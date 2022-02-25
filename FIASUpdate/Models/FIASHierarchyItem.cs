using System.Data;

namespace FIASUpdate.Models
{
    public class FIASHierarchyItem
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string NameFull { get; set; }
        public string ObjectGUID { get; set; }
        public string Type { get; set; }

        public static FIASHierarchyItem Parse(DataRow R)
        {
            return new FIASHierarchyItem
            {
                ObjectGUID = R.Field<string>("ObjectGUID"),
                Level = R.Field<int>("Level"),
                Type = R.Field<string>("Type"),
                Name = R.Field<string>("Name"),
                NameFull = R.Field<string>("NameFull")
            };
        }
    }
}