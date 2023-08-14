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
            this.Настройки = new System.Windows.Forms.TabControl();
            this.TP_Import = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_ImportDelta = new System.Windows.Forms.Button();
            this.B_ImportFull = new System.Windows.Forms.Button();
            this.TP_Settings = new System.Windows.Forms.TabPage();
            this.uC_Database1 = new FIASUpdate.Controls.UC_Database();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MI_About = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.Настройки.SuspendLayout();
            this.TP_Import.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TP_Settings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Настройки
            // 
            this.Настройки.Controls.Add(this.TP_Import);
            this.Настройки.Controls.Add(this.TP_Settings);
            this.Настройки.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Настройки.Location = new System.Drawing.Point(0, 24);
            this.Настройки.Name = "Настройки";
            this.Настройки.SelectedIndex = 0;
            this.Настройки.Size = new System.Drawing.Size(537, 586);
            this.Настройки.TabIndex = 10;
            // 
            // TP_Import
            // 
            this.TP_Import.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.TP_Import.Controls.Add(this.tableLayoutPanel1);
            this.TP_Import.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Import.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Import.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Import.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.TP_Import.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.TP_Import.Location = new System.Drawing.Point(4, 22);
            this.TP_Import.Name = "TP_Import";
            this.TP_Import.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Import.Size = new System.Drawing.Size(529, 560);
            this.TP_Import.TabIndex = 1;
            this.TP_Import.Text = "Импорт данных";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.B_ImportDelta, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_ImportFull, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 146);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // B_ImportDelta
            // 
            this.B_ImportDelta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_ImportDelta.AutoSize = true;
            this.B_ImportDelta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_ImportDelta.Enabled = false;
            this.B_ImportDelta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_ImportDelta.Location = new System.Drawing.Point(177, 93);
            this.B_ImportDelta.Margin = new System.Windows.Forms.Padding(20);
            this.B_ImportDelta.Name = "B_ImportDelta";
            this.B_ImportDelta.Padding = new System.Windows.Forms.Padding(5);
            this.B_ImportDelta.Size = new System.Drawing.Size(168, 33);
            this.B_ImportDelta.TabIndex = 0;
            this.B_ImportDelta.Text = "Импорт БД - Обновления";
            this.B_ImportDelta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_ImportDelta.UseVisualStyleBackColor = true;
            this.B_ImportDelta.Visible = false;
            this.B_ImportDelta.Click += new System.EventHandler(this.B_ImportDelta_Click);
            // 
            // B_ImportFull
            // 
            this.B_ImportFull.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_ImportFull.AutoSize = true;
            this.B_ImportFull.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_ImportFull.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_ImportFull.Location = new System.Drawing.Point(191, 20);
            this.B_ImportFull.Margin = new System.Windows.Forms.Padding(20);
            this.B_ImportFull.Name = "B_ImportFull";
            this.B_ImportFull.Padding = new System.Windows.Forms.Padding(5);
            this.B_ImportFull.Size = new System.Drawing.Size(141, 33);
            this.B_ImportFull.TabIndex = 0;
            this.B_ImportFull.Text = "Импорт БД - Полная";
            this.B_ImportFull.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_ImportFull.UseVisualStyleBackColor = true;
            this.B_ImportFull.Click += new System.EventHandler(this.B_ImportFull_Click);
            // 
            // TP_Settings
            // 
            this.TP_Settings.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.TP_Settings.Controls.Add(this.uC_Database1);
            this.TP_Settings.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Settings.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Settings.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Settings.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.TP_Settings.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.TP_Settings.Location = new System.Drawing.Point(4, 22);
            this.TP_Settings.Name = "TP_Settings";
            this.TP_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Settings.Size = new System.Drawing.Size(529, 560);
            this.TP_Settings.TabIndex = 2;
            this.TP_Settings.Text = "Настройки";
            // 
            // uC_Database1
            // 
            this.uC_Database1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Database1.Location = new System.Drawing.Point(3, 3);
            this.uC_Database1.Name = "uC_Database1";
            this.uC_Database1.Size = new System.Drawing.Size(523, 554);
            this.uC_Database1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_About,
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MI_About
            // 
            this.MI_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MI_About.Image = global::FIASUpdate.icons8.Info16;
            this.MI_About.Name = "MI_About";
            this.MI_About.Size = new System.Drawing.Size(118, 20);
            this.MI_About.Text = "О приложении";
            this.MI_About.Click += new System.EventHandler(this.MI_About_Click);
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
            this.MI_Search.Image = global::FIASUpdate.icons8.Search16;
            this.MI_Search.Name = "MI_Search";
            this.MI_Search.Size = new System.Drawing.Size(176, 22);
            this.MI_Search.Text = "Поиск адреса в БД";
            this.MI_Search.Click += new System.EventHandler(this.MI_Search_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(537, 610);
            this.Controls.Add(this.Настройки);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(550, 500);
            this.Name = "FormMain";
            this.Text = "FIAS Update";
            this.Настройки.ResumeLayout(false);
            this.TP_Import.ResumeLayout(false);
            this.TP_Import.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TP_Settings.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.TabControl Настройки;
        private System.Windows.Forms.TabPage TP_Import;
        private System.Windows.Forms.TabPage TP_Settings;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_Search;
        private Controls.UC_Database uC_Database1;
        private System.Windows.Forms.Button B_ImportFull;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_ImportDelta;
        private System.Windows.Forms.ToolStripMenuItem MI_About;
    }
}

