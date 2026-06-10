using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FIAS.Core.Stores;

namespace FIASUpdate.Forms
{
    public partial class FormSubjectList : Form
    {
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(FIASProperties.SQLConnection);

        public FormSubjectList()
        {
            InitializeComponent();
        }

        private void CheckItems(bool state)
        {
            LV_Subjects.BeginUpdate();
            foreach (SubjectLVI item in LV_Subjects.Items)
            {
                item.Checked = state;
            }
            LV_Subjects.EndUpdate();
        }

        private void LoadData()
        {
            var subjects = Store.GetSubjects();
            var items = SubjectStore.GetSubjects()
                .Select(KV => new SubjectLVI(KV.Key, KV.Value) { Checked = subjects.Contains(KV.Key) })
                .OrderByDescending(I => I.Checked)
                .ThenBy(I => I.SubjectCode)
                .ToArray();

            LV_Subjects.BeginUpdate();
            LV_Subjects.Items.Clear();
            LV_Subjects.Items.AddRange(items);
            LV_Subjects.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            LV_Subjects.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Subjects.EndUpdate();
        }

        private void SaveData()
        {
            var subjects = LV_Subjects.CheckedItems
                .Cast<SubjectLVI>()
                .Select(I => I.SubjectCode)
                .OrderBy(I => I)
                .ToList();
            Store.SetSubjects(subjects);
            LoadData();
        }

        #region UI Events

        private void B_DeselectAll_Click(object sender, EventArgs e) => CheckItems(false);

        private void B_Refresh_Click(object sender, EventArgs e) => LoadData();

        private void B_Save_Click(object sender, EventArgs e) => SaveData();

        private void B_SelectAll_Click(object sender, EventArgs e) => CheckItems(true);

        private void FormSubjectList_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            LoadData();
        }

        #endregion UI Events

        private class SubjectLVI : ListViewItem
        {
            public SubjectLVI(string code, string name) : base(code)
            {
                SubItems.Add(name);
            }

            public string SubjectCode => Text;
            public string SubjectName => SubItems[1].Text;
        }
    }
}