namespace Ps.Clinic.ViewPopup
{
    partial class frmVP_ChonQuyenSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_ChonQuyenSo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.LkupNoteBook = new DevExpress.XtraEditors.LookUpEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgree = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkupNoteBook.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.CaptionImage = global::Ps.Clinic.Properties.Resources.checklist_icon;
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.LkupNoteBook);
            this.groupControl1.Controls.Add(this.btnExit);
            this.groupControl1.Controls.Add(this.btnAgree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(322, 125);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Chọn quyển sổ thu tiền";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(5, 55);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(53, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Quyển sổ :";
            // 
            // LkupNoteBook
            // 
            this.LkupNoteBook.EditValue = "";
            this.LkupNoteBook.Location = new System.Drawing.Point(64, 52);
            this.LkupNoteBook.Name = "LkupNoteBook";
            this.LkupNoteBook.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.LkupNoteBook.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LkupNoteBook.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", 30, "Ký hiệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NoteBookName", 60, "Quyển sổ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WriteNumber", 35, "Số ghi đến")});
            this.LkupNoteBook.Properties.NullText = "Phòng khám";
            this.LkupNoteBook.Size = new System.Drawing.Size(239, 20);
            this.LkupNoteBook.TabIndex = 1;
            this.LkupNoteBook.EditValueChanged += new System.EventHandler(this.LkupNoteBook_EditValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(171, 83);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAgree.Image = ((System.Drawing.Image)(resources.GetObject("btnAgree.Image")));
            this.btnAgree.Location = new System.Drawing.Point(96, 83);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(74, 25);
            this.btnAgree.TabIndex = 3;
            this.btnAgree.Text = "Đồng ý";
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // frmVP_ChonQuyenSo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(322, 125);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVP_ChonQuyenSo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn quyển sổ thu tiền";
            this.Load += new System.EventHandler(this.frmVP_ChonQuyenSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkupNoteBook.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit LkupNoteBook;
        private DevExpress.XtraEditors.SimpleButton btnAgree;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.GroupControl groupControl1;

    }
}