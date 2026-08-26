using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIAS.Core;
using FIAS.Core.Extensions;
using FIAS.Core.Models;
using FIAS.Core.Stores;
using FIASUpdate.Controls;
using FIASUpdate.Properties;
using JANL.Extensions;

namespace FIASUpdate.Forms
{
    public partial class FormAddressSearch : Form
    {
        private readonly string DBName = Settings.Default.DBName;
        private readonly List<(RadioButton RB, FIASDivision Division)> RB_F;
        private readonly FIASStore Store = new FIASStore(Settings.Default.SQLConnection);

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
        }

        private async Task Search()
        {
            if (TB_Search.Text.Length < 2) { return; }
            UIState(false);
            try
            {
                var search = TB_Search.Text.TrimSpaces();
                var limit = (int)NUD_Limit.Value;
                var result = await Store.Search(Division, search, Level, limit);
                LV_Search.BeginUpdate();
                LV_Search.Items.Clear();
                LV_Search.Items.AddRange(AddressLVI.FromList(result, false));
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
                var address = (FIASRegistryAddress)(AddressLVI)LV_Search.SelectedItems[0];
                UC_Object.SetObject(address, Division);
            }
            else
            {
                UC_Object.ClearObject();
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