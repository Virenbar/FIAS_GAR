using System;
using System.Windows.Forms;

namespace FIASUpdate.Models
{
    internal class FIASArchiveLVI : ListViewItem
    {
        public FIASArchiveLVI(FIASArchive archive) : base($"{archive.Date:yyyy.MM.dd}")
        {
            Archive = archive;
            SubItems.Add(Archive.TextVersion);
            SubItems.Add("-");
            SubItems.Add("-");
            Refresh();
        }

        public FIASArchive Archive { get; }

        public string State
        {
            get => SubItems[3].Text;
            set
            {
                if (SubItems[3].Text == value) { return; }
                SubItems[3].Text = value;
            }
        }

        public void Refresh()
        {
            Archive.Refresh();
            SubItems[2].Text = Archive.ArchiveSize.HasValue ? $"{Archive.ArchiveSize / Math.Pow(1024, 2):N2} МБ" : "-";
            SubItems[3].Text = Archive.Exsists ? "Архив скачан" : "Архив не скачан";
        }
    }
}