using FIAS.Core;
using FIAS.Core.Extensions;
using FIAS.Core.Stores;
using FIASUpdate.Properties;
using JANL.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormAddressSearch : Form
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly string DBName = Settings.DBName;
        private readonly List<(RadioButton RB, FIASDivision Division)> RB_F;
        private readonly FIASStore Store = new FIASStore(Settings.SQLConnection);

        public FormAddressSearch()
        {
            InitializeComponent();
            Level = 10;
            RB_F = new List<(RadioButton RB, FIASDivision Division)> {
                (RB_ADM, FIASDivision.adm),
                (RB_MUN, FIASDivision.mun)
            };
        }

        private void RefreshUI()
        {
            Text = "Справочник ФИАС";
            if (LV_Search.Items.Count > 0) { Text += $" (Объектов: {LV_Search.Items.Count:N0})"; }

            MI_PDF.Enabled = TB_GUID.Text.Length > 0;
            MI_Parameters.Enabled = TB_GUID.Text.Length > 0;
            MI_URL.Enabled = TB_GUID.Text.Length > 0;
            B_CopyGUID.Enabled = TB_GUID.Text.Length > 0;
            B_CopyAddress.Enabled = TB_Address.Text.Length > 0;
        }

        private async Task Search()
        {
            if (TB_Search.Text.Length < 2) { return; }
            UIState(false);
            try
            {
                var S = TB_Search.Text.TrimSpaces();
                var Limit = (int)NUD_Limit.Value;
                var Result = await Store.Search(Division, S, Level, Limit);
                LV_Search.BeginUpdate();
                LV_Search.Items.Clear();
                foreach (var R in Result)
                {
                    var LVI = new ListViewItem(R.ObjectGUID) { Font = TB_GUID.Font, UseItemStyleForSubItems = false };
                    LVI.SubItems.Add(R.AddressFull).Font = Font;
                    LV_Search.Items.Add(LVI);
                }
                if (LV_Search.Items.Count > 0) { LV_Search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); }
                LV_Search.EndUpdate();
                RefreshUI();
            }
            catch (Exception E) { this.ShowError(E); }
            finally { UIState(true); }
        }

        private void UIState(bool value)
        {
            TB_Search.ReadOnly = !value;
            B_Search.Enabled = value;
            CB_Level.Enabled = value;
            NUD_Limit.Enabled = value;
            RB_ADM.Enabled = value;
            RB_MUN.Enabled = value;
        }

        #region Properties

        /// <summary>
        /// Выбранный адрес
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Деление
        /// </summary>
        private FIASDivision Division => RB_F.First(R => R.RB.Checked).Division;

        /// <summary>
        /// Выбранный GUID
        /// </summary>
        public Guid GUID { get; private set; }

        /// <summary>
        /// Уровень иерархии по умолчанию
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Адрес/GUID для поиска
        /// </summary>
        public string SearchText { get; set; }

        #endregion Properties

        #region UI Events

        private void B_CopyAddress_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_Address.Text);
        }

        private void B_CopyGUID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_GUID.Text);
        }

        private async void B_Search_Click(object sender, EventArgs e) => await Search();

        private async void CB_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level = Convert.ToInt32(CB_Level.SelectedValue);
            await Search();
        }

        private async void FormAddressSearch_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            TB_Search.Text = SearchText;
            CB_Level.SelectedIndexChanged -= CB_Level_SelectedIndexChanged;
            UIState(false);
            try
            {
                CB_Level.DataSource = await Store.FIASLevels();
                CB_Level.DisplayMember = "Name";
                CB_Level.ValueMember = "Level";
                CB_Level.SelectedValue = Level;
                CB_Level.SelectedIndexChanged += CB_Level_SelectedIndexChanged;
                UIState(true);
            }
            catch (Exception E)
            {
                this.ShowError($"Не удалось подключиться к базе {DBName}: {E.Message}");
            }
            RefreshUI();
            await Search();
        }

        private void LV_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Search.SelectedItems.Count > 0)
            {
                var A = LV_Search.SelectedItems[0];
                TB_GUID.Text = A.SubItems[0].Text;
                TB_Address.Text = A.SubItems[1].Text;
            }
            else
            {
                TB_GUID.Text = string.Empty;
                TB_Address.Text = string.Empty;
            }
            RefreshUI();
        }

        private async void MI_DBInfo_Click(object sender, EventArgs e)
        {
            UIState(false);
            try
            {
                var D = await Store.Statistics();
                var S = string.Join(Environment.NewLine, D.Select(KV => $"{KV.Key}: {KV.Value}"));
                this.ShowInfo(S, "Информация о БД");
            }
            catch (Exception E) { this.ShowError(E.Message); }
            finally { UIState(true); }
        }

        private async void MI_Parameters_Click(object sender, EventArgs e)
        {
            UIState(false);
            try
            {
                var parameters = await Store.GetObjectParameters(TB_GUID.Text);
                var F = new FormDictionaryView
                {
                    Text = "Параметры объекта",
                    KeyHeader = "Параметр",
                    ValeuHeader = "Значение"
                };
                F.SetDictionary(parameters);
                F.ShowDialog(this);
            }
            catch (Exception E) { this.ShowError(E.Message); }
            finally { UIState(true); }
        }

        private void MI_PDF_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPDFStatementURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void MI_URL_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPageURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private async void RB_CheckedChanged(object sender, EventArgs e) => await Search();

        private async void TB_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Search();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Search.Clear();
                e.Handled = true;
            }
        }

        private void TB_Search_TextChanged(object sender, EventArgs e) => L_GUID.Visible = TB_Search.Text.IsGUID();

        #endregion UI Events
    }
}