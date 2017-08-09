namespace iHISLCD
{
    partial class ControlLCD
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlDanhSach = new DevExpress.XtraEditors.PanelControl();
            this.pnlTieuDeCot = new DevExpress.XtraEditors.PanelControl();
            this.pnlTenPk = new DevExpress.XtraEditors.PanelControl();
            this.lblTenPK = new DevExpress.XtraEditors.LabelControl();
            this.tmCuon = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTieuDeCot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTenPk)).BeginInit();
            this.pnlTenPk.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlDanhSach.Appearance.Options.UseBackColor = true;
            this.pnlDanhSach.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDanhSach.Location = new System.Drawing.Point(4, 111);
            this.pnlDanhSach.LookAndFeel.SkinName = "Office 2013";
            this.pnlDanhSach.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.ScrollBarSmallChange = 3;
            this.pnlDanhSach.Size = new System.Drawing.Size(519, 190);
            this.pnlDanhSach.TabIndex = 1;
            // 
            // pnlTieuDeCot
            // 
            this.pnlTieuDeCot.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlTieuDeCot.Appearance.Options.UseBackColor = true;
            this.pnlTieuDeCot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTieuDeCot.Location = new System.Drawing.Point(4, 57);
            this.pnlTieuDeCot.LookAndFeel.SkinName = "Office 2013";
            this.pnlTieuDeCot.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlTieuDeCot.Name = "pnlTieuDeCot";
            this.pnlTieuDeCot.ScrollBarSmallChange = 3;
            this.pnlTieuDeCot.Size = new System.Drawing.Size(519, 48);
            this.pnlTieuDeCot.TabIndex = 0;
            // 
            // pnlTenPk
            // 
            this.pnlTenPk.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlTenPk.Appearance.Options.UseBackColor = true;
            this.pnlTenPk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTenPk.Controls.Add(this.lblTenPK);
            this.pnlTenPk.Location = new System.Drawing.Point(4, 3);
            this.pnlTenPk.LookAndFeel.SkinName = "Office 2013";
            this.pnlTenPk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlTenPk.Name = "pnlTenPk";
            this.pnlTenPk.ScrollBarSmallChange = 3;
            this.pnlTenPk.Size = new System.Drawing.Size(519, 48);
            this.pnlTenPk.TabIndex = 0;
            // 
            // lblTenPK
            // 
            this.lblTenPK.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPK.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblTenPK.Location = new System.Drawing.Point(11, 3);
            this.lblTenPK.Name = "lblTenPK";
            this.lblTenPK.Size = new System.Drawing.Size(84, 35);
            this.lblTenPK.TabIndex = 0;
            this.lblTenPK.Text = "tenpk";
            // 
            // tmCuon
            // 
            this.tmCuon.Tick += new System.EventHandler(this.tmCuon_Tick);
            // 
            // ControlLCD
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.pnlTieuDeCot);
            this.Controls.Add(this.pnlTenPk);
            this.Name = "ControlLCD";
            this.Size = new System.Drawing.Size(523, 304);
            this.Load += new System.EventHandler(this.ControlLCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTieuDeCot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTenPk)).EndInit();
            this.pnlTenPk.ResumeLayout(false);
            this.pnlTenPk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.PanelControl pnlTenPk;
        public DevExpress.XtraEditors.PanelControl pnlTieuDeCot;
        public DevExpress.XtraEditors.PanelControl pnlDanhSach;
        private DevExpress.XtraEditors.LabelControl lblTenPK;
        private System.Windows.Forms.Timer tmCuon;
    }
}
