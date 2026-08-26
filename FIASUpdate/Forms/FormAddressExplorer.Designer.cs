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
            this.LV_Search = new System.Windows.Forms.ListView();
            this.LV_GUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_FIAS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UC_Object = new FIASUpdate.Controls.UC_FIASObject();
            this.TS_Navigation.SuspendLayout();
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
            this.LV_Search.Size = new System.Drawing.Size(784, 375);
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
            // UC_Object
            // 
            this.UC_Object.AutoSize = true;
            this.UC_Object.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UC_Object.Location = new System.Drawing.Point(0, 400);
            this.UC_Object.Name = "UC_Object";
            this.UC_Object.Size = new System.Drawing.Size(784, 62);
            this.UC_Object.TabIndex = 19;
            // 
            // FormAddressExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.LV_Search);
            this.Controls.Add(this.UC_Object);
            this.Controls.Add(this.TS_Navigation);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormAddressExplorer";
            this.Text = "FormAddressExplorer";
            this.Load += new System.EventHandler(this.FormAddressExplorer_Load);
            this.TS_Navigation.ResumeLayout(false);
            this.TS_Navigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TS_Navigation;
        private System.Windows.Forms.ToolStripButton B_Back;
        private JANL.Controls.ToolStripTextBoxLabel TB_Filter;
        private System.Windows.Forms.ToolStripSeparator TS_Separator;
        internal System.Windows.Forms.ListView LV_Search;
        internal System.Windows.Forms.ColumnHeader LV_GUID;
        internal System.Windows.Forms.ColumnHeader LV_Address;
        private System.Windows.Forms.ContextMenuStrip CMS_FIAS;
        private System.Windows.Forms.ColumnHeader LV_Name;
        private Controls.UC_FIASObject UC_Object;
    }
}