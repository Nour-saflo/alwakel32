using Al_Wakel_Pro_move_1.login;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
               var settings = Properties.Settings.Default;
                settings.startDate = default(DateTime);
                settings.endDate = default(DateTime);
                settings.Save();
   

                //dont stop this
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Show an error message if an unexpected error occurs
                XtraMessageBox.Show("حدث خطأ غير متوقع: " + ex.Message);
                Application.Exit();
            }
        }

    }
}

