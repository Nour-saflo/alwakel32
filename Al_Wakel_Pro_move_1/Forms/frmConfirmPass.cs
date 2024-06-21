using Al_Wakel_Pro_move_1.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmConfirmPass : DevExpress.XtraEditors.XtraForm
    {
        public static bool isConfirmPass = false;
        AppDataContext _context = new AppDataContext();
        private Form _from;

        public frmConfirmPass(Form form)
        {
            _from = form;
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void frmConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Verfiy_Click(sender, e);
            }
        }
        private void btn_Verfiy_Click(object sender, EventArgs e)
        {
            var x = _context.User.Select(ccc => ccc.PasswordForEditQuantity).FirstOrDefault();
            if (!x.Equals(txt_Password.Text))
            {
                isConfirmPass = false;
                this.Close();
                _from.Close();
            }
            else
            {
                isConfirmPass = true;
                this.Close();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            isConfirmPass = false;
            this.Close();
        }
    }
}