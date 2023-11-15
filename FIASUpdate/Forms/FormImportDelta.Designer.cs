namespace FIASUpdate.Forms
{
    partial class FormImportDelta
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
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_Progress = new FIASUpdate.Controls.ToolStripTaskProgress();
            this.LV_Archives = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.сolumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.B_Download = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Import = new System.Windows.Forms.Button();
            this.FLP_Action = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Open = new System.Windows.Forms.Button();
            this.Info = new FIASUpdate.Controls.UC_DatabaseInfo();
            this.statusStrip1.SuspendLayout();
            this.FLP_Action.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(362, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "OwO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(562, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TS_Progress
            // 
            this.TS_Progress.Name = "TS_Progress";
            this.TS_Progress.Size = new System.Drawing.Size(62, 17);
            this.TS_Progress.Status = "-";
            this.TS_Progress.Text = "Статус: - -";
            this.TS_Progress.Value = "-";
            // 
            // LV_Archives
            // 
            this.LV_Archives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.сolumnHeader4});
            this.LV_Archives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Archives.FullRowSelect = true;
            this.LV_Archives.GridLines = true;
            this.LV_Archives.HideSelection = false;
            this.LV_Archives.Location = new System.Drawing.Point(3, 18);
            this.LV_Archives.MultiSelect = false;
            this.LV_Archives.Name = "LV_Archives";
            this.LV_Archives.Size = new System.Drawing.Size(556, 344);
            this.LV_Archives.TabIndex = 17;
            this.LV_Archives.UseCompatibleStateImageBehavior = false;
            this.LV_Archives.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Версия";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Описание";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Статус";
            this.columnHeader3.Width = 128;
            // 
            // сolumnHeader4
            // 
            this.сolumnHeader4.Text = "Размер";
            this.сolumnHeader4.Width = 76;
            // 
            // B_Download
            // 
            this.B_Download.AutoSize = true;
            this.B_Download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Download.Enabled = false;
            this.B_Download.Image = global::FIASUpdate.icons8.Save16;
            this.B_Download.Location = new System.Drawing.Point(3, 3);
            this.B_Download.Name = "B_Download";
            this.B_Download.Padding = new System.Windows.Forms.Padding(1);
            this.B_Download.Size = new System.Drawing.Size(120, 25);
            this.B_Download.TabIndex = 19;
            this.B_Download.Text = "Скачать архивы";
            this.B_Download.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Download.UseVisualStyleBackColor = true;
            this.B_Download.Click += new System.EventHandler(this.B_Download_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.AutoSize = true;
            this.B_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Cancel.Enabled = false;
            this.B_Cancel.Image = global::FIASUpdate.icons8.Cancel16;
            this.B_Cancel.Location = new System.Drawing.Point(256, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Padding = new System.Windows.Forms.Padding(1);
            this.B_Cancel.Size = new System.Drawing.Size(76, 25);
            this.B_Cancel.TabIndex = 20;
            this.B_Cancel.Text = "Отмена";
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Import
            // 
            this.B_Import.AutoSize = true;
            this.B_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Import.Enabled = false;
            this.B_Import.Image = global::FIASUpdate.icons8.Replace16;
            this.B_Import.Location = new System.Drawing.Point(129, 3);
            this.B_Import.Name = "B_Import";
            this.B_Import.Padding = new System.Windows.Forms.Padding(1);
            this.B_Import.Size = new System.Drawing.Size(121, 25);
            this.B_Import.TabIndex = 19;
            this.B_Import.Text = "Импортировать";
            this.B_Import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // FLP_Action
            // 
            this.FLP_Action.AutoSize = true;
            this.FLP_Action.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_Action.Controls.Add(this.B_Download);
            this.FLP_Action.Controls.Add(this.B_Import);
            this.FLP_Action.Controls.Add(this.B_Cancel);
            this.FLP_Action.Location = new System.Drawing.Point(224, 3);
            this.FLP_Action.Name = "FLP_Action";
            this.FLP_Action.Size = new System.Drawing.Size(335, 31);
            this.FLP_Action.TabIndex = 21;
            this.FLP_Action.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LV_Archives);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 365);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список архивов";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.FLP_Action, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_Open, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 421);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(562, 37);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // B_Open
            // 
            this.B_Open.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Open.AutoSize = true;
            this.B_Open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Open.Location = new System.Drawing.Point(3, 6);
            this.B_Open.Name = "B_Open";
            this.B_Open.Padding = new System.Windows.Forms.Padding(1);
            this.B_Open.Size = new System.Drawing.Size(99, 25);
            this.B_Open.TabIndex = 20;
            this.B_Open.Text = "Открыть папку";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(562, 56);
            this.Info.Subjects = null;
            this.Info.TabIndex = 18;
            this.Info.Version = new System.DateTime(((long)(0)));
            // 
            // FormImportDelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(562, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.Name = "FormImportDelta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт БД";
            this.Load += new System.EventHandler(this.FormImportDelta_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.FLP_Action.ResumeLayout(false);
            this.FLP_Action.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView LV_Archives;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button B_Download;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.FlowLayoutPanel FLP_Action;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ColumnHeader сolumnHeader4;
        private Controls.ToolStripTaskProgress TS_Progress;
        private System.Windows.Forms.Button B_Open;
        private Controls.UC_DatabaseInfo Info;
    }
}