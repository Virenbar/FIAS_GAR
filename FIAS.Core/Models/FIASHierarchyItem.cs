using System.Data;

namespace FIAS.Core.Models
{
    public class FIASHierarchyItem
    {
        public FIASHierarchyItem() { }

        protected FIASHierarchyItem(DataRow row)
        {
            ObjectGUID = row.Field<string>("ObjectGUID");
            Level = row.Field<int>("Level");
            Type = row.Field<string>("Type");
            Name = row.Field<string>("Name");
            NameFull = row.Field<string>("NameFull");
        }

        public int Level { get; set; }
        public string Name { get; set; }
        public string NameFull { get; set; }
        public string ObjectGUID { get; set; }
        public string Type { get; set; }

        public static FIASHierarchyItem Parse(DataRow row) => new FIASHierarchyItem(row);

        public override string ToString() => $"{NameFull}({ObjectGUID})";
    }
}