namespace FIASUpdate.Forms
{
    partial class FormAddressExplorer
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
            this.TS_Navigation = new System.Windows.Forms.ToolStrip();
            this.B_Back = new System.Windows.Forms.ToolStripButton();
            this.TB_Filter = new JANL.Controls.ToolStripTextBoxLabel();
            this.TS_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Address = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.B_CopyGUID = new System.Windows.Forms.Button();
            this.TB_GUID = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.B_CopyAddress = new System.Windows.Forms.Button();
            this.LV_Search = new System.Windows.Forms.ListView();
            this.LV_GUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_FIAS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TS_Navigation.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS_Navigation
            // 
            this.TS_Navigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_Back,
            this.TB_Filter,
            this.TS_Separator});
            this.TS_Navigation.Location = new System.Drawing.Point(0, 0);
            this.TS_Navigation.Name = "TS_Navigation";
            this.TS_Navigation.Size = new System.Drawing.Size(784, 25);
            this.TS_Navigation.TabIndex = 0;
            this.TS_Navigation.Text = "toolStrip1";
            // 
            // B_Back
            // 
            this.B_Back.Image = global::FIASUpdate.icons8.Minus16;
            this.B_Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Back.Name = "B_Back";
            this.B_Back.Size = new System.Drawing.Size(36, 22);
            this.B_Back.Text = "...";
            this.B_Back.Click += new System.EventHandler(this.B_Back_Click);
            // 
            // TB_Filter
            // 
            this.TB_Filter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TB_Filter.Label = "Фильтр";
            this.TB_Filter.Name = "TB_Filter";
            this.TB_Filter.Size = new System.Drawing.Size(200, 25);
            this.TB_Filter.ToolTipText = "Esc - очистить фильтр";
            this.TB_Filter.InputDone += new System.EventHandler(this.TB_Filter_InputDone);
            // 
            // TS_Separator
            // 
            this.TS_Separator.Name = "TS_Separator";
            this.TS_Separator.Size = new System.Drawing.Size(6, 25);
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
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 404);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.Size = new System.Drawing.Size(784, 58);
            this.TableLayoutPanel2.TabIndex = 17;
            // 
            // TB_Address
            // 
            this.TB_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Address.Location = new System.Drawing.Point(47, 32);
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.ReadOnly = true;
            this.TB_Address.Size = new System.Drawing.Size(669, 22);
            this.TB_Address.TabIndex = 5;
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
            this.B_CopyGUID.Location = new System.Drawing.Point(722, 3);
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
            this.TB_GUID.Size = new System.Drawing.Size(669, 20);
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
            this.B_CopyAddress.Location = new System.Drawing.Point(722, 32);
            this.B_CopyAddress.Name = "B_CopyAddress";
            this.B_CopyAddress.Size = new System.Drawing.Size(59, 23);
            this.B_CopyAddress.TabIndex = 3;
            this.B_CopyAddress.Text = "Copy";
            this.B_CopyAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_CopyAddress.UseVisualStyleBackColor = true;
            this.B_CopyAddress.Click += new System.EventHandler(this.B_CopyAddress_Click);
            // 
            // LV_Search
            // 
            this.LV_Search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LV_GUID,
            this.LV_Name,
            this.LV_Address});
            this.LV_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Search.FullRowSelect = true;
            this.LV_Search.GridLines = true;
            this.LV_Search.HideSelection = false;
            this.LV_Search.Location = new System.Drawing.Point(0, 25);
            this.LV_Search.Name = "LV_Search";
            this.LV_Search.Size = new System.Drawing.Size(784, 379);
            this.LV_Search.TabIndex = 18;
            this.LV_Search.UseCompatibleStateImageBehavior = false;
            this.LV_Search.View = System.Windows.Forms.View.Details;
            this.LV_Search.SelectedIndexChanged += new System.EventHandler(this.LV_Search_SelectedIndexChanged);
            this.LV_Search.DoubleClick += new System.EventHandler(this.LV_Search_DoubleClick);
            // 
            // LV_GUID
            // 
            this.LV_GUID.Text = "GUID";
            this.LV_GUID.Width = 150;
            // 
            // LV_Name
            // 
            this.LV_Name.Text = "Название";
            this.LV_Name.Width = 100;
            // 
            // LV_Address
            // 
            this.LV_Address.Text = "Адрес";
            this.LV_Address.Width = 150;
            // 
            // CMS_FIAS
            // 
            this.CMS_FIAS.Name = "CMS_FIAS";
            this.CMS_FIAS.Size = new System.Drawing.Size(61, 4);
            // 
            // FormAddressExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.LV_Search);
            this.Controls.Add(this.TableLayoutPanel2);
            this.Controls.Add(this.TS_Navigation);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormAddressExplorer";
            this.Text = "FormAddressExplorer";
            this.Load += new System.EventHandler(this.FormAddressExplorer_Load);
            this.TS_Navigation.ResumeLayout(false);
            this.TS_Navigation.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TS_Navigation;
        private System.Windows.Forms.ToolStripButton B_Back;
        private JANL.Controls.ToolStripTextBoxLabel TB_Filter;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.TextBox TB_Address;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button B_CopyGUID;
        internal System.Windows.Forms.TextBox TB_GUID;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button B_CopyAddress;
        private System.Windows.Forms.ToolStripSeparator TS_Separator;
        internal System.Windows.Forms.ListView LV_Search;
        internal System.Windows.Forms.ColumnHeader LV_GUID;
        internal System.Windows.Forms.ColumnHeader LV_Address;
        private System.Windows.Forms.ContextMenuStrip CMS_FIAS;
        private System.Windows.Forms.ColumnHeader LV_Name;
    }
}