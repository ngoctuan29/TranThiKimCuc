using DevExpress.XtraBars.Docking;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicLibrary
{
    public class EditDesignReport
    {
        private XtraReport rrt;
        private  XRDesignMdiController mdiController;
        bool coluu = false;

        public EditDesignReport(XtraReport rrt)
        {
            this.rrt = rrt;
        }

        public bool ShowpageEditDesign()
        {
            try
            {
                ReportDesignTool rrtDT = new ReportDesignTool(rrt);

                GroupAndSortDockPanel groupSort = (GroupAndSortDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.GroupAndSort];
                groupSort.Visibility = DockVisibility.AutoHide;

                ErrorListDockPanel errorList = (ErrorListDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.ErrorList];
                errorList.Visibility = DockVisibility.AutoHide;

                FieldListDockPanel fieldList = (FieldListDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.FieldList];
                fieldList.Visibility = DockVisibility.AutoHide;

                ReportExplorerDockPanel reportExplorer = (ReportExplorerDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.ReportExplorer];
                reportExplorer.Visibility = DockVisibility.AutoHide;

                PropertyGridDockPanel propertyGrid = (PropertyGridDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.PropertyGrid];
                propertyGrid.Visibility = DockVisibility.AutoHide;

                ToolBoxDockPanel toolBox = (ToolBoxDockPanel)rrtDT.DesignRibbonForm.DesignDockManager[DesignDockPanelType.ToolBox];
                toolBox.Visibility = DockVisibility.AutoHide;

                mdiController = rrtDT.DesignRibbonForm.DesignMdiController;
                mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

                rrtDT.ShowRibbonDesignerDialog();

                if (mdiController.ActiveDesignPanel != null)
                {
                    mdiController.ActiveDesignPanel.CloseReport();
                }

                if (coluu)
                {
                    coluu = false;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            SaveCommandHandler sch = new SaveCommandHandler(panel, rrt.Name);
            sch.GetCoLuu = new SaveCommandHandler.CoLuu(GetCoLuu);
            panel.AddCommandHandler(sch);
        }

        public void GetCoLuu(bool coluu)
        {
            this.coluu = coluu;
        }
    }

    public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
    {
        XRDesignPanel panel;
        public delegate void CoLuu(bool coluu);
        string filename = null;
        public CoLuu GetCoLuu;

        public SaveCommandHandler(XRDesignPanel panel, string filename)
        {
            this.panel = panel;
            this.filename = filename;
        }

        public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command, object[] args)
        {
            Save();
        }

        public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs || command == ReportCommand.Closing);
            return !useNextHandler;
        }

        private void Save()
        {
            try
            {
                panel.Report.SaveLayout("EditReport\\" + filename + ".repx");
                panel.ReportState = ReportState.Saved;
                GetCoLuu(true);
            }
            catch 
            {
                return;
            }
        }
    }
}
