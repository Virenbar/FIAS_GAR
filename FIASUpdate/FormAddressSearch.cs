using FIASUpdate.Enums;
using FIASUpdate.Stores;
using JANL;
using JANL.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate
{
    public partial class FormAddressSearch : Form
    {
        private readonly string DBName = FIASManager.DBName;
        private readonly List<(RadioButton RB, FIASDivision Division)> RB_F;
        private readonly FIASStore Store = new FIASStore();

        public FormAddressSearch()
        {
            InitializeComponent();
            Level = 10;
            RB_F = new List<(RadioButton RB, FIASDivision Division)> { (RB_ADM, FIASDivision.adm), (RB_MUN, FIASDivision.mun) };
        }

        private void RefreshUI()
        {
            Text = "Справочник ФИАС";
            if (LV_Search.Items.Count > 0) { Text += $" (Объектов: {LV_Search.Items.Count:N0})"; }
        }

        private async Task Search()
        {
            if (TB_Search.Text.Length < 2) { return; }
            SetUIState(false);
            try
            {
                var D = RB_F.First(R => R.RB.Checked).Division;
                var S = TB_Search.Text.TrimSpaces();
                var Limit = (int)NUD_Limit.Value;
                var Result = await Store.Search(D, S, Level, Limit);
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
            catch (Exception E) { Msgs.ShowError(E); }
            finally { SetUIState(true); }
        }

        private void SetUIState(bool value)
        {
            TB_Search.ReadOnly = !value;
            B_Search.Enabled = value;
            CB_Level.Enabled = value;
            B_Info.Enabled = value;
            RB_ADM.Enabled = value;
            RB_MUN.Enabled = value;
        }

        #region Properties

        public int Level { get; private set; }

        #endregion Properties

        #region UI Events

        private void B_CopyAddress_Click(object sender, EventArgs e)
        {
            if (TB_Address.Text.Length > 0) { Clipboard.SetText(TB_Address.Text); }
        }

        private void B_CopyGUID_Click(object sender, EventArgs e)
        {
            if (TB_GUID.Text.Length > 0) { Clipboard.SetText(TB_GUID.Text); }
        }

        private async void B_Info_Click(object sender, EventArgs e)
        {
            SetUIState(false);
            try
            {
                var D = await Store.Statistics();
                var S = string.Join(Environment.NewLine, D.Select(KV => $"{KV.Key}: {KV.Value}"));
                Msgs.ShowInfo(S, "Информация о БД");
            }
            catch (Exception E) { Msgs.ShowError(E.Message); }
            finally { SetUIState(true); }
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
            CB_Level.SelectedIndexChanged -= CB_Level_SelectedIndexChanged;
            SetUIState(false);
            try
            {
                using (var C = await SQLHelper.NewConnectionAsync())
                {
                    CB_Level.DataSource = await FIASStore.UP_CB_Levels().ExecuteAsync(C);
                }
                CB_Level.DisplayMember = "Name";
                CB_Level.ValueMember = "Level";
                CB_Level.SelectedValue = Level;
                CB_Level.SelectedIndexChanged += CB_Level_SelectedIndexChanged;
                SetUIState(true);
            }
            catch (Exception E) { Msgs.ShowError($"Не удалось подключиться к базе {DBName}: {E.Message}"); }
            RefreshUI();
            await Search();
        }

        private void LV_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Search.SelectedItems.Count == 0)
            {
                TB_GUID.Text = string.Empty;
                TB_Address.Text = string.Empty;
                return;
            }
            var A = LV_Search.SelectedItems[0];
            TB_GUID.Text = A.SubItems[0].Text;
            TB_Address.Text = A.SubItems[1].Text;
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

        private void TB_Search_TextChanged(object sender, EventArgs e) => L_GUID.Visible = Store.IsGUID(TB_Search.Text);

        #endregion UI Events
    }
}