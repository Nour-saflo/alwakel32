using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Bunifu.UI.WinForms.BunifuTextbox;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class EditUSer : DevExpress.XtraEditors.XtraForm
    {
        private byte[] _image;
        Model.User _userUpdate;
        AppDataContext _context;
        public EditUSer(Model.User userUpdate)
        {
            InitializeComponent();
            _context = new AppDataContext();
            _userUpdate=userUpdate;
            FillUserData();
        }
        private void FillUserData()
        {
            btxt_Age.Text = _userUpdate.Age.ToString();
            btxt_Name.Text = _userUpdate.Name;
            _image = _userUpdate.Image;
            btxt_Password.Text = _userUpdate.Password;
            btxt_confirmPassword.Text = _userUpdate.Password;
            btxt_Number.Text = _userUpdate.PhoneNumber.ToString();
            btxt_UserName.Text = _userUpdate.UserName;
            active.EditValue = _userUpdate.IsActive;
        }
        private async Task UpdateUser()
        {
            try
            {
                _userUpdate.Age = Convert.ToInt32(btxt_Age.Text);
                _userUpdate.Email = "defualt@gmail.com";
                _userUpdate.Name = btxt_Name.Text;
                _userUpdate.Image = _image;
                _userUpdate.PasswordForEditQuantity = "asdfghjkl;qwertyuiop[zxc";
                _userUpdate.Role = "user";
                _userUpdate.Password = btxt_Password.Text;
                _userUpdate.Address = _userUpdate.Address;
                _userUpdate.PhoneNumber = btxt_Number.Text;
                _userUpdate.CurrnceyName = _userUpdate.CurrnceyName;
                _userUpdate.UserName = btxt_UserName.Text;
                _userUpdate.IsActive = (bool)active.EditValue;
                _context.Entry(_userUpdate).State = System.Data.Entity.EntityState.Modified;
                await _context.SaveChangesAsync();
                HelperMessage.DoneOpertaion(this, "تم تحديث بيانات المستخدم بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث بيانات المستخدم: {ex.Message}");
            }
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
        private async void bbtn_Save_Click(object sender, EventArgs e)
        {
            try
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
                if (!await IsExsits(btxt_UserName.Text))
                {
                    if (_image is null)
                    {
                        XtraMessageBox.Show("قم برفع صورة شعار الصراف");
                        return;
                    }
                   await UpdateUser();
                    HelperMessage.DoneOpertaion(this,"تم تحديث بيانات المتسخدم بنجاح");
                }
                else
                {
                    XtraMessageBox.Show("اسم المستخدم هذا موجود قم بتغيير اسم المستخدم");
                    btxt_UserName.Text = "";
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ ما اثناء تعديل الحساب الرجاء المحاولة مرة اخرى");
            }
        }
        private async Task<bool> IsExsits(string userName)
        {
            var c1 = userName != _userUpdate.UserName;
            var c2 = await _context.User.AnyAsync(x => x.UserName.Equals(userName));
            return (c1&&c2) ;
        }
        private bool CheckIsNull()
        {
            foreach (Control control in guna2ShadowPanel1.Controls)
            {
                if (control is BunifuTextBox bunifuTextBox)
                {
                    if (string.IsNullOrEmpty(bunifuTextBox.Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool MatchPassword(string text1, string text2)
        {
            return text1.Equals(text2);
        }
    }
}