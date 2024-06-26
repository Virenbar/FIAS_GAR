﻿namespace FIASUpdate.Forms
{
    partial class FormAddressSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.NUD_Limit = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.RB_ADM = new System.Windows.Forms.RadioButton();
            this.RB_MUN = new System.Windows.Forms.RadioButton();
            this.L_GUID = new System.Windows.Forms.Label();
            this.TB_Address = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_Level = new System.Windows.Forms.ComboBox();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Search = new System.Windows.Forms.Button();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Label3 = new System.Windows.Forms.Label();
            this.B_CopyGUID = new System.Windows.Forms.Button();
            this.TB_GUID = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.B_CopyAddress = new System.Windows.Forms.Button();
            this.LV_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_GUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Search = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_DBInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_PDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_URL = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Limit)).BeginInit();
            this.FlowLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Search
            // 
            this.TB_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Search.Location = new System.Drawing.Point(9, 10);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(708, 22);
            this.TB_Search.TabIndex = 0;
            this.FormToolTip.SetToolTip(this.TB_Search, "Enter - Выполнить поиск\r\nEsc - Очистить поле");
            this.TB_Search.TextChanged += new System.EventHandler(this.TB_Search_TextChanged);
            this.TB_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Search_KeyDown);
            // 
            // NUD_Limit
            // 
            this.NUD_Limit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowLayoutPanel1.SetFlowBreak(this.NUD_Limit, true);
            this.NUD_Limit.Location = new System.Drawing.Point(339, 3);
            this.NUD_Limit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_Limit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Limit.Name = "NUD_Limit";
            this.NUD_Limit.Size = new System.Drawing.Size(72, 22);
            this.NUD_Limit.TabIndex = 7;
            this.NUD_Limit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 33);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Деление";
            // 
            // RB_ADM
            // 
            this.RB_ADM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_ADM.AutoSize = true;
            this.RB_ADM.Location = new System.Drawing.Point(181, 31);
            this.RB_ADM.Name = "RB_ADM";
            this.RB_ADM.Size = new System.Drawing.Size(128, 17);
            this.RB_ADM.TabIndex = 12;
            this.RB_ADM.Text = "Административное";
            this.RB_ADM.UseVisualStyleBackColor = true;
            this.RB_ADM.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // RB_MUN
            // 
            this.RB_MUN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_MUN.AutoSize = true;
            this.RB_MUN.Checked = true;
            this.RB_MUN.Location = new System.Drawing.Point(62, 31);
            this.RB_MUN.Name = "RB_MUN";
            this.RB_MUN.Size = new System.Drawing.Size(113, 17);
            this.RB_MUN.TabIndex = 11;
            this.RB_MUN.TabStop = true;
            this.RB_MUN.Text = "Муниципальное";
            this.RB_MUN.UseVisualStyleBackColor = true;
            this.RB_MUN.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // L_GUID
            // 
            this.L_GUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.L_GUID.AutoSize = true;
            this.FlowLayoutPanel1.SetFlowBreak(this.L_GUID, true);
            this.L_GUID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_GUID.ForeColor = System.Drawing.Color.ForestGreen;
            this.L_GUID.Location = new System.Drawing.Point(315, 32);
            this.L_GUID.Name = "L_GUID";
            this.L_GUID.Size = new System.Drawing.Size(38, 15);
            this.L_GUID.TabIndex = 10;
            this.L_GUID.Text = "GUID";
            this.L_GUID.Visible = false;
            // 
            // TB_Address
            // 
            this.TB_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Address.Location = new System.Drawing.Point(47, 32);
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.ReadOnly = true;
            this.TB_Address.Size = new System.Drawing.Size(685, 22);
            this.TB_Address.TabIndex = 5;
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(3, 7);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(52, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Уровень";
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(292, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Лимит";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowLayoutPanel1.AutoSize = true;
            this.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel1.Controls.Add(this.Label4);
            this.FlowLayoutPanel1.Controls.Add(this.CB_Level);
            this.FlowLayoutPanel1.Controls.Add(this.Label1);
            this.FlowLayoutPanel1.Controls.Add(this.NUD_Limit);
            this.FlowLayoutPanel1.Controls.Add(this.Label5);
            this.FlowLayoutPanel1.Controls.Add(this.RB_MUN);
            this.FlowLayoutPanel1.Controls.Add(this.RB_ADM);
            this.FlowLayoutPanel1.Controls.Add(this.L_GUID);
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(9, 40);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(414, 51);
            this.FlowLayoutPanel1.TabIndex = 14;
            // 
            // CB_Level
            // 
            this.CB_Level.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Level.FormattingEnabled = true;
            this.CB_Level.Location = new System.Drawing.Point(61, 3);
            this.CB_Level.Name = "CB_Level";
            this.CB_Level.Size = new System.Drawing.Size(225, 21);
            this.CB_Level.TabIndex = 6;
            this.CB_Level.SelectedIndexChanged += new System.EventHandler(this.CB_Level_SelectedIndexChanged);
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.AutoSize = true;
            this.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel3.Controls.Add(this.FlowLayoutPanel1, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.TB_Search, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.B_Search, 1, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 24);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.Padding = new System.Windows.Forms.Padding(6);
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel3.Size = new System.Drawing.Size(800, 100);
            this.TableLayoutPanel3.TabIndex = 17;
            // 
            // B_Search
            // 
            this.B_Search.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Search.AutoSize = true;
            this.B_Search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Search.Image = global::FIASUpdate.icons8.Search16;
            this.B_Search.Location = new System.Drawing.Point(723, 9);
            this.B_Search.Name = "B_Search";
            this.B_Search.Padding = new System.Windows.Forms.Padding(1);
            this.B_Search.Size = new System.Drawing.Size(68, 25);
            this.B_Search.TabIndex = 3;
            this.B_Search.Text = "Поиск";
            this.B_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Search.UseVisualStyleBackColor = true;
            this.B_Search.Click += new System.EventHandler(this.B_Search_Click);
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.AutoSize = true;
            this.TableLayoutPanel2.ColumnCount = 3;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.Controls.Add(this.TB_Address, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.B_CopyGUID, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.TB_GUID, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.B_CopyAddress, 2, 1);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 392);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.Size = new System.Drawing.Size(800, 58);
            this.TableLayoutPanel2.TabIndex = 16;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 37);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Адрес";
            // 
            // B_CopyGUID
            // 
            this.B_CopyGUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_CopyGUID.AutoSize = true;
            this.B_CopyGUID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_CopyGUID.Enabled = false;
            this.B_CopyGUID.Image = global::FIASUpdate.icons8.Clipboard16;
            this.B_CopyGUID.Location = new System.Drawing.Point(738, 3);
            this.B_CopyGUID.Name = "B_CopyGUID";
            this.B_CopyGUID.Size = new System.Drawing.Size(59, 23);
            this.B_CopyGUID.TabIndex = 3;
            this.B_CopyGUID.Text = "Copy";
            this.B_CopyGUID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_CopyGUID.UseVisualStyleBackColor = true;
            this.B_CopyGUID.Click += new System.EventHandler(this.B_CopyGUID_Click);
            // 
            // TB_GUID
            // 
            this.TB_GUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GUID.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_GUID.Location = new System.Drawing.Point(47, 4);
            this.TB_GUID.Name = "TB_GUID";
            this.TB_GUID.ReadOnly = true;
            this.TB_GUID.Size = new System.Drawing.Size(685, 20);
            this.TB_GUID.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "GUID";
            // 
            // B_CopyAddress
            // 
            this.B_CopyAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_CopyAddress.AutoSize = true;
            this.B_CopyAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_CopyAddress.Enabled = false;
            this.B_CopyAddress.Image = global::FIASUpdate.icons8.Clipboard16;
            this.B_CopyAddress.Location = new System.Drawing.Point(738, 32);
            this.B_CopyAddress.Name = "B_CopyAddress";
            this.B_CopyAddress.Size = new System.Drawing.Size(59, 23);
            this.B_CopyAddress.TabIndex = 3;
            this.B_CopyAddress.Text = "Copy";
            this.B_CopyAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_CopyAddress.UseVisualStyleBackColor = true;
            this.B_CopyAddress.Click += new System.EventHandler(this.B_CopyAddress_Click);
            // 
            // LV_Address
            // 
            this.LV_Address.Text = "Адрес";
            this.LV_Address.Width = 150;
            // 
            // LV_GUID
            // 
            this.LV_GUID.Text = "GUID";
            this.LV_GUID.Width = 150;
            // 
            // LV_Search
            // 
            this.LV_Search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LV_GUID,
            this.LV_Address});
            this.LV_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Search.FullRowSelect = true;
            this.LV_Search.GridLines = true;
            this.LV_Search.HideSelection = false;
            this.LV_Search.Location = new System.Drawing.Point(0, 124);
            this.LV_Search.Name = "LV_Search";
            this.LV_Search.Size = new System.Drawing.Size(800, 268);
            this.LV_Search.TabIndex = 14;
            this.LV_Search.UseCompatibleStateImageBehavior = false;
            this.LV_Search.View = System.Windows.Forms.View.Details;
            this.LV_Search.SelectedIndexChanged += new System.EventHandler(this.LV_Search_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дополнительноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_DBInfo,
            this.MI_Parameters,
            this.MI_PDF,
            this.MI_URL});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.дополнительноToolStripMenuItem.Text = "Сервис";
            // 
            // MI_DBInfo
            // 
            this.MI_DBInfo.Image = global::FIASUpdate.icons8.Info16;
            this.MI_DBInfo.Name = "MI_DBInfo";
            this.MI_DBInfo.Size = new System.Drawing.Size(189, 22);
            this.MI_DBInfo.Text = "Статистика БД";
            this.MI_DBInfo.Click += new System.EventHandler(this.MI_DBInfo_Click);
            // 
            // MI_PDF
            // 
            this.MI_PDF.Enabled = false;
            this.MI_PDF.Image = global::FIASUpdate.icons8.PDF16;
            this.MI_PDF.Name = "MI_PDF";
            this.MI_PDF.Size = new System.Drawing.Size(189, 22);
            this.MI_PDF.Text = "Скачать выписку";
            this.MI_PDF.Click += new System.EventHandler(this.MI_PDF_Click);
            // 
            // MI_Parameters
            // 
            this.MI_Parameters.Enabled = false;
            this.MI_Parameters.Image = global::FIASUpdate.icons8.TableProperties16;
            this.MI_Parameters.Name = "MI_Parameters";
            this.MI_Parameters.Size = new System.Drawing.Size(189, 22);
            this.MI_Parameters.Text = "Показать параметры";
            this.MI_Parameters.Click += new System.EventHandler(this.MI_Parameters_Click);
            // 
            // MI_URL
            // 
            this.MI_URL.Enabled = false;
            this.MI_URL.Image = global::FIASUpdate.icons8.Internet16;
            this.MI_URL.Name = "MI_URL";
            this.MI_URL.Size = new System.Drawing.Size(189, 22);
            this.MI_URL.Text = "Открыть на сайте";
            this.MI_URL.Click += new System.EventHandler(this.MI_URL_Click);
            // 
            // FormAddressSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LV_Search);
            this.Controls.Add(this.TableLayoutPanel3);
            this.Controls.Add(this.TableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAddressSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAddressSearch";
            this.Load += new System.EventHandler(this.FormAddressSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Limit)).EndInit();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolTip FormToolTip;
        internal System.Windows.Forms.TextBox TB_Search;
        internal System.Windows.Forms.NumericUpDown NUD_Limit;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox CB_Level;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.RadioButton RB_ADM;
        internal System.Windows.Forms.RadioButton RB_MUN;
        internal System.Windows.Forms.Label L_GUID;
        internal System.Windows.Forms.TextBox TB_Address;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.Button B_Search;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button B_CopyGUID;
        internal System.Windows.Forms.TextBox TB_GUID;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button B_CopyAddress;
        internal System.Windows.Forms.ColumnHeader LV_Address;
        internal System.Windows.Forms.ColumnHeader LV_GUID;
        internal System.Windows.Forms.ListView LV_Search;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_DBInfo;
        private System.Windows.Forms.ToolStripMenuItem MI_PDF;
        private System.Windows.Forms.ToolStripMenuItem MI_Parameters;
        private System.Windows.Forms.ToolStripMenuItem MI_URL;
    }
}