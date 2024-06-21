using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Core
{
    public class HelperMessage
    {
        public static void DoneOpertaion(Form form, string message)
        {
            XtraMessageBox.Show(message);
            form.Close();
        }
        public static void FailerMessage(string message)
        {
            XtraMessageBox.Show(message, "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
