namespace FIASUpdate.Controls
{
    partial class UC_FIASObject
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
            this.components = new System.ComponentModel.Container();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Address = new System.Windows.Forms.TextBox();
            this.SB_Parameters = new FIASUpdate.Controls.SplitButton();
            this.M_Other = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MI_PDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_URL = new System.Windows.Forms.ToolStripMenuItem();
            this.Label3 = new System.Windows.Forms.Label();
            this.TB_GUID = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.B_CopyGUID = new System.Windows.Forms.Button();
            this.B_CopyAddress = new System.Windows.Forms.Button();
            this.B_Parameters = new System.Windows.Forms.Button();
            this.B_PDF = new System.Windows.Forms.Button();
            this.B_URL = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TableLayoutPanel2.SuspendLayout();
            this.M_Other.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.AutoSize = true;
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.Controls.Add(this.TB_Address, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.SB_Parameters, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.TB_GUID, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.B_CopyGUID, 3, 0);
            this.TableLayoutPanel2.Controls.Add(this.B_CopyAddress, 3, 1);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.Size = new System.Drawing.Size(658, 62);
            this.TableLayoutPanel2.TabIndex = 17;
            // 
            // TB_Address
            // 
            this.TB_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel2.SetColumnSpan(this.TB_Address, 2);
            this.TB_Address.Location = new System.Drawing.Point(47, 36);
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.ReadOnly = true;
            this.TB_Address.Size = new System.Drawing.Size(507, 20);
            this.TB_Address.TabIndex = 5;
            // 
            // SB_Parameters
            // 
            this.SB_Parameters.AutoSize = true;
            this.SB_Parameters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SB_Parameters.ContextMenuStrip = this.M_Other;
            this.SB_Parameters.Image = global::FIASUpdate.icons8.TableProperties16;
            this.SB_Parameters.Location = new System.Drawing.Point(442, 3);
            this.SB_Parameters.Name = "SB_Parameters";
            this.SB_Parameters.Padding = new System.Windows.Forms.Padding(1);
            this.SB_Parameters.Size = new System.Drawing.Size(112, 25);
            this.SB_Parameters.SplitMenuStrip = this.M_Other;
            this.SB_Parameters.TabIndex = 21;
            this.SB_Parameters.Text = "Параметры";
            this.SB_Parameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SB_Parameters.UseVisualStyleBackColor = true;
            this.SB_Parameters.Click += new System.EventHandler(this.SB_Parameters_Click);
            // 
            // M_Other
            // 
            this.M_Other.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_PDF,
            this.MI_URL});
            this.M_Other.Name = "contextMenuStrip1";
            this.M_Other.Size = new System.Drawing.Size(181, 70);
            // 
            // MI_PDF
            // 
            this.MI_PDF.Image = global::FIASUpdate.icons8.PDF16;
            this.MI_PDF.Name = "MI_PDF";
            this.MI_PDF.Size = new System.Drawing.Size(180, 22);
            this.MI_PDF.Text = "Скачать выписку";
            this.MI_PDF.Click += new System.EventHandler(this.MI_PDF_Click);
            // 
            // MI_URL
            // 
            this.MI_URL.Image = global::FIASUpdate.icons8.Internet16;
            this.MI_URL.Name = "MI_URL";
            this.MI_URL.Size = new System.Drawing.Size(180, 22);
            this.MI_URL.Text = "Открыть на сайте";
            this.MI_URL.Click += new System.EventHandler(this.MI_URL_Click);
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 40);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Адрес";
            // 
            // TB_GUID
            // 
            this.TB_GUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GUID.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_GUID.Location = new System.Drawing.Point(47, 5);
            this.TB_GUID.Name = "TB_GUID";
            this.TB_GUID.ReadOnly = true;
            this.TB_GUID.Size = new System.Drawing.Size(389, 20);
            this.TB_GUID.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "GUID";
            // 
            // B_CopyGUID
            // 
            this.B_CopyGUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_CopyGUID.AutoSize = true;
            this.B_CopyGUID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_CopyGUID.Enabled = false;
            this.B_CopyGUID.Image = global::FIASUpdate.icons8.Clipboard16;
            this.B_CopyGUID.Location = new System.Drawing.Point(560, 3);
            this.B_CopyGUID.Name = "B_CopyGUID";
            this.B_CopyGUID.Padding = new System.Windows.Forms.Padding(1);
            this.B_CopyGUID.Size = new System.Drawing.Size(95, 25);
            this.B_CopyGUID.TabIndex = 3;
            this.B_CopyGUID.Text = "Копировать";
            this.B_CopyGUID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_CopyGUID.UseVisualStyleBackColor = true;
            this.B_CopyGUID.Click += new System.EventHandler(this.B_CopyGUID_Click);
            // 
            // B_CopyAddress
            // 
            this.B_CopyAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_CopyAddress.AutoSize = true;
            this.B_CopyAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_CopyAddress.Enabled = false;
            this.B_CopyAddress.Image = global::FIASUpdate.icons8.Clipboard16;
            this.B_CopyAddress.Location = new System.Drawing.Point(560, 34);
            this.B_CopyAddress.Name = "B_CopyAddress";
            this.B_CopyAddress.Padding = new System.Windows.Forms.Padding(1);
            this.B_CopyAddress.Size = new System.Drawing.Size(95, 25);
            this.B_CopyAddress.TabIndex = 3;
            this.B_CopyAddress.Text = "Копировать";
            this.B_CopyAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_CopyAddress.UseVisualStyleBackColor = true;
            this.B_CopyAddress.Click += new System.EventHandler(this.B_CopyAddress_Click);
            // 
            // B_Parameters
            // 
            this.B_Parameters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_Parameters.AutoSize = true;
            this.B_Parameters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Parameters.Enabled = false;
            this.B_Parameters.Image = global::FIASUpdate.icons8.TableProperties16;
            this.B_Parameters.Location = new System.Drawing.Point(190, 3);
            this.B_Parameters.Name = "B_Parameters";
            this.B_Parameters.Padding = new System.Windows.Forms.Padding(1);
            this.B_Parameters.Size = new System.Drawing.Size(94, 25);
            this.B_Parameters.TabIndex = 19;
            this.B_Parameters.Text = "Параметры";
            this.B_Parameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Parameters.UseVisualStyleBackColor = true;
            this.B_Parameters.Click += new System.EventHandler(this.B_Parameters_Click);
            // 
            // B_PDF
            // 
            this.B_PDF.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_PDF.AutoSize = true;
            this.B_PDF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_PDF.Enabled = false;
            this.B_PDF.Image = global::FIASUpdate.icons8.PDF16;
            this.B_PDF.Location = new System.Drawing.Point(104, 3);
            this.B_PDF.Name = "B_PDF";
            this.B_PDF.Padding = new System.Windows.Forms.Padding(1);
            this.B_PDF.Size = new System.Drawing.Size(80, 25);
            this.B_PDF.TabIndex = 19;
            this.B_PDF.Text = "Выписка";
            this.B_PDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_PDF.UseVisualStyleBackColor = true;
            this.B_PDF.Click += new System.EventHandler(this.B_PDF_Click);
            // 
            // B_URL
            // 
            this.B_URL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.B_URL.AutoSize = true;
            this.B_URL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_URL.Enabled = false;
            this.B_URL.Image = global::FIASUpdate.icons8.Internet16;
            this.B_URL.Location = new System.Drawing.Point(3, 3);
            this.B_URL.Name = "B_URL";
            this.B_URL.Padding = new System.Windows.Forms.Padding(1);
            this.B_URL.Size = new System.Drawing.Size(95, 25);
            this.B_URL.TabIndex = 19;
            this.B_URL.Text = "Сайт ФИАС";
            this.B_URL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_URL.UseVisualStyleBackColor = true;
            this.B_URL.Click += new System.EventHandler(this.B_URL_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.B_URL);
            this.flowLayoutPanel1.Controls.Add(this.B_PDF);
            this.flowLayoutPanel1.Controls.Add(this.B_Parameters);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(47, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 31);
            this.flowLayoutPanel1.TabIndex = 20;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // UC_FIASObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.TableLayoutPanel2);
            this.Name = "UC_FIASObject";
            this.Size = new System.Drawing.Size(658, 110);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.M_Other.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.TextBox TB_Address;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button B_CopyGUID;
        internal System.Windows.Forms.TextBox TB_GUID;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button B_CopyAddress;
        internal System.Windows.Forms.Button B_Parameters;
        internal System.Windows.Forms.Button B_PDF;
        internal System.Windows.Forms.Button B_URL;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FIASUpdate.Controls.SplitButton SB_Parameters;
        private System.Windows.Forms.ContextMenuStrip M_Other;
        private System.Windows.Forms.ToolStripMenuItem MI_PDF;
        private System.Windows.Forms.ToolStripMenuItem MI_URL;
    }
}
