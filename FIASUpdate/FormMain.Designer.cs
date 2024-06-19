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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Search = new System.Windows.Forms.Button();
            this.B_Operation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_ImportDelta = new System.Windows.Forms.Button();
            this.B_ImportFull = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.B_Settings = new System.Windows.Forms.ToolStripButton();
            this.B_About = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сервис";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.B_Search, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_Operation, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(531, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // B_Search
            // 
            this.B_Search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_Search.AutoSize = true;
            this.B_Search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Search.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_Search.Image = global::FIASUpdate.icons8.Search16;
            this.B_Search.Location = new System.Drawing.Point(60, 3);
            this.B_Search.Name = "B_Search";
            this.B_Search.Padding = new System.Windows.Forms.Padding(5);
            this.B_Search.Size = new System.Drawing.Size(144, 33);
            this.B_Search.TabIndex = 0;
            this.B_Search.Text = "Поиск адреса в БД";
            this.B_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Search.UseVisualStyleBackColor = true;
            this.B_Search.Click += new System.EventHandler(this.B_Search_Click);
            // 
            // B_Operation
            // 
            this.B_Operation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_Operation.AutoSize = true;
            this.B_Operation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Operation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_Operation.Image = global::FIASUpdate.icons8.Replace16;
            this.B_Operation.Location = new System.Drawing.Point(339, 3);
            this.B_Operation.Name = "B_Operation";
            this.B_Operation.Padding = new System.Windows.Forms.Padding(5);
            this.B_Operation.Size = new System.Drawing.Size(117, 33);
            this.B_Operation.TabIndex = 0;
            this.B_Operation.Text = "Операции БД";
            this.B_Operation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Operation.UseVisualStyleBackColor = true;
            this.B_Operation.Click += new System.EventHandler(this.B_Operation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 167);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Импорт БД";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.B_ImportDelta, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_ImportFull, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(531, 146);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // B_ImportDelta
            // 
            this.B_ImportDelta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_ImportDelta.AutoSize = true;
            this.B_ImportDelta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_ImportDelta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_ImportDelta.Location = new System.Drawing.Point(168, 93);
            this.B_ImportDelta.Margin = new System.Windows.Forms.Padding(20);
            this.B_ImportDelta.MinimumSize = new System.Drawing.Size(180, 0);
            this.B_ImportDelta.Name = "B_ImportDelta";
            this.B_ImportDelta.Padding = new System.Windows.Forms.Padding(5);
            this.B_ImportDelta.Size = new System.Drawing.Size(194, 33);
            this.B_ImportDelta.TabIndex = 0;
            this.B_ImportDelta.Text = "Импорт разностных копий БД";
            this.B_ImportDelta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_ImportDelta.UseVisualStyleBackColor = true;
            this.B_ImportDelta.Click += new System.EventHandler(this.B_ImportDelta_Click);
            // 
            // B_ImportFull
            // 
            this.B_ImportFull.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_ImportFull.AutoSize = true;
            this.B_ImportFull.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_ImportFull.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.B_ImportFull.Location = new System.Drawing.Point(175, 20);
            this.B_ImportFull.Margin = new System.Windows.Forms.Padding(20);
            this.B_ImportFull.MinimumSize = new System.Drawing.Size(180, 0);
            this.B_ImportFull.Name = "B_ImportFull";
            this.B_ImportFull.Padding = new System.Windows.Forms.Padding(5);
            this.B_ImportFull.Size = new System.Drawing.Size(180, 33);
            this.B_ImportFull.TabIndex = 0;
            this.B_ImportFull.Text = "Импорт полной копии БД";
            this.B_ImportFull.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_ImportFull.UseVisualStyleBackColor = true;
            this.B_ImportFull.Click += new System.EventHandler(this.B_ImportFull_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_Settings,
            this.B_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(537, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // B_Settings
            // 
            this.B_Settings.Image = global::FIASUpdate.icons8.Settings16;
            this.B_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Settings.Name = "B_Settings";
            this.B_Settings.Size = new System.Drawing.Size(87, 22);
            this.B_Settings.Text = "Настройки";
            this.B_Settings.Click += new System.EventHandler(this.B_Settings_Click);
            // 
            // B_About
            // 
            this.B_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.B_About.Image = global::FIASUpdate.icons8.Info16;
            this.B_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_About.Name = "B_About";
            this.B_About.Size = new System.Drawing.Size(110, 22);
            this.B_About.Text = "О приложении";
            this.B_About.Click += new System.EventHandler(this.B_About_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(537, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormMain";
            this.Text = "FIAS Update";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button B_ImportFull;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_ImportDelta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Search;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton B_Settings;
        private System.Windows.Forms.ToolStripButton B_About;
        private System.Windows.Forms.Button B_Operation;
    }
}

