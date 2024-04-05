using JANL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FIASUpdate.Controls
{
    public class ToolStripTaskProgress : ToolStripStatusLabel
    {
        public ToolStripTaskProgress()
        {
            Progress = new Progress<TaskProgress>(Handler);
        }

        public void Clear()
        {
            _status = "-";
            _value = "-";
            UpdateText();
        }

        private void Handler(TaskProgress T)
        {
            if (T.HasStatus) { _status = T.Status; }
            if (T.HasValue)
            {
                _value = (T.Value + T.Max == 0) ? "" : $"{T.Value:N0}";
                _value += new string('|', T.Value / 100_000);
            }
            UpdateText();
        }

        private void UpdateText()
        {
            Text = $"Статус: {_status} {_value}";
        }

        #region Properties
        private string _status = "-";
        private string _value = "-";

        [Browsable(false)]
        public Progress<TaskProgress> Progress { get; }

        [Browsable(false)]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                UpdateText();
            }
        }

        [Browsable(false)]
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                UpdateText();
            }
        }

        #endregion Properties
    }
}