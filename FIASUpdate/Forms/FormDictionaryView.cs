using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormDictionaryView : Form
    {
        public FormDictionaryView()
        {
            InitializeComponent();
        }

        public FormDictionaryView(Dictionary<dynamic, dynamic> dictionary) : this()
        {
            SetDictionary(dictionary);
        }

        public void SetDictionary<K, V>(Dictionary<K, V> dictionary)
        {
            LV.BeginUpdate();
            var items = dictionary.Select(ToLVI).ToArray();
            LV.Items.AddRange(items);
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV.EndUpdate();
        }

        private void B_Copy_Click(object sender, EventArgs e)
        {
            var text = LV.SelectedItems[0].SubItems[1].Text;
            Clipboard.SetText(text);
        }

        private void FormDictionaryView_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
        }

        private void LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            B_Copy.Enabled = LV.SelectedItems.Count > 0;
        }

        private ListViewItem ToLVI<K, V>(KeyValuePair<K, V> pair)
        {
            var item = new ListViewItem(pair.Key.ToString());
            item.SubItems.Add(pair.Value.ToString());
            return item;
        }

        #region Properties

        public string KeyHeader
        {
            get => CH_Key.Text;
            set => CH_Key.Text = value;
        }

        public string ValeuHeader
        {
            get => CH_Value.Text;
            set => CH_Value.Text = value;
        }

        #endregion Properties
    }
}