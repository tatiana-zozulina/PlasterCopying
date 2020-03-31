using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlasterCopying
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Program : IExternalCommand
    {
        public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            var document = revit.Application.ActiveUIDocument.Document;
            try
            {
                string errorMessage;
                Logic.CreateLogic(document, out errorMessage);
                if (errorMessage != null)
                {
                    TaskDialog.Show("Ошибка", errorMessage);
                }
                else
                {
                    var levels = Logic.Levels
                        .ToDictionary(x => x.Id, x => x.Name);
                    var groups = Logic.GroupTypes
                        .ToDictionary(x => x.Id, x=> new Tuple<string, List<ElementId>>(x.Name, GetGroupId(x)));
                    var dialog = new Dialog(levels, groups);
                    dialog.ShowDialog();
                    while (dialog.DialogResult == DialogResult.OK)
                    {
                        // debug
                        var result = new StringBuilder();
                        result.AppendLine($"SelectedGroupId: {(dialog.SelectedGroupId == null ? 0 : dialog.SelectedGroupId.IntegerValue)}");
                        result.AppendLine($"SelectedStandartFloorId: {(dialog.SelectedStandartFloorId == null ? 0 : dialog.SelectedStandartFloorId.IntegerValue)}");
                        result.AppendLine("SelectedFinishingsIds:");
                        foreach (var x in dialog.SelectedFinishingsIds)
                            result.AppendLine(x.IntegerValue.ToString());
                        result.AppendLine($"SelectedUserGroupName: {dialog.SelectedUserGroupName}");
                        result.AppendLine("SelectedLevelsIds:");
                        foreach (var x in dialog.SelectedLevelsIds)
                            result.AppendLine(x.IntegerValue.ToString());
                        TaskDialog.Show("Selected", result.ToString());
                        // end debug
                        if (dialog.SelectedGroupId != null)
                        {
                            break;
                        }
                        else
                        {
                            var conflictFinishing = new List<ElementId>();
                            foreach (var finishingId in dialog.SelectedFinishingsIds)
                            {
                                if (Logic.IsFinishingInAnotherGroup(finishingId))
                                    conflictFinishing.Add(finishingId);
                            }
                            if (conflictFinishing.Count > 0)
                            {
                                var task = new TaskDialog("Конфликт");
                                var conflictNames = new List<string>();
                                foreach (var item in conflictFinishing)
                                    conflictNames.Add(GetNameById(document, item));
                                task.ExpandedContent = string.Join("\n", conflictFinishing);//conflictNames
                                task.MainInstruction = "Некоторые элементы уже включены в другие группы." +
                                "Их можно удалить из других групп либо пропустить." +
                                "Удалить элементы из других групп?";
                                var buttons = TaskDialogCommonButtons.No| TaskDialogCommonButtons.Retry| TaskDialogCommonButtons.Yes;
                                task.CommonButtons = buttons;
                                var taskResult = task.Show();
                                if (taskResult == TaskDialogResult.No)
                                {
                                    foreach (var item in conflictFinishing)
                                        dialog.SelectedFinishingsIds.Remove(item);
                                    break;
                                }
                                if (taskResult == TaskDialogResult.Yes)
                                {
                                    RemoveFinishingFromGroups(document, conflictFinishing);
                                    break;
                                }
                            }
                            else
                                break;
                        }
                        dialog.DialogResult = DialogResult.None;
                        dialog.ShowDialog();
                    }
                    //var group = document.Create.NewGroup(dialog.SelectedFinishingsIds);
                    //if(!string.IsNullOrEmpty(dialog.SelectedUserGroupName))
                    //    group.Name = dialog.SelectedUserGroupName;
                }
                
                //TaskDialog.Show("DuctManagement", "Погнали!");
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", e.ToString());
                return Result.Failed;
            }
            return Result.Succeeded;
        }

        private List<ElementId> GetGroupId(GroupType group)
        {
            var result = new List<ElementId>();
            foreach (Group g in group.Groups)
                result.Add(g.LevelId);
            return result;
        }

        private string GetNameById(Document document, ElementId id)
        {
            var element = document.GetElement(id);
            return element.Name;
        }

        private void RemoveFinishingFromGroups(Document document, List<ElementId> ids)
        {
            var collector = new FilteredElementCollector(document);
            var groups = collector.OfClass(typeof(Group))
                .ToElements();
            foreach (Group group in groups)
            {
                foreach (var id in ids)
                {
                    var name = group.Name;
                    var groupMembers = group.UngroupMembers();
                    //groupMembers.Remove(id);
                    if (groupMembers.Count > 0)
                        document.Create.NewGroup(groupMembers);
                }
            }
        }


    }
}
