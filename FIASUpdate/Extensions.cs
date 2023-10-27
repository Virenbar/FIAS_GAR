using Microsoft.SqlServer.Management.Smo;

namespace FIASUpdate
{
    internal static class Extensions
    {
        public static string TrimSpaces(this string str)
        {
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }

        public static Column Clone(this Column column)
        {
            var copy = new Column
            {
                Name = column.Name,
                DataType = column.DataType,
                Default = column.Default,
                Identity = column.Identity,
                IdentityIncrement = column.IdentityIncrement,
                IdentitySeed = column.IdentitySeed,
                Nullable = column.Nullable
            };
            return copy;
        }

        public static Column CloneTo(this Column column, Table table)
        {
            var copy = new Column(table, column.Name)
            {
                DataType = column.DataType,
                Default = column.Default,
                Identity = column.Identity,
                IdentityIncrement = column.IdentityIncrement,
                IdentitySeed = column.IdentitySeed,
                Nullable = column.Nullable
            };
            table.Columns.Add(copy);
            return copy;
        }
    }
}