namespace PlasterCopying
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupsRadioButton = new System.Windows.Forms.RadioButton();
            this.StandartFloorRadioButton = new System.Windows.Forms.RadioButton();
            this.LevelsLabel = new System.Windows.Forms.Label();
            this.LevelsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.FinishingListBox = new System.Windows.Forms.CheckedListBox();
            this.FinishingLabel = new System.Windows.Forms.Label();
            this.Copy = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GroupsComboBox = new System.Windows.Forms.ComboBox();
            this.StandartFloorComboBox = new System.Windows.Forms.ComboBox();
            this.GroupError = new System.Windows.Forms.Label();
            this.StandartFloorError = new System.Windows.Forms.Label();
            this.FinishingError = new System.Windows.Forms.Label();
            this.LevelError = new System.Windows.Forms.Label();
            this.UserGroupName = new System.Windows.Forms.Label();
            this.UserGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.NameError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GroupsRadioButton
            // 
            this.GroupsRadioButton.AutoSize = true;
            this.GroupsRadioButton.Checked = true;
            this.GroupsRadioButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.GroupsRadioButton.Location = new System.Drawing.Point(12, 12);
            this.GroupsRadioButton.Name = "GroupsRadioButton";
            this.GroupsRadioButton.Size = new System.Drawing.Size(106, 17);
            this.GroupsRadioButton.TabIndex = 0;
            this.GroupsRadioButton.TabStop = true;
            this.GroupsRadioButton.Text = "Группа Отделки";
            this.GroupsRadioButton.UseVisualStyleBackColor = true;
            this.GroupsRadioButton.CheckedChanged += new System.EventHandler(this.GroupsRadioButton_CheckedChanged);
            // 
            // StandartFloorRadioButton
            // 
            this.StandartFloorRadioButton.AutoSize = true;
            this.StandartFloorRadioButton.Location = new System.Drawing.Point(12, 75);
            this.StandartFloorRadioButton.Name = "StandartFloorRadioButton";
            this.StandartFloorRadioButton.Size = new System.Drawing.Size(97, 17);
            this.StandartFloorRadioButton.TabIndex = 2;
            this.StandartFloorRadioButton.Text = "Типовой Этаж";
            this.StandartFloorRadioButton.UseVisualStyleBackColor = true;
            this.StandartFloorRadioButton.CheckedChanged += new System.EventHandler(this.StandartFloorRadioButton_CheckedChanged);
            // 
            // LevelsLabel
            // 
            this.LevelsLabel.AutoSize = true;
            this.LevelsLabel.Enabled = false;
            this.LevelsLabel.Location = new System.Drawing.Point(261, 12);
            this.LevelsLabel.Name = "LevelsLabel";
            this.LevelsLabel.Size = new System.Drawing.Size(114, 13);
            this.LevelsLabel.TabIndex = 4;
            this.LevelsLabel.Text = "Уровни копирования";
            // 
            // LevelsCheckedListBox
            // 
            this.LevelsCheckedListBox.CheckOnClick = true;
            this.LevelsCheckedListBox.FormattingEnabled = true;
            this.LevelsCheckedListBox.Location = new System.Drawing.Point(255, 28);
            this.LevelsCheckedListBox.Name = "LevelsCheckedListBox";
            this.LevelsCheckedListBox.Size = new System.Drawing.Size(202, 289);
            this.LevelsCheckedListBox.TabIndex = 5;
            this.LevelsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.LevelsCheckedListBox_SelectedIndexChanged);
            // 
            // FinishingListBox
            // 
            this.FinishingListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.FinishingListBox.CheckOnClick = true;
            this.FinishingListBox.Enabled = false;
            this.FinishingListBox.FormattingEnabled = true;
            this.FinishingListBox.Location = new System.Drawing.Point(26, 163);
            this.FinishingListBox.Name = "FinishingListBox";
            this.FinishingListBox.Size = new System.Drawing.Size(201, 94);
            this.FinishingListBox.TabIndex = 6;
            this.FinishingListBox.SelectedIndexChanged += new System.EventHandler(this.FinishingListBox_SelectedIndexChanged);
            // 
            // FinishingLabel
            // 
            this.FinishingLabel.AutoSize = true;
            this.FinishingLabel.Enabled = false;
            this.FinishingLabel.Location = new System.Drawing.Point(26, 145);
            this.FinishingLabel.Name = "FinishingLabel";
            this.FinishingLabel.Size = new System.Drawing.Size(136, 13);
            this.FinishingLabel.TabIndex = 7;
            this.FinishingLabel.Text = "Типы отделочных систем";
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(388, 336);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(75, 23);
            this.Copy.TabIndex = 8;
            this.Copy.Text = "Копировать";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // GroupsComboBox
            // 
            this.GroupsComboBox.FormattingEnabled = true;
            this.GroupsComboBox.Location = new System.Drawing.Point(26, 35);
            this.GroupsComboBox.Name = "GroupsComboBox";
            this.GroupsComboBox.Size = new System.Drawing.Size(202, 21);
            this.GroupsComboBox.TabIndex = 9;
            this.GroupsComboBox.Text = "--Выберете группу--";
            this.GroupsComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupsComboBox_SelectedIndexChanged);
            // 
            // StandartFloorComboBox
            // 
            this.StandartFloorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.StandartFloorComboBox.FormattingEnabled = true;
            this.StandartFloorComboBox.Location = new System.Drawing.Point(26, 98);
            this.StandartFloorComboBox.Name = "StandartFloorComboBox";
            this.StandartFloorComboBox.Size = new System.Drawing.Size(202, 21);
            this.StandartFloorComboBox.TabIndex = 10;
            this.StandartFloorComboBox.Text = "--Выберете типовой этаж--";
            this.StandartFloorComboBox.SelectedIndexChanged += new System.EventHandler(this.StandartFloorComboBox_SelectedIndexChanged);
            // 
            // GroupError
            // 
            this.GroupError.AutoSize = true;
            this.GroupError.ForeColor = System.Drawing.Color.DarkRed;
            this.GroupError.Location = new System.Drawing.Point(30, 59);
            this.GroupError.Name = "GroupError";
            this.GroupError.Size = new System.Drawing.Size(96, 13);
            this.GroupError.TabIndex = 11;
            this.GroupError.Text = "Выберете группу.";
            this.GroupError.Visible = false;
            // 
            // StandartFloorError
            // 
            this.StandartFloorError.AutoSize = true;
            this.StandartFloorError.BackColor = System.Drawing.SystemColors.Control;
            this.StandartFloorError.ForeColor = System.Drawing.Color.DarkRed;
            this.StandartFloorError.Location = new System.Drawing.Point(30, 122);
            this.StandartFloorError.Name = "StandartFloorError";
            this.StandartFloorError.Size = new System.Drawing.Size(132, 13);
            this.StandartFloorError.TabIndex = 12;
            this.StandartFloorError.Text = "Выберете типовой этаж.";
            this.StandartFloorError.Visible = false;
            // 
            // FinishingError
            // 
            this.FinishingError.AutoSize = true;
            this.FinishingError.ForeColor = System.Drawing.Color.DarkRed;
            this.FinishingError.Location = new System.Drawing.Point(30, 260);
            this.FinishingError.Name = "FinishingError";
            this.FinishingError.Size = new System.Drawing.Size(127, 13);
            this.FinishingError.TabIndex = 13;
            this.FinishingError.Text = "Не выбран ни один тип.";
            this.FinishingError.Visible = false;
            // 
            // LevelError
            // 
            this.LevelError.AutoSize = true;
            this.LevelError.ForeColor = System.Drawing.Color.DarkRed;
            this.LevelError.Location = new System.Drawing.Point(261, 320);
            this.LevelError.Name = "LevelError";
            this.LevelError.Size = new System.Drawing.Size(151, 13);
            this.LevelError.TabIndex = 14;
            this.LevelError.Text = "Не выбран ни один уровень.";
            this.LevelError.Visible = false;
            // 
            // UserGroupName
            // 
            this.UserGroupName.AutoSize = true;
            this.UserGroupName.Enabled = false;
            this.UserGroupName.Location = new System.Drawing.Point(26, 281);
            this.UserGroupName.Name = "UserGroupName";
            this.UserGroupName.Size = new System.Drawing.Size(139, 13);
            this.UserGroupName.TabIndex = 15;
            this.UserGroupName.Text = "Имя создаваемой группы";
            // 
            // UserGroupNameTextBox
            // 
            this.UserGroupNameTextBox.Enabled = false;
            this.UserGroupNameTextBox.Location = new System.Drawing.Point(26, 297);
            this.UserGroupNameTextBox.Name = "UserGroupNameTextBox";
            this.UserGroupNameTextBox.Size = new System.Drawing.Size(202, 20);
            this.UserGroupNameTextBox.TabIndex = 16;
            this.UserGroupNameTextBox.TextChanged += new System.EventHandler(this.UserGroupNameTextBox_TextChanged);
            // 
            // NameError
            // 
            this.NameError.AutoSize = true;
            this.NameError.ForeColor = System.Drawing.Color.DarkRed;
            this.NameError.Location = new System.Drawing.Point(30, 320);
            this.NameError.Name = "NameError";
            this.NameError.Size = new System.Drawing.Size(70, 13);
            this.NameError.TabIndex = 17;
            this.NameError.Text = "Имя занято!";
            this.NameError.Visible = false;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 371);
            this.Controls.Add(this.NameError);
            this.Controls.Add(this.UserGroupNameTextBox);
            this.Controls.Add(this.UserGroupName);
            this.Controls.Add(this.LevelError);
            this.Controls.Add(this.FinishingError);
            this.Controls.Add(this.StandartFloorError);
            this.Controls.Add(this.GroupError);
            this.Controls.Add(this.StandartFloorComboBox);
            this.Controls.Add(this.GroupsComboBox);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.FinishingLabel);
            this.Controls.Add(this.FinishingListBox);
            this.Controls.Add(this.LevelsCheckedListBox);
            this.Controls.Add(this.LevelsLabel);
            this.Controls.Add(this.StandartFloorRadioButton);
            this.Controls.Add(this.GroupsRadioButton);
            this.Name = "Dialog";
            this.Text = "Копирование штукатурки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton GroupsRadioButton;
        private System.Windows.Forms.RadioButton StandartFloorRadioButton;
        private System.Windows.Forms.Label LevelsLabel;
        private System.Windows.Forms.CheckedListBox LevelsCheckedListBox;
        private System.Windows.Forms.CheckedListBox FinishingListBox;
        private System.Windows.Forms.Label FinishingLabel;
        private System.Windows.Forms.Button Copy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox GroupsComboBox;
        private System.Windows.Forms.ComboBox StandartFloorComboBox;
        private System.Windows.Forms.Label GroupError;
        private System.Windows.Forms.Label StandartFloorError;
        private System.Windows.Forms.Label FinishingError;
        private System.Windows.Forms.Label LevelError;
        private System.Windows.Forms.Label UserGroupName;
        private System.Windows.Forms.TextBox UserGroupNameTextBox;
        private System.Windows.Forms.Label NameError;
    }
}