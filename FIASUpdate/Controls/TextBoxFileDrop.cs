using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FIASUpdate.Controls
{
    public class TextBoxFileDrop : TextBox
    {
        public TextBoxFileDrop()
        {
            base.ReadOnly = true;
            AllowDrop = true;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(true)]
        public new bool ReadOnly { get; } = true;

        /// <summary>
        /// Открыть окно выбора файла
        /// </summary>
        public void SelectFile()
        {
            var F = new OpenFileDialog { InitialDirectory = Text };
            if (F.ShowDialog() == DialogResult.OK) { Text = F.FileName; }
        }

        private static bool IsValid(string file)
        {
            return file.EndsWith(".zip") && File.Exists(file);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data is null) { return; }
            var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (IsValid(file)) { Text = file; }
            OnTextChanged(new System.EventArgs());
        }

        protected override void OnDragEnter(DragEventArgs e) => ProcessDrag(e);

        protected override void OnDragOver(DragEventArgs e) => ProcessDrag(e);

        private static void ProcessDrag(DragEventArgs e)
        {
            var Effect = DragDropEffects.None;
            if (e.Data is null) { return; }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (IsValid(file)) { Effect = DragDropEffects.Link; }
            }
            e.Effect = Effect;
        }
    }
}