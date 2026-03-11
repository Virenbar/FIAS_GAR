namespace FIASUpdate.Forms
{
    partial class FormSubjectList
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
            this.LV_Subjects = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Refresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.B_SelectAll = new System.Windows.Forms.Button();
            this.B_DeselectAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_Subjects
            // 
            this.LV_Subjects.CheckBoxes = true;
            this.LV_Subjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LV_Subjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Subjects.FullRowSelect = true;
            this.LV_Subjects.GridLines = true;
            this.LV_Subjects.HideSelection = false;
            this.LV_Subjects.Location = new System.Drawing.Point(5, 36);
            this.LV_Subjects.Name = "LV_Subjects";
            this.LV_Subjects.Size = new System.Drawing.Size(341, 390);
            this.LV_Subjects.TabIndex = 0;
            this.LV_Subjects.UseCompatibleStateImageBehavior = false;
            this.LV_Subjects.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Код";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Наименование";
            this.columnHeader2.Width = 119;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.B_Save, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.B_Refresh, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 426);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(341, 31);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // B_Save
            // 
            this.B_Save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.B_Save.AutoSize = true;
            this.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Save.Image = global::FIASUpdate.icons8.Save16;
            this.B_Save.Location = new System.Drawing.Point(246, 3);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.B_SelectAll);
            this.flowLayoutPanel1.Controls.Add(this.B_DeselectAll);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 31);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // B_SelectAll
            // 
            this.B_SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_SelectAll.AutoSize = true;
            this.B_SelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_SelectAll.Location = new System.Drawing.Point(3, 3);
            this.B_SelectAll.MinimumSize = new System.Drawing.Size(100, 0);
            this.B_SelectAll.Name = "B_SelectAll";
            this.B_SelectAll.Padding = new System.Windows.Forms.Padding(1);
            this.B_SelectAll.Size = new System.Drawing.Size(100, 25);
            this.B_SelectAll.TabIndex = 11;
            this.B_SelectAll.Text = "Выбрать все";
            this.B_SelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_SelectAll.UseVisualStyleBackColor = true;
            this.B_SelectAll.Click += new System.EventHandler(this.B_SelectAll_Click);
            // 
            // B_DeselectAll
            // 
            this.B_DeselectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_DeselectAll.AutoSize = true;
            this.B_DeselectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_DeselectAll.Location = new System.Drawing.Point(109, 3);
            this.B_DeselectAll.MinimumSize = new System.Drawing.Size(100, 0);
            this.B_DeselectAll.Name = "B_DeselectAll";
            this.B_DeselectAll.Padding = new System.Windows.Forms.Padding(1);
            this.B_DeselectAll.Size = new System.Drawing.Size(100, 25);
            this.B_DeselectAll.TabIndex = 11;
            this.B_DeselectAll.Text = "Убрать все";
            this.B_DeselectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_DeselectAll.UseVisualStyleBackColor = true;
            this.B_DeselectAll.Click += new System.EventHandler(this.B_DeselectAll_Click);
            // 
            // FormSubjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(351, 462);
            this.Controls.Add(this.LV_Subjects);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "FormSubjectList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Список субъектоа БД";
            this.Load += new System.EventHandler(this.FormSubjectList_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_Subjects;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Refresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button B_SelectAll;
        private System.Windows.Forms.Button B_DeselectAll;
    }
}