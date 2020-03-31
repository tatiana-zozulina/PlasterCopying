using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasterCopying
{
    static class Logic
    {
        public static Autodesk.Revit.DB.Document Document { get; private set; }
        public static Level[] Levels { get; private set; }
        public static GroupType[] GroupTypes { get; private set; }

        private static string[] GroupTypeNames;

        public static void CreateLogic(Autodesk.Revit.DB.Document document, out string message)
        {
            Document = document;
            Levels = GetLevels();
            if (Levels.Length == 0)
            {
                message = "В текущем проекте нет уровней для копирования!";
                return;
            }
            message = null;
            GroupTypes = GetGroups();
        }

        public static WallType[] GetTypesOfWallsForLevel(ElementId levelId)
        {
            var collector = new FilteredElementCollector(Document);
            var levelFilter = new ElementLevelFilter(levelId);
            var allWallsOnLevel = collector
                .OfClass(typeof(Wall))
                .WherePasses(levelFilter)
                .ToElements()
                .Select(x => ((Wall)x).WallType)
                .Where(x => x.Width < 0.17 );
            List<WallType> result = new List<WallType>();
            List<int> resultId = new List<int>();
            foreach (var wall in allWallsOnLevel)
            {
                if (!resultId.Contains(wall.Id.IntegerValue))
                {
                    result.Add(wall);
                    resultId.Add(wall.Id.IntegerValue);
                }
            }
            return result.ToArray();
        }

        public static bool IsGroupNameValid(string groupName)
        {
            return !GroupTypeNames.Contains(groupName);
        }

        public static bool IsFinishingInAnotherGroup(ElementId id)
        {
            var element = Document.GetElement(id);
            return element.GroupId != null;
        }
        
        private static Level[] GetLevels()
        {
            var collector = new FilteredElementCollector(Document);
            var levels = collector.OfClass(typeof(Level))
                .ToElements()
                .Select(x => (Level)x)
                .OrderBy(x => x.ProjectElevation)
                .ToArray();
            return levels;
        }

        private static GroupType[] GetGroups()
        {
            var collector = new FilteredElementCollector(Document);
            var groupTypes = collector.OfClass(typeof(GroupType))
                .ToElements()
                .Select(x => (GroupType)x);
            GroupTypeNames = groupTypes.Select(x => x.Name).ToArray();
            var result = groupTypes
                .Where(x => !x.Groups.IsEmpty && IsGroupTypeWallsWithLevel(x))
                .ToArray();
            return result;
        }

        private static bool IsGroupTypeWallsWithLevel(GroupType groupType)
        {
            var groupSet = groupType.Groups;
            foreach (Group group in groupSet)
            {
                var memberIds = group.GetMemberIds();
                var levelId = Document.GetElement(memberIds.First()).LevelId;
                foreach (var id in memberIds)
                {
                    var element = Document.GetElement(id);
                    if (levelId != element.LevelId 
                        || element.Category == null
                        || (BuiltInCategory)element.Category.Id.IntegerValue != BuiltInCategory.OST_Walls)
                        return false;
                }
                break;
            }
            return true;
        }
    
    }
}
