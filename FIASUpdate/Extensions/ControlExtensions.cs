using System.Windows.Forms;
using FIASUpdate.Properties;

namespace FIASUpdate.Extensions
{
    public static class ControlExtensions
    {
        public static void AutoSizeColumns(this ListView listView)
        {
            var dummy = new ColumnHeader();
            // dummy gets the last DisplayIndex
            listView.Columns.Add(dummy);
            // dummy gets the remaining space instead
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView.Columns.Remove(dummy);
        }

        public static void BindSettings(this Form form)
        {
            form.DataBindings.Add(new Binding("Font", Settings.Default, "DefaultFont", true, DataSourceUpdateMode.OnPropertyChanged));
            form.DataBindings.Add(new Binding("ForeColor", Settings.Default, "DefaultForeColor", true, DataSourceUpdateMode.OnPropertyChanged));
            form.DataBindings.Add(new Binding("BackColor", Settings.Default, "DefaultBackColor", true, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}