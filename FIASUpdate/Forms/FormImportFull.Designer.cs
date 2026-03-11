namespace FIASUpdate.Forms
{
    partial class FormImportFull
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Honk",
            "Honk"}, -1);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LV_Result = new System.Windows.Forms.ListView();
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Open = new System.Windows.Forms.Button();
            this.FLP_Action = new System.Windows.Forms.FlowLayoutPanel();
            this.B_Import = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CB_OnlyEmpty = new System.Windows.Forms.CheckBox();
            this.B_Select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Archive = new FIASUpdate.Controls.TextBoxFileDrop();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Version = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.TS_Progress = new FIASUpdate.Controls.ToolStripTaskProgress();
            this.TS_Stopwatch = new JANL.Controls.ToolStripStopwatch();
            this.Info = new FIASUpdate.Controls.UC_DatabaseInfo();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.FLP_Action.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LV_Result);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 353);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результат";
            // 
            // LV_Result
            // 
            this.LV_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Table,
            this.Result});
            this.LV_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Result.GridLines = true;
            this.LV_Result.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_Result.HideSelection = false;
            this.LV_Result.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.LV_Result.Location = new System.Drawing.Point(3, 18);
            this.LV_Result.Name = "LV_Result";
            this.LV_Result.Size = new System.Drawing.Size(478, 332);
            this.LV_Result.TabIndex = 10;
            this.LV_Result.UseCompatibleStateImageBehavior = false;
            this.LV_Result.View = System.Windows.Forms.View.Details;
            // 
            // Table
            // 
            this.Table.Text = "Таблица";
            this.Table.Width = 65;
            // 
            // Result
            // 
            this.Result.Text = "Статус";
            this.Result.Width = 62;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.B_Open, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FLP_Action, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 509);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 31);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // B_Open
            // 
            this.B_Open.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Open.AutoSize = true;
            this.B_Open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Open.Image = global::FIASUpdate.icons8.OpenedFolder16;
            this.B_Open.Location = new System.Drawing.Point(3, 3);
            this.B_Open.Name = "B_Open";
            this.B_Open.Padding = new System.Windows.Forms.Padding(1);
            this.B_Open.Size = new System.Drawing.Size(115, 25);
            this.B_Open.TabIndex = 0;
            this.B_Open.Text = "Открыть папку";
            this.B_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // FLP_Action
            // 
            this.FLP_Action.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FLP_Action.AutoSize = true;
            this.FLP_Action.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_Action.Controls.Add(this.B_Import);
            this.FLP_Action.Controls.Add(this.B_Cancel);
            this.FLP_Action.Location = new System.Drawing.Point(275, 0);
            this.FLP_Action.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_Action.Name = "FLP_Action";
            this.FLP_Action.Size = new System.Drawing.Size(209, 31);
            this.FLP_Action.TabIndex = 11;
            this.FLP_Action.WrapContents = false;
            // 
            // B_Import
            // 
            this.B_Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.B_Import.AutoSize = true;
            this.B_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Import.Image = global::FIASUpdate.icons8.Replace16;
            this.B_Import.Location = new System.Drawing.Point(3, 3);
            this.B_Import.Name = "B_Import";
            this.B_Import.Padding = new System.Windows.Forms.Padding(1);
            this.B_Import.Size = new System.Drawing.Size(121, 25);
            this.B_Import.TabIndex = 0;
            this.B_Import.Text = "Импортировать";
            this.B_Import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.AutoSize = true;
            this.B_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Cancel.Enabled = false;
            this.B_Cancel.Image = global::FIASUpdate.icons8.Cancel16;
            this.B_Cancel.Location = new System.Drawing.Point(130, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Padding = new System.Windows.Forms.Padding(1);
            this.B_Cancel.Size = new System.Drawing.Size(76, 25);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Отмена";
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры импорта";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.CB_OnlyEmpty, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.B_Select, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TB_Archive, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TB_Version, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(478, 79);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // CB_OnlyEmpty
            // 
            this.CB_OnlyEmpty.AutoSize = true;
            this.CB_OnlyEmpty.Checked = true;
            this.CB_OnlyEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_OnlyEmpty.Location = new System.Drawing.Point(54, 59);
            this.CB_OnlyEmpty.Name = "CB_OnlyEmpty";
            this.CB_OnlyEmpty.Size = new System.Drawing.Size(249, 17);
            this.CB_OnlyEmpty.TabIndex = 2;
            this.CB_OnlyEmpty.Text = "Импортировать только в пустые таблицы";
            this.CB_OnlyEmpty.UseVisualStyleBackColor = true;
            // 
            // B_Select
            // 
            this.B_Select.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Select.AutoSize = true;
            this.B_Select.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Select.Image = global::FIASUpdate.icons8.OpenedFolder16;
            this.B_Select.Location = new System.Drawing.Point(397, 1);
            this.B_Select.Margin = new System.Windows.Forms.Padding(0);
            this.B_Select.Name = "B_Select";
            this.B_Select.Padding = new System.Windows.Forms.Padding(1);
            this.B_Select.Size = new System.Drawing.Size(81, 25);
            this.B_Select.TabIndex = 6;
            this.B_Select.Text = "Выбрать";
            this.B_Select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Select.UseVisualStyleBackColor = true;
            this.B_Select.Click += new System.EventHandler(this.B_Select_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Архив";
            // 
            // TB_Archive
            // 
            this.TB_Archive.AllowDrop = true;
            this.TB_Archive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Archive.Location = new System.Drawing.Point(54, 3);
            this.TB_Archive.Name = "TB_Archive";
            this.TB_Archive.Size = new System.Drawing.Size(340, 22);
            this.TB_Archive.TabIndex = 3;
            this.TB_Archive.TextChanged += new System.EventHandler(this.TB_Archive_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Версия";
            // 
            // TB_Version
            // 
            this.TB_Version.Location = new System.Drawing.Point(54, 31);
            this.TB_Version.Name = "TB_Version";
            this.TB_Version.ReadOnly = true;
            this.TB_Version.Size = new System.Drawing.Size(100, 22);
            this.TB_Version.TabIndex = 6;
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Progress,
            this.TS_Stopwatch});
            this.Status.Location = new System.Drawing.Point(0, 540);
            this.Status.Name = "Status";
            this.Status.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Status.Size = new System.Drawing.Size(484, 22);
            this.Status.TabIndex = 15;
            this.Status.Text = "statusStrip1";
            // 
            // TS_Progress
            // 
            this.TS_Progress.Name = "TS_Progress";
            this.TS_Progress.Size = new System.Drawing.Size(411, 17);
            this.TS_Progress.Spring = true;
            this.TS_Progress.Status = "-";
            this.TS_Progress.Text = "Статус: - -";
            this.TS_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TS_Progress.Value = "-";
            // 
            // TS_Stopwatch
            // 
            this.TS_Stopwatch.Name = "TS_Stopwatch";
            this.TS_Stopwatch.ShowText = false;
            this.TS_Stopwatch.Size = new System.Drawing.Size(58, 20);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(484, 56);
            this.Info.Subjects = null;
            this.Info.TabIndex = 19;
            this.Info.Version = new System.DateTime(((long)(0)));
            // 
            // FormImportFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Status);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "FormImportFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт БД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormImportFull_FormClosing);
            this.Load += new System.EventHandler(this.FormImportFull_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.FLP_Action.ResumeLayout(false);
            this.FLP_Action.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LV_Result;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CB_OnlyEmpty;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.FlowLayoutPanel FLP_Action;
        private System.Windows.Forms.Button B_Cancel;
        private Controls.ToolStripTaskProgress TS_Progress;
        private JANL.Controls.ToolStripStopwatch TS_Stopwatch;
        private System.Windows.Forms.Button B_Open;
        private Controls.UC_DatabaseInfo Info;
        private Controls.TextBoxFileDrop TB_Archive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button B_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Version;
    }
}