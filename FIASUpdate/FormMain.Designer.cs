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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Honk",
            "Honk"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.B_SQLConnection = new System.Windows.Forms.Button();
            this.B_XMLPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LV_Tables = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.B_TablesRefresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.B_TablesSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.Настройки.SuspendLayout();
            this.TP_Import.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.TP_Settings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.TP_Import.Size = new System.Drawing.Size(529, 506);
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
            this.groupBox2.Size = new System.Drawing.Size(523, 398);
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
            listViewItem1});
            this.LV_Result.Location = new System.Drawing.Point(3, 18);
            this.LV_Result.Name = "LV_Result";
            this.LV_Result.Size = new System.Drawing.Size(517, 377);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 468);
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
            this.TP_Settings.Controls.Add(this.groupBox3);
            this.TP_Settings.Controls.Add(this.tableLayoutPanel3);
            this.TP_Settings.Controls.Add(this.tableLayoutPanel2);
            this.TP_Settings.Location = new System.Drawing.Point(4, 22);
            this.TP_Settings.Name = "TP_Settings";
            this.TP_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Settings.Size = new System.Drawing.Size(529, 538);
            this.TP_Settings.TabIndex = 2;
            this.TP_Settings.Text = "Настройки";
            this.TP_Settings.UseVisualStyleBackColor = true;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LV_Tables);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 433);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Таблицы для импорта";
            // 
            // LV_Tables
            // 
            this.LV_Tables.CheckBoxes = true;
            this.LV_Tables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LV_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Tables.FullRowSelect = true;
            this.LV_Tables.GridLines = true;
            this.LV_Tables.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            this.LV_Tables.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.LV_Tables.Location = new System.Drawing.Point(3, 18);
            this.LV_Tables.MultiSelect = false;
            this.LV_Tables.Name = "LV_Tables";
            this.LV_Tables.Size = new System.Drawing.Size(517, 412);
            this.LV_Tables.TabIndex = 0;
            this.LV_Tables.UseCompatibleStateImageBehavior = false;
            this.LV_Tables.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Таблица";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Строк";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата импорта";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.B_TablesRefresh, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 498);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(523, 37);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // B_TablesRefresh
            // 
            this.B_TablesRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_TablesRefresh.AutoSize = true;
            this.B_TablesRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_TablesRefresh.Location = new System.Drawing.Point(3, 6);
            this.B_TablesRefresh.Name = "B_TablesRefresh";
            this.B_TablesRefresh.Padding = new System.Windows.Forms.Padding(1);
            this.B_TablesRefresh.Size = new System.Drawing.Size(73, 25);
            this.B_TablesRefresh.TabIndex = 2;
            this.B_TablesRefresh.Text = "Обновить";
            this.B_TablesRefresh.UseVisualStyleBackColor = true;
            this.B_TablesRefresh.Click += new System.EventHandler(this.B_TablesRefresh_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.B_TablesSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(438, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(82, 31);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // B_TablesSave
            // 
            this.B_TablesSave.AutoSize = true;
            this.B_TablesSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_TablesSave.Location = new System.Drawing.Point(3, 3);
            this.B_TablesSave.Name = "B_TablesSave";
            this.B_TablesSave.Padding = new System.Windows.Forms.Padding(1);
            this.B_TablesSave.Size = new System.Drawing.Size(76, 25);
            this.B_TablesSave.TabIndex = 2;
            this.B_TablesSave.Text = "Сохранить";
            this.B_TablesSave.UseVisualStyleBackColor = true;
            this.B_TablesSave.Click += new System.EventHandler(this.B_TablesSave_Click);
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
            this.MI_Search.Size = new System.Drawing.Size(180, 22);
            this.MI_Search.Text = "Поиск адреса в БД";
            this.MI_Search.Click += new System.EventHandler(this.MI_Search_Click);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(537, 610);
            this.Controls.Add(this.Настройки);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.TP_Settings.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.Button B_SQLConnection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_XMLPath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LV_Tables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button B_TablesRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button B_TablesSave;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_Search;
    }
}

