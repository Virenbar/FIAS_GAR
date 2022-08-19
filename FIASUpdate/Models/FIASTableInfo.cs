using System;
using System.Data;

namespace FIASUpdate.Models
{
    public class FIASTableInfo
    {
        private FIASTableInfo(DataRow R)
        {
            Name = R.Field<string>("Name");
            RowCount = R.Field<long>("RowCount");
            TotalMB = R.Field<decimal>("TotalMB");
            UsedMB = R.Field<decimal>("UsedMB");
            UnusedMB = R.Field<decimal>("UnusedMB");
            CanImport = R.Field<bool>("CanImport");
            LastImport = R.Field<DateTime?>("LastImport");
        }

        public bool CanImport { get; }
        public DateTime? LastImport { get; }
        public string Name { get; }
        public long RowCount { get; }
        public decimal TotalMB { get; }
        public decimal UnusedMB { get; }
        public decimal UsedMB { get; }

        public static FIASTableInfo Parse(DataRow R) => new FIASTableInfo(R);

        public override string ToString() => Name;
    }
}