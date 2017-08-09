using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraScheduler;
namespace Ps.Clinic.Entry
{
    public partial class frmHen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataTable dtMedicalDetail = new DataTable();
        
        public frmHen()
        {
            InitializeComponent();
            dtfrom.EditValue = dtTo.EditValue = Utils.DateServer();
        }


        private void frmHen_Load(object sender, EventArgs e)
        {
            
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                        //patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        //MedicalCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_MedicalRecordCode).ToString(), string.Empty);
                        //dReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveID).ToString());
                        //iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        //dRowIDMedicines = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RowIDMedicinesFor).ToString());
                        //sPatientName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        //sAddRess = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString(), string.Empty);
                        //sBirthyear = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        //if (patientCode != string.Empty && dReceiveID != 0 && MedicalCode != string.Empty && iObjectCode != 0)
                        //{
                            
                        //}
                        //else
                        //{
                        //    return;
                        //}
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }

        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void frmHen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3: butSave_Click(sender, e); break;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    this.Close();
                    GC.Collect();
                }
                else
                {
                    XtraMessageBox.Show(" Danh sách hẹn lưu không thành công!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch { }
        }

        private void AppointmentScheduler_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            try
            {
                //frmHenPopup frm = new frmHenPopup();
                //frm.ShowDialog();
                //Appointment apt = e.Appointment;
                //bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);

                // Create a custom form.
                //frmHenPopup frm = new frmHenPopup((SchedulerControl)sender, apt, openRecurrenceForm);
                //try
                //{
                //    // Required for skins support.
                //    myForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel;

                //    e.DialogResult = myForm.ShowDialog();
                //    schedulerControl1.Refresh();
                //    e.Handled = true;
                //}
                //finally
                //{
                //    myForm.Dispose();
                //}
            }
            catch { }
        }

        private void AppointmentScheduler_AllowAppointmentConflicts(object sender, AppointmentConflictEventArgs e)
        {
            e.Conflicts.Clear();

            AppointmentDependencyBaseCollection depCollectionDep =
                schedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(e.Appointment.Id);
            if (depCollectionDep.Count > 0)
            {
                if (CheckForInvalidDependenciesAsDependent(depCollectionDep, e.AppointmentClone))
                    e.Conflicts.Add(e.AppointmentClone);
            }

            AppointmentDependencyBaseCollection depCollectionPar =
                schedulerStorage1.AppointmentDependencies.Items.GetDependenciesByParentId(e.Appointment.Id);
            if (depCollectionPar.Count > 0)
            {
                if (CheckForInvalidDependenciesAsParent(depCollectionPar, e.AppointmentClone))
                    e.Conflicts.Add(e.AppointmentClone);
            }
        }

        private bool CheckForInvalidDependenciesAsDependent(AppointmentDependencyBaseCollection depCollection, Appointment apt)
        {
            foreach (AppointmentDependency dep in depCollection)
            {
                if (dep.Type == AppointmentDependencyType.FinishToStart)
                {
                    DateTime checkTime = schedulerStorage1.Appointments.Items.GetAppointmentById(dep.ParentId).End;
                    if (apt.Start < checkTime)
                        return true;
                }
            }
            return false;
        }

        private bool CheckForInvalidDependenciesAsParent(AppointmentDependencyBaseCollection depCollection, Appointment apt)
        {
            foreach (AppointmentDependency dep in depCollection)
            {
                if (dep.Type == AppointmentDependencyType.FinishToStart)
                {
                    DateTime checkTime = schedulerStorage1.Appointments.Items.GetAppointmentById(dep.DependentId).Start;
                    if (apt.End > checkTime)
                        return true;
                }
            }
            return false;
        }

        

        private void schedulerControl1_InplaceEditorShowing(object sender, InplaceEditorEventArgs e)
        {
            
        }

    }
}