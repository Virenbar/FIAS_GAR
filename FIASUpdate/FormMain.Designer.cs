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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_Drop = new System.Windows.Forms.CheckBox();
            this.CB_DropConfirm = new System.Windows.Forms.CheckBox();
            this.L_DropWarning = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LV_Result = new System.Windows.Forms.ListView();
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Import = new System.Windows.Forms.Button();
            this.SWL = new JANL.StopWatchLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_OnlyEmpty = new System.Windows.Forms.CheckBox();
            this.CB_Shrink = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_SQLConnection = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.B_XMLPath = new System.Windows.Forms.Button();
            this.B_Search = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.Настройки.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
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
            this.Настройки.Controls.Add(this.tabPage1);
            this.Настройки.Controls.Add(this.tabPage2);
            this.Настройки.Controls.Add(this.tabPage3);
            this.Настройки.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Настройки.Location = new System.Drawing.Point(0, 0);
            this.Настройки.Name = "Настройки";
            this.Настройки.SelectedIndex = 0;
            this.Настройки.Size = new System.Drawing.Size(537, 556);
            this.Настройки.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создание таблиц";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            this.groupBox3.Visible = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(517, 79);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.CB_Drop);
            this.flowLayoutPanel2.Controls.Add(this.CB_DropConfirm);
            this.flowLayoutPanel2.Controls.Add(this.L_DropWarning);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(492, 23);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // CB_Drop
            // 
            this.CB_Drop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Drop.AutoSize = true;
            this.CB_Drop.Location = new System.Drawing.Point(3, 3);
            this.CB_Drop.Name = "CB_Drop";
            this.CB_Drop.Size = new System.Drawing.Size(117, 17);
            this.CB_Drop.TabIndex = 0;
            this.CB_Drop.Text = "Создать таблицы";
            this.CB_Drop.UseVisualStyleBackColor = true;
            // 
            // CB_DropConfirm
            // 
            this.CB_DropConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_DropConfirm.AutoSize = true;
            this.CB_DropConfirm.Location = new System.Drawing.Point(126, 3);
            this.CB_DropConfirm.Name = "CB_DropConfirm";
            this.CB_DropConfirm.Size = new System.Drawing.Size(192, 17);
            this.CB_DropConfirm.TabIndex = 2;
            this.CB_DropConfirm.Text = "Старые таблицы будут удалены";
            this.CB_DropConfirm.UseVisualStyleBackColor = true;
            this.CB_DropConfirm.Visible = false;
            // 
            // L_DropWarning
            // 
            this.L_DropWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.L_DropWarning.AutoSize = true;
            this.L_DropWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_DropWarning.ForeColor = System.Drawing.Color.Red;
            this.L_DropWarning.Location = new System.Drawing.Point(324, 5);
            this.L_DropWarning.Name = "L_DropWarning";
            this.L_DropWarning.Size = new System.Drawing.Size(165, 13);
            this.L_DropWarning.TabIndex = 1;
            this.L_DropWarning.Text = "Таблицы будут пересозданы";
            this.L_DropWarning.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 530);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Импорт данных";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LV_Result);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 422);
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
            this.LV_Result.Size = new System.Drawing.Size(517, 401);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 492);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.B_Search);
            this.tabPage3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(529, 530);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_SQLConnection, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.B_XMLPath, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(523, 62);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "SQLCS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(438, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = global::FIASUpdate.Properties.Settings.Default.SQLCS;
            // 
            // B_SQLConnection
            // 
            this.B_SQLConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_SQLConnection.AutoSize = true;
            this.B_SQLConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_SQLConnection.Location = new System.Drawing.Point(447, 3);
            this.B_SQLConnection.Name = "B_SQLConnection";
            this.B_SQLConnection.Padding = new System.Windows.Forms.Padding(1);
            this.B_SQLConnection.Size = new System.Drawing.Size(73, 25);
            this.B_SQLConnection.TabIndex = 0;
            this.B_SQLConnection.Text = "SQL Server";
            this.B_SQLConnection.UseVisualStyleBackColor = true;
            this.B_SQLConnection.Click += new System.EventHandler(this.B_SQLConnection_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "XMLPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(3, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(438, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::FIASUpdate.Properties.Settings.Default.XMLPath;
            // 
            // B_XMLPath
            // 
            this.B_XMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_XMLPath.AutoSize = true;
            this.B_XMLPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_XMLPath.Location = new System.Drawing.Point(447, 34);
            this.B_XMLPath.Name = "B_XMLPath";
            this.B_XMLPath.Padding = new System.Windows.Forms.Padding(1);
            this.B_XMLPath.Size = new System.Drawing.Size(73, 25);
            this.B_XMLPath.TabIndex = 0;
            this.B_XMLPath.Text = "XML Path";
            this.B_XMLPath.UseVisualStyleBackColor = true;
            this.B_XMLPath.Click += new System.EventHandler(this.B_XMLPath_Click);
            // 
            // B_Search
            // 
            this.B_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Search.AutoSize = true;
            this.B_Search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Search.Location = new System.Drawing.Point(432, 499);
            this.B_Search.Name = "B_Search";
            this.B_Search.Padding = new System.Windows.Forms.Padding(1);
            this.B_Search.Size = new System.Drawing.Size(91, 25);
            this.B_Search.TabIndex = 3;
            this.B_Search.Text = "Поиск адреса";
            this.B_Search.UseVisualStyleBackColor = true;
            this.B_Search.Click += new System.EventHandler(this.B_Search_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(537, 578);
            this.Controls.Add(this.Настройки);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 500);
            this.Name = "FormMain";
            this.Text = "FIAS Update";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Настройки.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel SL_Status;
		private System.Windows.Forms.ToolStripStatusLabel SL_Value;
        private System.Windows.Forms.TabControl Настройки;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox CB_Drop;
        private System.Windows.Forms.CheckBox CB_DropConfirm;
        private System.Windows.Forms.Label L_DropWarning;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LV_Result;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Import;
        private JANL.StopWatchLabel SWL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox CB_OnlyEmpty;
        private System.Windows.Forms.CheckBox CB_Shrink;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button B_SQLConnection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_XMLPath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button B_Search;
    }
}

