using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Resourse;
using Bunifu.UI.WinForms.BunifuTextbox;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmCreateAccount : DevExpress.XtraEditors.XtraForm
    {
        AppDataContext _context = new AppDataContext();
        bool isHidePassword = true;
        bool isHideConfirmPassword = true;
        private byte[] _image;
        private readonly Model.User _user;

        public frmCreateAccount(Model.User user)
        {
            InitializeComponent();
            _user = user;
        }



        private async void bbtn_Save_Click(object sender, EventArgs e)
        {
            bool isMatch = MatchPassword(btxt_Password.Text, btxt_confirmPassword.Text);
            if (!isMatch)
            {
                XtraMessageBox.Show("كلمات السر غير متطابقة");
                return;
            }
            if (CheckIsNull())
            {
                XtraMessageBox.Show("يوجد حقول فارغة");
                return;
            }
            try
            {
                if (!await IsExsits(btxt_UserName.Text))
                {
                    if (_image is null)
                    {
                        XtraMessageBox.Show("قم برفع صورة شعار الصراف");
                        return;
                    }
                    AddNewUser();
                    XtraMessageBox.Show("تمت إضافة حساب بنجاح");
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("اسم المستخدم هذا موجود قم بتغيير اسم المستخدم");
                    btxt_UserName.Text = "";
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ ما اثناء إنشاء الحساب الرجاء المحاولة مرة اخرى");
            }
        }
   
        private async void AddNewUser()
        {
            int lastId = GetLastId();
            Model.User newUser = new Model.User();
            newUser.Id = ++lastId;
            newUser.Age = Convert.ToInt32(btxt_Age.Text);
            newUser.Email = "defualt@gmail.com";
            newUser.Name = btxt_Name.Text;
            newUser.Image = _image;
            newUser.PasswordForEditQuantity = "asdfghjkl;qwertyuiop[zxc";
            newUser.Role = "user";
            newUser.Password = btxt_Password.Text;
            newUser.Address = _user.Address;
            newUser.PhoneNumber = btxt_Number.Text;
            newUser.CurrnceyName = _user.CurrnceyName;
            newUser.UserName = btxt_UserName.Text;
            newUser.IsActive = (bool)active.EditValue;
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
        }
        private async Task<bool> IsExsits(string userName)
        {
            return await _context.User.AnyAsync(x => x.UserName.Equals(userName));
        }

        private bool CheckIsNull()
        {
            var result = false;
            foreach (Control control in guna2ShadowPanel1.Controls)
            {
                if (control is BunifuTextBox bunifuTextBox)
                {
                    if (string.IsNullOrEmpty(bunifuTextBox.Text))
                    {
                        bunifuTextBox.BorderColorIdle = Color.Red;  
                        result= true;
                    }
                }
            }
            return result;
        }
        private bool MatchPassword(string text1, string text2)
        {
            return text1.Equals(text2);
        }
        private void btxt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }
        private void btxt_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }
        private void btxt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }
        private void lbl_password_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(btxt_Password, ref isHidePassword);
        }
        private void lbl_ConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(btxt_confirmPassword, ref isHideConfirmPassword);
        }
        private void TogglePasswordVisibility(BunifuTextBox textBox, ref bool isHidden)
        {
            isHidden = !isHidden;
            if (isHidePassword)
            {
                textBox.PasswordChar = '*';
            }
            else
            {
                textBox.PasswordChar = '\0';
            }
        }
        private int GetLastId()
        {
            return _context.User.Max(x => x.Id);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the binary data of the selected file into the image property
                _image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
    }
}