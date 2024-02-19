using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FIAS.Core.Extensions
{
    public static class DataExtensions
    {
        public static Dictionary<K, V> ToDictionary<K, V>(this DataTable table, string key, string value)
        {
            return table.Rows.Cast<DataRow>().ToDictionary(R => R.Field<K>(key), R => R.Field<V>(value));
        }
    }
}