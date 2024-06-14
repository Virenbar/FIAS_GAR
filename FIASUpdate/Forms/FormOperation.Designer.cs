namespace FIASUpdate.Forms
{
    partial class FormOperation
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_Progress = new FIASUpdate.Controls.ToolStripTaskProgress();
            this.TS_Stopwatch = new JANL.Controls.ToolStripStopwatch();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FLP_Action = new System.Windows.Forms.FlowLayoutPanel();
            this.B_Run = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.RB_mun_adm = new System.Windows.Forms.RadioButton();
            this.RB_mun = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_Update = new System.Windows.Forms.CheckBox();
            this.RB_adm = new System.Windows.Forms.RadioButton();
            this.CB_Shrink = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.FLP_Action.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Progress,
            this.TS_Stopwatch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 120);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TS_Progress
            // 
            this.TS_Progress.Name = "TS_Progress";
            this.TS_Progress.Size = new System.Drawing.Size(271, 17);
            this.TS_Progress.Spring = true;
            this.TS_Progress.Status = "-";
            this.TS_Progress.Text = "Статус: - -";
            this.TS_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TS_Progress.Value = "-";
            // 
            // TS_Stopwatch
            // 
            this.TS_Stopwatch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TS_Stopwatch.Name = "TS_Stopwatch";
            this.TS_Stopwatch.ShowText = false;
            this.TS_Stopwatch.Size = new System.Drawing.Size(58, 20);
            this.TS_Stopwatch.Text = "Время";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.FLP_Action, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 83);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 37);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // FLP_Action
            // 
            this.FLP_Action.AutoSize = true;
            this.FLP_Action.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_Action.Controls.Add(this.B_Run);
            this.FLP_Action.Controls.Add(this.B_Cancel);
            this.FLP_Action.Location = new System.Drawing.Point(158, 3);
            this.FLP_Action.Name = "FLP_Action";
            this.FLP_Action.Size = new System.Drawing.Size(183, 31);
            this.FLP_Action.TabIndex = 21;
            this.FLP_Action.WrapContents = false;
            // 
            // B_Run
            // 
            this.B_Run.AutoSize = true;
            this.B_Run.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Run.Enabled = false;
            this.B_Run.Image = global::FIASUpdate.icons8.Replace16;
            this.B_Run.Location = new System.Drawing.Point(3, 3);
            this.B_Run.Name = "B_Run";
            this.B_Run.Padding = new System.Windows.Forms.Padding(1);
            this.B_Run.Size = new System.Drawing.Size(95, 25);
            this.B_Run.TabIndex = 19;
            this.B_Run.Text = "Выполнить";
            this.B_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Run.UseVisualStyleBackColor = true;
            this.B_Run.Click += new System.EventHandler(this.B_Run_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.AutoSize = true;
            this.B_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Cancel.Enabled = false;
            this.B_Cancel.Image = global::FIASUpdate.icons8.Cancel16;
            this.B_Cancel.Location = new System.Drawing.Point(104, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Padding = new System.Windows.Forms.Padding(1);
            this.B_Cancel.Size = new System.Drawing.Size(76, 25);
            this.B_Cancel.TabIndex = 20;
            this.B_Cancel.Text = "Отмена";
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // RB_mun_adm
            // 
            this.RB_mun_adm.AutoSize = true;
            this.RB_mun_adm.Checked = true;
            this.RB_mun_adm.Location = new System.Drawing.Point(182, 3);
            this.RB_mun_adm.Name = "RB_mun_adm";
            this.RB_mun_adm.Size = new System.Drawing.Size(74, 17);
            this.RB_mun_adm.TabIndex = 0;
            this.RB_mun_adm.TabStop = true;
            this.RB_mun_adm.Text = "mun/adm";
            this.RB_mun_adm.UseVisualStyleBackColor = true;
            // 
            // RB_mun
            // 
            this.RB_mun.AutoSize = true;
            this.RB_mun.Location = new System.Drawing.Point(128, 3);
            this.RB_mun.Name = "RB_mun";
            this.RB_mun.Size = new System.Drawing.Size(48, 17);
            this.RB_mun.TabIndex = 0;
            this.RB_mun.Text = "mun";
            this.RB_mun.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.CB_Update);
            this.flowLayoutPanel2.Controls.Add(this.RB_mun);
            this.flowLayoutPanel2.Controls.Add(this.RB_mun_adm);
            this.flowLayoutPanel2.Controls.Add(this.RB_adm);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(312, 23);
            this.flowLayoutPanel2.TabIndex = 27;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // CB_Update
            // 
            this.CB_Update.AutoSize = true;
            this.CB_Update.Location = new System.Drawing.Point(3, 3);
            this.CB_Update.Name = "CB_Update";
            this.CB_Update.Size = new System.Drawing.Size(119, 17);
            this.CB_Update.TabIndex = 26;
            this.CB_Update.Text = "Обновить реестр";
            this.CB_Update.UseVisualStyleBackColor = true;
            this.CB_Update.CheckedChanged += new System.EventHandler(this.CB_Update_CheckedChanged);
            // 
            // RB_adm
            // 
            this.RB_adm.AutoSize = true;
            this.RB_adm.Location = new System.Drawing.Point(262, 3);
            this.RB_adm.Name = "RB_adm";
            this.RB_adm.Size = new System.Drawing.Size(47, 17);
            this.RB_adm.TabIndex = 0;
            this.RB_adm.Text = "adm";
            this.RB_adm.UseVisualStyleBackColor = true;
            // 
            // CB_Shrink
            // 
            this.CB_Shrink.AutoSize = true;
            this.CB_Shrink.Location = new System.Drawing.Point(8, 31);
            this.CB_Shrink.Name = "CB_Shrink";
            this.CB_Shrink.Size = new System.Drawing.Size(76, 17);
            this.CB_Shrink.TabIndex = 26;
            this.CB_Shrink.Text = "Сжать БД";
            this.CB_Shrink.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CB_Shrink, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 56);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // FormOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(344, 142);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MinimumSize = new System.Drawing.Size(360, 180);
            this.Name = "FormOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Операции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOperation_FormClosing);
            this.Load += new System.EventHandler(this.FormOperation_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.FLP_Action.ResumeLayout(false);
            this.FLP_Action.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Controls.ToolStripTaskProgress TS_Progress;
        private JANL.Controls.ToolStripStopwatch TS_Stopwatch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel FLP_Action;
        private System.Windows.Forms.Button B_Run;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton RB_mun_adm;
        private System.Windows.Forms.RadioButton RB_mun;
        private System.Windows.Forms.RadioButton RB_adm;
        private System.Windows.Forms.CheckBox CB_Shrink;
        private System.Windows.Forms.CheckBox CB_Update;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}