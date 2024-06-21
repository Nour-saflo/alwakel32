using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Bunifu.UI.WinForms.BunifuTextbox;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.login
{
    public partial class frmLogin : XtraForm
    {
        public bool IsSuccess;
        public static bool isLogin = false;
        AppDataContext _contex = new AppDataContext();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            bool check = CheckTxtIsNotNull();
            string password = btxt_PassWord.Text;
            string userName = btxt_UserName.Text;
            if (check)
            {
                User user = _contex.User.FirstOrDefault(x => x.Password.Equals(password) && x.UserName.Equals(userName) &&(bool) x.IsActive);
                if (user != null)
                {
                    GlobalUser.Clone(user);
                    isLogin = true;
                    HelperMessage.DoneOpertaion(this, "تم تسجيل الدخول بنجاح");
                }
                else
                {
                    XtraMessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحات");
                }
            }
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckTxtIsNotNull()
        {
            bool isNotNUll = true;
            foreach (Control control in guna2ShadowPanel3.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.BorderColor = Color.Red;
                        isNotNUll = false;
                    }
                }
            }
            if (!isNotNUll)
            {
                XtraMessageBox.Show("قم بملئ جميع الحقول");
            }
            return isNotNUll;

        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }
    }
}
