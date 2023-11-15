using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FIASUpdate.Controls
{
    public partial class UC_DatabaseInfo : UserControl
    {
        private List<string> _subjects;
        private DateTime? _version;

        public UC_DatabaseInfo()
        {
            InitializeComponent();
        }

        public List<string> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                TB_Subject.Text = value is null ? "" : string.Join(" ", value);
            }
        }

        public DateTime? Version
        {
            get => _version;
            set
            {
                _version = value;
                TB_Version.Text = value is null ? "" : $"{value:yyyy.MM.dd}";
            }
        }
    }
}