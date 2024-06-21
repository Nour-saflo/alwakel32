using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using Al_Wakel_Pro_move_1.Services;
using Bunifu.UI.WinForms.BunifuTextbox;
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
    public partial class frmEditLoginData : XtraForm
    {
        private AppDataContext _context = new AppDataContext();
        private readonly IUserRepository _userRepo;
        private User _user;

        public frmEditLoginData()
        {
            InitializeComponent();
            _context = new AppDataContext();
            _userRepo = new UserRepository(_context);
            LoadData();
        }
        private void LoadData()
        {
            _user =   _userRepo.GetById(GlobalUser.Id);
            if (_user == null)
            {
                HelperMessage.FailerMessage("حدث خطأ ما إثناء جلب بيانات المستخدم");
                XtraMessageBox.Show("سوف يتم إطفاء البرنامج الرجاء قم بالدخول مرة أخرى");
                Application.Exit();
                return;
            }
            FialDataUser();
        }
        private void FialDataUser()
        {
            txt_UserName.Text = _user.UserName;
            btxt_Password.Text = _user.Password;
            btxt_ConfirmPassword.Text = _user.Password;
            btxt_SecoundPassword.Text = _user.PasswordForEditQuantity;
            btxt_SecoundPasswordConfirm.Text = _user.PasswordForEditQuantity;
        }

        private async void bbtn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNotNull = IsAnyFieldsEmpty();
                if (!isNotNull)
                {
                    (bool password, bool secoundPassword) = CheckIfMatch(btxt_Password.Text, btxt_ConfirmPassword.Text,
                        btxt_SecoundPassword.Text, btxt_SecoundPasswordConfirm.Text);
                    if (!password || !secoundPassword)
                    {
                        XtraMessageBox.Show("تحقق من تطابق كلمات السر");
                    }
                    else
                    {
                        UpdateUserDetails();
                        await _context.SaveChangesAsync();
                        GlobalUser.Clone(_user);
                        HelperMessage.DoneOpertaion(this,"تم تحديث بيانات المستخدم بنجاح");
                    }
                    return;
                }
                else
                {
                    XtraMessageBox.Show("لا تترك أياً من الحقول فارغة");
                }
            }
            catch (Exception ex)
            {
                HelperMessage.FailerMessage("حدث خطأ ما إثناء تحديث بيانات تسجيل الدخول.....");
            }
        }
        private void UpdateUserDetails()
        {
            _user.Password = btxt_Password.Text;
            _user.UserName = txt_UserName.Text;
            _user.PasswordForEditQuantity = btxt_SecoundPassword.Text;
            _context.Entry(_user).State = System.Data.Entity.EntityState.Modified;
        }
        private (bool password, bool secoundPassword) CheckIfMatch(string password, string confirmPassword, string secoundPassword, string SecoundPasswordConfirm)
        {
            bool checkPass = password.Equals(confirmPassword);
            bool checConfPass = secoundPassword.Equals(SecoundPasswordConfirm);
            return (checkPass, checConfPass);
        }
        private bool IsAnyFieldsEmpty()
        {
            bool result = false;
            foreach (Control control in guna2ShadowPanel1.Controls)
            {
                if (control is BunifuTextBox textBox)
                {
                    if (String.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.BorderColorIdle = Color.Red;
                        result = true;
                    }
                }
            }
            return result;
        }
        private void txt_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }
    }
}
