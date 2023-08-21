using System.Windows.Forms;

namespace FIASUpdate.Models
{
    internal class FIASArchiveItem : ListViewItem
    {
        public FIASArchiveItem(FIASArchive archive) : base($"{archive.Date:yyyy.MM.dd}")
        {
            Archive = archive;
            SubItems.Add(Archive.TextVersion);
            SubItems.Add(Archive.IsExsists() ? "Скачан" : "Не скачан");
        }

        public string State
        {
            get => SubItems[2].Text;
            set => SubItems[2].Text = value;
        }

        public FIASArchive Archive { get; }
    }
}