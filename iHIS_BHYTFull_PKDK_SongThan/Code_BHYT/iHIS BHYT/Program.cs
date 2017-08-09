using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace Ps.Clinic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                UserLookAndFeel.Default.SetSkinStyle("Seven");
                //Application.Run(new Security.frmStartupiHIS());
                //Application.Run(new Security.frmStartupiHIS_BD_BachDang());
                Application.Run(new Security.frmStartupiHIS_BD_SongThan());
             //   Application.Run(new Security.frmStartupiHIS_BD_SongThan());
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}