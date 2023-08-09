namespace FIASUpdate.Controls
{
    partial class UC_Database
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LV_Tables = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Refresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Version = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Subject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_SQLConnection = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.B_XMLPath = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LV_Tables);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(501, 196);
            this.groupBox3.TabIndex = 3;
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
            listViewItem1.StateImageIndex = 0;
            this.LV_Tables.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.LV_Tables.Location = new System.Drawing.Point(3, 16);
            this.LV_Tables.MultiSelect = false;
            this.LV_Tables.Name = "LV_Tables";
            this.LV_Tables.Size = new System.Drawing.Size(495, 177);
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
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.B_Save, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.B_Refresh, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 258);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(501, 63);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // B_Save
            // 
            this.B_Save.AutoSize = true;
            this.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Save.Location = new System.Drawing.Point(426, 35);
            this.B_Save.Name = "B_Save";
            this.B_Save.Padding = new System.Windows.Forms.Padding(1);
            this.B_Save.Size = new System.Drawing.Size(72, 25);
            this.B_Save.TabIndex = 2;
            this.B_Save.Text = "Сохранить";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Refresh
            // 
            this.B_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Refresh.AutoSize = true;
            this.B_Refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Refresh.Location = new System.Drawing.Point(3, 35);
            this.B_Refresh.Name = "B_Refresh";
            this.B_Refresh.Padding = new System.Windows.Forms.Padding(1);
            this.B_Refresh.Size = new System.Drawing.Size(68, 25);
            this.B_Refresh.TabIndex = 2;
            this.B_Refresh.Text = "Обновить";
            this.B_Refresh.UseVisualStyleBackColor = true;
            this.B_Refresh.Click += new System.EventHandler(this.B_Refresh_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.TB_Version);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.TB_Subject);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(379, 26);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Версия:";
            // 
            // TB_Version
            // 
            this.TB_Version.Location = new System.Drawing.Point(56, 3);
            this.TB_Version.Name = "TB_Version";
            this.TB_Version.ReadOnly = true;
            this.TB_Version.Size = new System.Drawing.Size(76, 20);
            this.TB_Version.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Субъекты:";
            // 
            // TB_Subject
            // 
            this.TB_Subject.Location = new System.Drawing.Point(204, 3);
            this.TB_Subject.Name = "TB_Subject";
            this.TB_Subject.ReadOnly = true;
            this.TB_Subject.Size = new System.Drawing.Size(172, 20);
            this.TB_Subject.TabIndex = 1;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(501, 62);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "SQLConnection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(3, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(415, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = global::FIASUpdate.Properties.Settings.Default.SQLConnection;
            // 
            // B_SQLConnection
            // 
            this.B_SQLConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_SQLConnection.AutoSize = true;
            this.B_SQLConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_SQLConnection.Location = new System.Drawing.Point(424, 3);
            this.B_SQLConnection.Name = "B_SQLConnection";
            this.B_SQLConnection.Padding = new System.Windows.Forms.Padding(1);
            this.B_SQLConnection.Size = new System.Drawing.Size(74, 25);
            this.B_SQLConnection.TabIndex = 0;
            this.B_SQLConnection.Text = "SQL Server";
            this.B_SQLConnection.UseVisualStyleBackColor = true;
            this.B_SQLConnection.Click += new System.EventHandler(this.B_SQLConnection_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "XMLPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(3, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(415, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::FIASUpdate.Properties.Settings.Default.XMLPath;
            // 
            // B_XMLPath
            // 
            this.B_XMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_XMLPath.AutoSize = true;
            this.B_XMLPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_XMLPath.Location = new System.Drawing.Point(424, 34);
            this.B_XMLPath.Name = "B_XMLPath";
            this.B_XMLPath.Padding = new System.Windows.Forms.Padding(1);
            this.B_XMLPath.Size = new System.Drawing.Size(74, 25);
            this.B_XMLPath.TabIndex = 0;
            this.B_XMLPath.Text = "XML Path";
            this.B_XMLPath.UseVisualStyleBackColor = true;
            this.B_XMLPath.Click += new System.EventHandler(this.B_XMLPath_Click);
            // 
            // UC_Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UC_Database";
            this.Size = new System.Drawing.Size(501, 321);
            this.Load += new System.EventHandler(this.UC_Database_Load);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LV_Tables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button B_Refresh;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_SQLConnection;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button B_XMLPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Version;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Subject;
    }
}
