using System.Data;

namespace FIAS.API.Models
{
    public class FIASRegistryAddress
    {
        public string AddressFull { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string NameFull { get; set; }
        public string ObjectGUID { get; set; }
        public string ParentGUID { get; set; }
        public string Type { get; set; }

        public static FIASRegistryAddress Parse(DataRow R)
        {
            return new FIASRegistryAddress
            {
                ParentGUID = R.Field<string>("ParentGUID"),
                ObjectGUID = R.Field<string>("ObjectGUID"),
                Level = R.Field<int>("Level"),
                Type = R.Field<string>("Type"),
                Name = R.Field<string>("Name"),
                NameFull = R.Field<string>("NameFull"),
                AddressFull = R.Field<string>("AddressFull")
            };
        }
    }
}