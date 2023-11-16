using System;
using System.Windows.Forms;

namespace FIASUpdate.Models
{
    internal class FIASArchiveItem : ListViewItem
    {
        public FIASArchiveItem(FIASArchive archive) : base($"{archive.Date:yyyy.MM.dd}")
        {
            Archive = archive;
            SubItems.Add(Archive.TextVersion);
            SubItems.Add("-");
            SubItems.Add("-");
            Refresh();
        }

        public void Refresh()
        {
            Archive.Refresh();
            SubItems[2].Text = Archive.Exsists ? "Скачан" : "Не скачан";
            SubItems[3].Text = Archive.ArchiveSize.HasValue ? $"{Archive.ArchiveSize / Math.Pow(1024, 2):N2} МБ" : "-";
        }

        public string State
        {
            get => SubItems[2].Text;
            set => SubItems[2].Text = value;
        }

        public FIASArchive Archive { get; }
    }
}