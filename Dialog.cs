using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlasterCopying
{
    public partial class Dialog : System.Windows.Forms.Form
    {
        public ElementId SelectedGroupId { get; private set; }
        public ElementId SelectedStandartFloorId { get; private set; }
        public List<ElementId> SelectedLevelsIds { get; private set; }
        public List<ElementId> SelectedFinishingsIds { get; set; } //todo
        public string SelectedUserGroupName { get; private set; }

        private WallType[] Finishing;
        private readonly Dictionary<ElementId, string> LevelWithId = new Dictionary<ElementId, string>();
        private readonly Dictionary<ElementId, Tuple<string, List<ElementId>>> Groups = new Dictionary<ElementId, Tuple<string, List<ElementId>>>();
        public Dialog(Dictionary<ElementId, string> levelWithId, Dictionary<ElementId, Tuple<string, List<ElementId>>> groups)
        {
            InitializeComponent();
            if (this.DialogResult == DialogResult.Cancel)
                return;
            LevelWithId = levelWithId;
            Groups = groups;
            foreach (var level in LevelWithId)
            {
                LevelsCheckedListBox.Items.Add(level.Value, false);
                StandartFloorComboBox.Items.Add(level.Value);
            }
            foreach (var group in Groups)
                GroupsComboBox.Items.Add(group.Value.Item1);
        }

        private void GroupsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            HideErrorLabels();
            if (!GroupsRadioButton.Checked)
            {
                GroupsComboBox.SelectedIndex = -1;
                GroupsComboBox.DropDownStyle = ComboBoxStyle.Simple;
                GroupsComboBox.Text = "--Выберете группу--";
                GroupsComboBox.Enabled = false;
            }
            else
            {
                GroupsComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                GroupsComboBox.Text = "--Выберете группу--";
                GroupsComboBox.Enabled = true;
                LevelsCheckedListBox.Items.Clear();
                foreach (var level in LevelWithId)
                    LevelsCheckedListBox.Items.Add(level.Value, false);

            }
        }

        private void StandartFloorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            HideErrorLabels();
            if (!StandartFloorRadioButton.Checked)
            {
                UserGroupNameTextBox.Clear();
                StandartFloorComboBox.SelectedIndex = -1;
                StandartFloorComboBox.DropDownStyle = ComboBoxStyle.Simple;
                StandartFloorComboBox.Text = "--Выберете типовой этаж--";
                StandartFloorComboBox.Enabled = false;
                FinishingListBox.Enabled = false;
                UserGroupNameTextBox.Enabled = false;
                FinishingListBox.BackColor = System.Drawing.Color.FromArgb(236, 236, 236);
                while (FinishingListBox.CheckedItems.Count > 0)
                    FinishingListBox.SetItemChecked(FinishingListBox.CheckedIndices[0], false);
            }
            else
            {
                LevelsCheckedListBox.Items.Clear();
                StandartFloorComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                StandartFloorComboBox.Text = "--Выберете типовой этаж--";
                StandartFloorComboBox.Enabled = true;
                FinishingListBox.Enabled = true;
                UserGroupNameTextBox.Enabled = true;
                FinishingListBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (CheckErrorLabels())
                return;
            if (!Logic.IsGroupNameValid(UserGroupNameTextBox.Text))
            {
                NameError.Visible = true;
                return;
            }
            SelectedGroupId = GroupsRadioButton.Checked ?
                Groups.ElementAt(GroupsComboBox.SelectedIndex).Key :
                null;
            SelectedStandartFloorId = StandartFloorRadioButton.Checked ?
                LevelWithId.ElementAt(StandartFloorComboBox.SelectedIndex).Key :
                null;
            SelectedFinishingsIds = new List<ElementId>();
            SelectedLevelsIds = new List<ElementId>();
            for (int i = 0; i < FinishingListBox.Items.Count; i++)
            {
                if (FinishingListBox.CheckedItems.Contains(FinishingListBox.Items[i]))
                    SelectedFinishingsIds.Add(Finishing[i].Id);
            }
            foreach (var level in LevelsCheckedListBox.CheckedItems)
            {
                SelectedLevelsIds.Add(LevelWithId.FirstOrDefault(x => x.Value == level.ToString()).Key);
            }
            SelectedUserGroupName = UserGroupNameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GroupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupError.Visible = false;
            if (GroupsComboBox.SelectedIndex >= 0)
            {
                LevelsCheckedListBox.Items.Clear();
                foreach (var level in LevelWithId)
                {
                    var key = level.Key;
                    var x = Groups.ElementAt(GroupsComboBox.SelectedIndex).Value.Item2;
                    if (!x.Contains(key))
                        LevelsCheckedListBox.Items.Add(level.Value);
                }
            }
        }

        private void StandartFloorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelsCheckedListBox.Items.Clear();
            FinishingListBox.Items.Clear();
            if (StandartFloorComboBox.SelectedIndex >= 0)
            {
                for (var i=0; i< LevelWithId.Count; i++)
                {
                    if(i!= StandartFloorComboBox.SelectedIndex)
                        LevelsCheckedListBox.Items.Add(LevelWithId.ElementAt(i).Value, false);
                }
                Finishing = Logic.GetTypesOfWallsForLevel(LevelWithId.ElementAt(StandartFloorComboBox.SelectedIndex).Key);
                for (var i = 0; i < Finishing.Length; i++)
                {
                    FinishingListBox.Items.Add(Finishing[i].Name);
                }
            }
            StandartFloorError.Visible = false;
        }

        private void FinishingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinishingError.Visible = false;
        }

        private void LevelsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelError.Visible = false;
        }

        private bool CheckErrorLabels()
        {
            GroupError.Visible = GroupsRadioButton.Checked 
                && GroupsComboBox.SelectedIndex < 0;
            StandartFloorError.Visible = StandartFloorRadioButton.Checked 
                && StandartFloorComboBox.SelectedIndex < 0;
            FinishingError.Visible = StandartFloorRadioButton.Checked 
                && FinishingListBox.CheckedItems.Count == 0;
            LevelError.Visible = LevelsCheckedListBox.CheckedItems.Count == 0;

            return GroupError.Visible
                || StandartFloorError.Visible
                || FinishingError.Visible
                || LevelError.Visible;
        }

        private void HideErrorLabels()
        {
            GroupError.Visible = false;
            StandartFloorError.Visible = false;
            FinishingError.Visible = false;
            LevelError.Visible = false;
        }

        private void UserGroupNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameError.Visible)
                NameError.Visible = false;
        }
    }
}
