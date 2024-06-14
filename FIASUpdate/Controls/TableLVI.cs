using FIAS.Core.Models;
using System.Windows.Forms;

namespace FIASUpdate.Controls
{
    internal class TableLVI : ListViewItem
    {
        public TableLVI(FIASTableInfo table)
        {
            Table = table;
            Text = Table.Name;
            SubItems.AddRange(new[] { $"{Table.RowCount:N0}", $"{Table.TotalMB:N2} МБ", $"{Table.LastImport:yyyy.MM.dd}" });
            Checked = Table.CanImport;
        }

        public new string Name => Table.Name;
        public FIASTableInfo Table { get; }
    }
}