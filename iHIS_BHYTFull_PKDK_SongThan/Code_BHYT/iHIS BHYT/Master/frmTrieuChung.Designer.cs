namespace Ps.Clinic.Master
{
    partial class frmTrieuChung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrieuChung));
            this.gridControl_Symptom = new DevExpress.XtraGrid.GridControl();
            this.gridView_Symptoms = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_SymptomsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Symptom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Symptoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Symptom
            // 
            this.gridControl_Symptom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Symptom.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Symptom.MainView = this.gridView_Symptoms;
            this.gridControl_Symptom.Name = "gridControl_Symptom";
            this.gridControl_Symptom.Size = new System.Drawing.Size(690, 312);
            this.gridControl_Symptom.TabIndex = 2;
            this.gridControl_Symptom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Symptoms});
            this.gridControl_Symptom.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Symptom_ProcessGridKey);
            // 
            // gridView_Symptoms
            // 
            this.gridView_Symptoms.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Symptoms.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Symptoms.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Symptoms.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Symptoms.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Symptoms.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Symptoms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_SymptomsName,
            this.col_RowID});
            this.gridView_Symptoms.GridControl = this.gridControl_Symptom;
            this.gridView_Symptoms.Name = "gridView_Symptoms";
            this.gridView_Symptoms.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Triệu chứng bệnh).";
            this.gridView_Symptoms.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Symptoms.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Symptoms.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Symptoms.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Symptoms.OptionsView.ShowFooter = true;
            this.gridView_Symptoms.OptionsView.ShowGroupPanel = false;
            this.gridView_Symptoms.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Symptoms_InvalidRowException);
            this.gridView_Symptoms.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Symptoms_ValidateRow);
            this.gridView_Symptoms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Symptoms_KeyDown);
            // 
            // col_SymptomsName
            // 
            this.col_SymptomsName.Caption = "Tên diễn giải";
            this.col_SymptomsName.FieldName = "SymptomsName";
            this.col_SymptomsName.Name = "col_SymptomsName";
            this.col_SymptomsName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_SymptomsName.Visible = true;
            this.col_SymptomsName.VisibleIndex = 0;
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "Mã";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Symptom);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(694, 337);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục - Triệu chứng bệnh ban đầu";
            // 
            // frmTrieuChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 337);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrieuChung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Triệu chứng bệnh ban đầu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrieuChung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Symptom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Symptoms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Symptom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Symptoms;
        private DevExpress.XtraGrid.Columns.GridColumn col_SymptomsName;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}