﻿namespace FIASUpdate.Forms
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.B_Import = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_OnlyEmpty = new System.Windows.Forms.CheckBox();
            this.CB_Shrink = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_Progress = new FIASUpdate.Controls.ToolStripTaskProgress();
            this.TS_Stopwatch = new JANL.Controls.ToolStripStopwatch();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LV_Result);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 468);
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
            this.LV_Result.Size = new System.Drawing.Size(476, 447);
            this.LV_Result.TabIndex = 10;
            this.LV_Result.UseCompatibleStateImageBehavior = false;
            this.LV_Result.View = System.Windows.Forms.View.Details;
            // 
            // Table
            // 
            this.Table.Text = "Таблица";
            this.Table.Width = 38;
            // 
            // Result
            // 
            this.Result.Text = "Статус";
            this.Result.Width = 40;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.B_Open, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 535);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 37);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // B_Open
            // 
            this.B_Open.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Open.AutoSize = true;
            this.B_Open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Open.Image = global::FIASUpdate.icons8.OpenedFolder16;
            this.B_Open.Location = new System.Drawing.Point(3, 6);
            this.B_Open.Name = "B_Open";
            this.B_Open.Padding = new System.Windows.Forms.Padding(1);
            this.B_Open.Size = new System.Drawing.Size(115, 25);
            this.B_Open.TabIndex = 0;
            this.B_Open.Text = "Открыть папку";
            this.B_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.B_Import);
            this.flowLayoutPanel2.Controls.Add(this.B_Cancel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(286, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(193, 31);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // B_Import
            // 
            this.B_Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.B_Import.AutoSize = true;
            this.B_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Import.Location = new System.Drawing.Point(3, 3);
            this.B_Import.Name = "B_Import";
            this.B_Import.Padding = new System.Windows.Forms.Padding(1);
            this.B_Import.Size = new System.Drawing.Size(105, 25);
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
            this.B_Cancel.Location = new System.Drawing.Point(114, 3);
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
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры импорта";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.CB_OnlyEmpty);
            this.flowLayoutPanel1.Controls.Add(this.CB_Shrink);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 46);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // CB_OnlyEmpty
            // 
            this.CB_OnlyEmpty.AutoSize = true;
            this.CB_OnlyEmpty.Checked = true;
            this.CB_OnlyEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_OnlyEmpty.Location = new System.Drawing.Point(3, 3);
            this.CB_OnlyEmpty.Name = "CB_OnlyEmpty";
            this.CB_OnlyEmpty.Size = new System.Drawing.Size(249, 17);
            this.CB_OnlyEmpty.TabIndex = 2;
            this.CB_OnlyEmpty.Text = "Импортировать только в пустые таблицы";
            this.CB_OnlyEmpty.UseVisualStyleBackColor = true;
            // 
            // CB_Shrink
            // 
            this.CB_Shrink.AutoSize = true;
            this.CB_Shrink.Checked = true;
            this.CB_Shrink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Shrink.Location = new System.Drawing.Point(3, 26);
            this.CB_Shrink.Name = "CB_Shrink";
            this.CB_Shrink.Size = new System.Drawing.Size(160, 17);
            this.CB_Shrink.TabIndex = 3;
            this.CB_Shrink.Text = "Сжать БД после импорта";
            this.CB_Shrink.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Progress,
            this.TS_Stopwatch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(482, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TS_Progress
            // 
            this.TS_Progress.Name = "TS_Progress";
            this.TS_Progress.Size = new System.Drawing.Size(409, 17);
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
            // FormImportFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(482, 594);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.Name = "FormImportFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт БД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormImportFull_FormClosing);
            this.Load += new System.EventHandler(this.FormImportFull_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox CB_OnlyEmpty;
        private System.Windows.Forms.CheckBox CB_Shrink;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button B_Cancel;
        private Controls.ToolStripTaskProgress TS_Progress;
        private JANL.Controls.ToolStripStopwatch TS_Stopwatch;
        private System.Windows.Forms.Button B_Open;
    }
}