namespace FIASUpdate.Forms
{
    partial class FormSettings
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.Info = new FIASUpdate.Controls.UC_DatabaseInfo();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_SQLConnection = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.B_XMLPath = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Refresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Tables = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Info.Location = new System.Drawing.Point(0, 475);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(544, 56);
            this.Info.Subjects = null;
            this.Info.TabIndex = 10;
            this.Info.Version = new System.DateTime(((long)(0)));
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "SQLConnection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(82, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(372, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = global::FIASUpdate.Properties.Settings.Default.SQLConnection;
            // 
            // B_SQLConnection
            // 
            this.B_SQLConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_SQLConnection.AutoSize = true;
            this.B_SQLConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_SQLConnection.Image = global::FIASUpdate.icons8.PencilDrawing16;
            this.B_SQLConnection.Location = new System.Drawing.Point(460, 3);
            this.B_SQLConnection.Name = "B_SQLConnection";
            this.B_SQLConnection.Padding = new System.Windows.Forms.Padding(1);
            this.B_SQLConnection.Size = new System.Drawing.Size(81, 25);
            this.B_SQLConnection.TabIndex = 0;
            this.B_SQLConnection.Text = "Выбрать";
            this.B_SQLConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_SQLConnection.UseVisualStyleBackColor = true;
            this.B_SQLConnection.Click += new System.EventHandler(this.B_SQLConnection_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FIASUpdate.Properties.Settings.Default, "XMLPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(82, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(372, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::FIASUpdate.Properties.Settings.Default.XMLPath;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Соединение";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Каталог";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_SQLConnection, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.B_XMLPath, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(544, 62);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // B_XMLPath
            // 
            this.B_XMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_XMLPath.AutoSize = true;
            this.B_XMLPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_XMLPath.Image = global::FIASUpdate.icons8.OpenedFolder16;
            this.B_XMLPath.Location = new System.Drawing.Point(460, 34);
            this.B_XMLPath.Name = "B_XMLPath";
            this.B_XMLPath.Padding = new System.Windows.Forms.Padding(1);
            this.B_XMLPath.Size = new System.Drawing.Size(81, 25);
            this.B_XMLPath.TabIndex = 0;
            this.B_XMLPath.Text = "Выбрать";
            this.B_XMLPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_XMLPath.UseVisualStyleBackColor = true;
            this.B_XMLPath.Click += new System.EventHandler(this.B_XMLPath_Click);
            // 
            // B_Save
            // 
            this.B_Save.AutoSize = true;
            this.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Save.Image = global::FIASUpdate.icons8.Save16;
            this.B_Save.Location = new System.Drawing.Point(449, 3);
            this.B_Save.Name = "B_Save";
            this.B_Save.Padding = new System.Windows.Forms.Padding(1);
            this.B_Save.Size = new System.Drawing.Size(92, 25);
            this.B_Save.TabIndex = 2;
            this.B_Save.Text = "Сохранить";
            this.B_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Refresh
            // 
            this.B_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Refresh.AutoSize = true;
            this.B_Refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Refresh.Image = global::FIASUpdate.icons8.Replace16;
            this.B_Refresh.Location = new System.Drawing.Point(3, 3);
            this.B_Refresh.Name = "B_Refresh";
            this.B_Refresh.Padding = new System.Windows.Forms.Padding(1);
            this.B_Refresh.Size = new System.Drawing.Size(89, 25);
            this.B_Refresh.TabIndex = 2;
            this.B_Refresh.Text = "Обновить";
            this.B_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Refresh.UseVisualStyleBackColor = true;
            this.B_Refresh.Click += new System.EventHandler(this.B_Refresh_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.B_Save, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.B_Refresh, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 531);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(544, 31);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата импорта";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Строк";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Таблица";
            this.columnHeader1.Width = 116;
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
            this.LV_Tables.Location = new System.Drawing.Point(3, 18);
            this.LV_Tables.MultiSelect = false;
            this.LV_Tables.Name = "LV_Tables";
            this.LV_Tables.Size = new System.Drawing.Size(538, 392);
            this.LV_Tables.TabIndex = 0;
            this.LV_Tables.UseCompatibleStateImageBehavior = false;
            this.LV_Tables.View = System.Windows.Forms.View.Details;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LV_Tables);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 413);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Таблицы для импорта";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(544, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 600);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UC_DatabaseInfo Info;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_SQLConnection;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button B_XMLPath;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView LV_Tables;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}