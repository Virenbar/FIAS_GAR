using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    public partial class FormAddressExplorer : Form
    {
        private readonly Stack<Crumb> Breadcrumbs = new Stack<Crumb>();
        private readonly string DBName = Settings.Default.DBName;
        private readonly FIASStore Store = new FIASStore(Settings.Default.SQLConnection);
        private List<FIASRegistryAddress> Addresses;

        public FormAddressExplorer()
        {
            InitializeComponent();
        }

        private Crumb LastCrumb => Breadcrumbs.Count == 0 ? null : Breadcrumbs.Peek();

        private async Task RefreshAddresses()
        {
            UIState(false);
            try
            {
                var crumb = LastCrumb;
                Addresses = crumb is null
                   ? await Store.GetSubject()
                   : await Store.GetChilds(crumb.GUID, Division);

                RefreshList();
                RefreshUI();
            }
            catch (Exception E) { this.ShowError(E); }
            finally { UIState(true); }
        }

        private void RefreshList()
        {
            TB_Filter.ForeColor = ForeColor;
            var list = Addresses;
            if (!string.IsNullOrWhiteSpace(TB_Filter.Text))
            {
                var split = TB_Filter.Text.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in split)
                {
                    var filtered = list
                        .Where(A => A.AddressFull.ToLower().Contains(item.ToLower()))
                        .OrderBy(A => A.Name.Length)
                        .ThenBy(A => A.Name)
                        .ToList();
                    if (filtered.Count > 0) { list = filtered; }
                }
                if (list.Equals(Addresses)) { TB_Filter.ForeColor = Color.Red; }
            }

            LV_Search.BeginUpdate();
            LV_Search.Items.Clear();
            LV_Search.Items.AddRange(AddressLVI.FromList(list));
            if (LV_Search.Items.Count > 0) { LV_Search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); }
            LV_Search.EndUpdate();
        }

        private void RefreshUI()
        {
            Text = "Справочник ФИАС";
            if (LV_Search.Items.Count > 0) { Text += $" (Объектов: {LV_Search.Items.Count:N0})"; }

            #region Обновление крошек
            foreach (var item in TS_Navigation.Items.OfType<ToolStripButton>().ToList())
            {
                TS_Navigation.Items.Remove(item);
            }
            // Текущий список
            foreach (var item in Breadcrumbs)
            {
                var B = new ToolStripButton($"{item.Name}")
                {
                    Tag = item
                };
                B.Click += async (object sender, EventArgs e) =>
                {
                    while (Breadcrumbs.Peek() != item)
                    {
                        Breadcrumbs.Pop();
                    }
                    await RefreshAddresses();
                };
                TS_Navigation.Items.Insert(0, B);
            }
            // Начальный элемент
            var B0 = new ToolStripButton("РФ");
            B0.Click += async (object sender, EventArgs e) =>
            {
                Breadcrumbs.Clear();
                await RefreshAddresses();
            };
            TS_Navigation.Items.Insert(0, B0);
            #endregion Обновление крошек
        }

        private void UIState(bool value)
        {
            TS_Navigation.Enabled = value;
        }

        #region Properties

        /// <summary>
        /// Выбранный адрес
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Деление
        /// </summary>
        public FIASDivision Division { get; set; } = FIASDivision.mun;

        /// <summary>
        /// Текст для фильтра
        /// </summary>
        public string FilterText { get; set; }

        /// <summary>
        /// Выбранный GUID
        /// </summary>
        public Guid GUID { get; private set; }

        /// <summary>
        /// Начальный GUID родителя
        /// </summary>
        public string RootGUID { get; set; }

        #endregion Properties

        #region UI Events

        private async void B_Back_Click(object sender, EventArgs e)
        {
            Breadcrumbs.Pop();
            await RefreshAddresses();
        }

        private async void FormAddressExplorer_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            TB_Filter.Text = FilterText;
            UIState(false);
            try
            {
                if (RootGUID.IsGUID())
                {
                    var root = Store.GetObject(RootGUID);
                    Breadcrumbs.Push(new Crumb { Name = root.Name, GUID = root.ObjectGUID });
                }

                await RefreshAddresses();
                UIState(true);
            }
            catch (Exception E)
            {
                this.ShowError($"Не удалось подключиться к базе {DBName}: {E.Message}");
            }

        }

        private async void LV_Search_DoubleClick(object sender, EventArgs e)
        {
            if (LV_Search.SelectedItems.Count > 0)
            {
                var address = (FIASRegistryAddress)(AddressLVI)LV_Search.SelectedItems[0];
                var next = new Crumb { Name = address.NameFull, GUID = address.ObjectGUID };
                Breadcrumbs.Push(next);
                await RefreshAddresses();
            }
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

        private void TB_Filter_InputDone(object sender, EventArgs e)
        {
            RefreshList();
        }

        #endregion UI Events

        private class Crumb
        {
            public string GUID { get; set; }
            public string Name { get; set; }
        }
    }
}