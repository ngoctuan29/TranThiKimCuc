﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmRpt_DSGuiMauXN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        public frmRpt_DSGuiMauXN()
        {
            InitializeComponent();
        }

        private void frmRpt_DSDotDieuTri_Load(object sender, EventArgs e)
        {
            
        }
        

        private void butPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl_result.ShowPrintPreview();
        }

        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                dtResult = new DataTable();
                dtResult = ServiceLaboratoryEntryBLL.DT_ListResultLabSend(dllNgay.tungay.Text, dllNgay.denngay.Text);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    gridControl_result.DataSource = dtResult;
                    this.gridView_result.Columns["WorkDate"].Group();
                    this.gridView_result.ExpandAllGroups();
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl_result.ShowPrintPreview();
            }
            catch { }
        }

        private void butXml_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsxml = new DataSet();
                DataTable dtPatients = new DataTable();
                DataTable dtReceive = new DataTable();
                DataTable dtSugges = new DataTable();
                DataTable dtMedicalRecord = new DataTable();
                DataTable dtMedicalRecordDetail = new DataTable();
                string sPatientCode = string.Empty, sMedicalCode = string.Empty;
                decimal dReceiveID = 0;
                foreach (DataRow r in dtResult.Select("Chon=1", "Chon Desc"))
                {
                    dsxml.Clone();
                    dtPatients.Clone();
                    sPatientCode = r["PatientCode"].ToString();
                    dReceiveID = Convert.ToDecimal(r["PatientReceiveID"].ToString());
                    dtPatients = PatientsBLL.hsba_Patients(sPatientCode);
                    dtReceive = PatientReceiveBLL.hsba_DTReceive(dReceiveID, sPatientCode);
                    dtSugges = SuggestedServiceReceiptBLL.hsba_Suggested(dReceiveID, sPatientCode);
                    dtMedicalRecord = MedicalRecord_BLL.hsba_MedicalRecord(dReceiveID, sPatientCode);
                    if (dtMedicalRecord.Rows.Count > 0)
                        sMedicalCode = dtMedicalRecord.Rows[0]["MedicalRecordCode"].ToString();
                    dtMedicalRecordDetail  = MedicalRecord_BLL.hsba_MedicalDetail(sMedicalCode);
                    dsxml.Tables.Add(dtPatients);
                    dsxml.Tables.Add(dtReceive);
                    dsxml.Tables.Add(dtSugges);
                    dsxml.Tables.Add(dtMedicalRecord);
                    dsxml.Tables.Add(dtMedicalRecordDetail);
                    string sfilename = @"..\..\hsba\" + sPatientCode + "_" + dReceiveID + ".xml";
                    if (File.Exists(sfilename))
                        File.Delete(sfilename);
                    dsxml.WriteXml(sfilename);
                }
            }
            catch { }
        }
        
    }
}