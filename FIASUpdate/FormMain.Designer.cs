namespace FIASUpdate
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Honk",
            "Honk"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SL_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SL_Value = new System.Windows.Forms.ToolStripStatusLabel();
            this.Настройки = new System.Windows.Forms.TabControl();
            this.TP_Import = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LV_Result = new System.Windows.Forms.ListView();
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Import = new System.Windows.Forms.Button();
            this.SWL = new JANL.UserControls.StopWatchLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_OnlyEmpty = new System.Windows.Forms.CheckBox();
            this.CB_Shrink = new System.Windows.Forms.CheckBox();
            this.TP_Settings = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.uC_Database1 = new FIASUpdate.Controls.UC_Database();
            this.statusStrip1.SuspendLayout();
            this.Настройки.SuspendLayout();
            this.TP_Import.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.TP_Settings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SL_Status,
            this.SL_Value});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(537, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Status: ";
            // 
            // SL_Status
            // 
            this.SL_Status.Name = "SL_Status";
            this.SL_Status.Size = new System.Drawing.Size(12, 17);
            this.SL_Status.Text = "-";
            // 
            // SL_Value
            // 
            this.SL_Value.Name = "SL_Value";
            this.SL_Value.Size = new System.Drawing.Size(12, 17);
            this.SL_Value.Text = "-";
            // 
            // Настройки
            // 
            this.Настройки.Controls.Add(this.TP_Import);
            this.Настройки.Controls.Add(this.TP_Settings);
            this.Настройки.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Настройки.Location = new System.Drawing.Point(0, 24);
            this.Настройки.Name = "Настройки";
            this.Настройки.SelectedIndex = 0;
            this.Настройки.Size = new System.Drawing.Size(537, 564);
            this.Настройки.TabIndex = 10;
            // 
            // TP_Import
            // 
            this.TP_Import.Controls.Add(this.groupBox2);
            this.TP_Import.Controls.Add(this.tableLayoutPanel1);
            this.TP_Import.Controls.Add(this.groupBox1);
            this.TP_Import.Location = new System.Drawing.Point(4, 22);
            this.TP_Import.Name = "TP_Import";
            this.TP_Import.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Import.Size = new System.Drawing.Size(529, 538);
            this.TP_Import.TabIndex = 1;
            this.TP_Import.Text = "Импорт данных";
            this.TP_Import.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LV_Result);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 430);
            this.groupBox2.TabIndex = 10;
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
            listViewItem2});
            this.LV_Result.Location = new System.Drawing.Point(3, 18);
            this.LV_Result.Name = "LV_Result";
            this.LV_Result.Size = new System.Drawing.Size(517, 409);
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
            this.tableLayoutPanel1.Controls.Add(this.B_Import, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SWL, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 500);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 35);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // B_Import
            // 
            this.B_Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.B_Import.AutoSize = true;
            this.B_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Import.Location = new System.Drawing.Point(411, 3);
            this.B_Import.Name = "B_Import";
            this.B_Import.Padding = new System.Windows.Forms.Padding(3);
            this.B_Import.Size = new System.Drawing.Size(109, 29);
            this.B_Import.TabIndex = 0;
            this.B_Import.Text = "Импортировать";
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // SWL
            // 
            this.SWL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SWL.ImageRunning = ((System.Drawing.Image)(resources.GetObject("SWL.ImageRunning")));
            this.SWL.ImageWaiting = ((System.Drawing.Image)(resources.GetObject("SWL.ImageWaiting")));
            this.SWL.Location = new System.Drawing.Point(3, 3);
            this.SWL.Name = "SWL";
            this.SWL.ShowImage = false;
            this.SWL.Size = new System.Drawing.Size(255, 29);
            this.SWL.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 67);
            this.groupBox1.TabIndex = 5;
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(517, 46);
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
            this.CB_Shrink.Size = new System.Drawing.Size(76, 17);
            this.CB_Shrink.TabIndex = 3;
            this.CB_Shrink.Text = "Сжать БД";
            this.CB_Shrink.UseVisualStyleBackColor = true;
            // 
            // TP_Settings
            // 
            this.TP_Settings.Controls.Add(this.uC_Database1);
            this.TP_Settings.Location = new System.Drawing.Point(4, 22);
            this.TP_Settings.Name = "TP_Settings";
            this.TP_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Settings.Size = new System.Drawing.Size(529, 538);
            this.TP_Settings.TabIndex = 2;
            this.TP_Settings.Text = "Настройки";
            this.TP_Settings.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Search});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // MI_Search
            // 
            this.MI_Search.Name = "MI_Search";
            this.MI_Search.Size = new System.Drawing.Size(176, 22);
            this.MI_Search.Text = "Поиск адреса в БД";
            this.MI_Search.Click += new System.EventHandler(this.MI_Search_Click);
            // 
            // uC_Database1
            // 
            this.uC_Database1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Database1.Location = new System.Drawing.Point(3, 3);
            this.uC_Database1.Name = "uC_Database1";
            this.uC_Database1.Size = new System.Drawing.Size(523, 532);
            this.uC_Database1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(537, 610);
            this.Controls.Add(this.Настройки);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(550, 500);
            this.Name = "FormMain";
            this.Text = "FIAS Update";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Настройки.ResumeLayout(false);
            this.TP_Import.ResumeLayout(false);
            this.TP_Import.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.TP_Settings.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel SL_Status;
		private System.Windows.Forms.ToolStripStatusLabel SL_Value;
        private System.Windows.Forms.TabControl Настройки;
        private System.Windows.Forms.TabPage TP_Import;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LV_Result;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Import;
        private JANL.UserControls.StopWatchLabel SWL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox CB_OnlyEmpty;
        private System.Windows.Forms.CheckBox CB_Shrink;
        private System.Windows.Forms.TabPage TP_Settings;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_Search;
        private Controls.UC_Database uC_Database1;
    }
}

