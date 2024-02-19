using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FIAS.Core.Models
{
    public class FIASRegistryAddress
    {
        public FIASRegistryAddress() { }

        protected FIASRegistryAddress(DataRow row)
        {
            ParentGUID = row.Field<string>("ParentGUID");
            ObjectGUID = row.Field<string>("ObjectGUID");
            Level = row.Field<int>("Level");
            Type = row.Field<string>("Type");
            Name = row.Field<string>("Name");
            NameFull = row.Field<string>("NameFull");
            AddressFull = row.Field<string>("AddressFull");
        }

        public string AddressFull { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string NameFull { get; set; }
        public string ObjectGUID { get; set; }
        public string ParentGUID { get; set; }
        public string Type { get; set; }

        public static List<FIASRegistryAddress> Parse(DataTable table) => table.Rows.Cast<DataRow>().Select(Parse).ToList();

        public static FIASRegistryAddress Parse(DataRow row) => new FIASRegistryAddress(row);

        public override string ToString() => $"{AddressFull}({ObjectGUID})";
    }
}