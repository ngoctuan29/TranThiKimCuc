namespace Ps.Clinic.ViewPopup
{
    partial class frmLyDoHuyPhieuThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLyDoHuyPhieuThu));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtReason = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butClosed = new DevExpress.XtraEditors.SimpleButton();
            this.butAgree = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.txtReason);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.butClosed);
            this.groupControl1.Controls.Add(this.butAgree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(401, 197);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Lý do hủy phiếu thu";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(12, 55);
            this.txtReason.Name = "txtReason";
            this.txtReason.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.txtReason.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtReason.Size = new System.Drawing.Size(382, 83);
            this.txtReason.TabIndex = 1016;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReason_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(127, 13);
            this.labelControl2.TabIndex = 1015;
            this.labelControl2.Text = "Nhập lý do hủy phiếu thu :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Location = new System.Drawing.Point(301, 179);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 1014;
            this.labelControl1.Text = "Powersoft Co., Ltd";
            // 
            // butClosed
            // 
            this.butClosed.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butClosed.Image = ((System.Drawing.Image)(resources.GetObject("butClosed.Image")));
            this.butClosed.Location = new System.Drawing.Point(312, 144);
            this.butClosed.Name = "butClosed";
            this.butClosed.Size = new System.Drawing.Size(82, 27);
            this.butClosed.TabIndex = 4;
            this.butClosed.Text = "Thoát";
            this.butClosed.Click += new System.EventHandler(this.butClosed_Click);
            // 
            // butAgree
            // 
            this.butAgree.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butAgree.Image = ((System.Drawing.Image)(resources.GetObject("butAgree.Image")));
            this.butAgree.Location = new System.Drawing.Point(231, 144);
            this.butAgree.Name = "butAgree";
            this.butAgree.Size = new System.Drawing.Size(80, 27);
            this.butAgree.TabIndex = 3;
            this.butAgree.Text = "Đồng ý";
            this.butAgree.Click += new System.EventHandler(this.butAgree_Click);
            // 
            // frmLyDoHuyPhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 197);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLyDoHuyPhieuThu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng khám.";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton butAgree;
        private DevExpress.XtraEditors.SimpleButton butClosed;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtReason;

    }
}