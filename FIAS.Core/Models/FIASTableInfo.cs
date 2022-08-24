using System;
using System.Data;

namespace FIAS.Core.Models
{
    public class FIASTableInfo
    {
        public FIASTableInfo() { }

        protected FIASTableInfo(DataRow row)
        {
            Name = row.Field<string>("Name");
            RowCount = row.Field<long>("RowCount");
            TotalMB = row.Field<decimal>("TotalMB");
            UsedMB = row.Field<decimal>("UsedMB");
            UnusedMB = row.Field<decimal>("UnusedMB");
            CanImport = row.Field<bool>("CanImport");
            LastImport = row.Field<DateTime?>("LastImport");
        }

        public bool CanImport { get; }
        public DateTime? LastImport { get; }
        public string Name { get; }
        public long RowCount { get; }
        public decimal TotalMB { get; }
        public decimal UnusedMB { get; }
        public decimal UsedMB { get; }

        public static FIASTableInfo Parse(DataRow row) => new FIASTableInfo(row);

        public override string ToString() => Name;
    }
}