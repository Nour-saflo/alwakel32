using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Forms;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using Al_Wakel_Pro_move_1.Resourse;
using Al_Wakel_Pro_move_1.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class Setting : XtraForm
    {
        private Currency _selectedCurrency;
        private readonly AppDataContext _context;
        private readonly ICurrnceyOperationRepository _currnceyOperationRepository;
        private readonly IUserRepository _userRepository;
        private byte[] _image;
        private User _user;

        public Setting()
        {
            InitializeComponent();
            _context = new AppDataContext();
            _currnceyOperationRepository = new CurrnceyOperationRepository(_context);
            _userRepository = new UserRepository(_context);
            LoadAllData();

        }

        private async void LoadAllData()
        {
            await LoadDate();
            IsAllowed();
        }
        public async Task LoadDate()
        {
            try
            {
                drop_Curncey.DataSource = await _context.Currency.Where(x => (bool)!x.IsDelete).ToListAsync();
                drop_Curncey.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating currency data: " + ex.Message);
            }
        }
        private void IsAllowed()
        {
            if (GlobalUser.Role.Equals("admin"))
            {
                LoadUserData();
            }
            else
            {
                guna2ShadowPanel1.Enabled = false;
                guna2ShadowPanel1.Visible = false;
            }
        }

        private void LoadUserData()
        {
            btxt_Address.Text = GlobalUser.Address;
            btxt_Number.Text = GlobalUser.PhoneNumber.ToString();
            btxt_Name.Text = GlobalUser.Name;
            btxt_CpmapnyName.Text = GlobalUser.CompanyName;
            txt_UserName.Text = GlobalUser.UserName;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            AddingAndWithDrawing bb = new AddingAndWithDrawing();
            bb.Show();

        }
        private void bunifuTextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }
        private async void bbtn_SetQuantity_Click(object sender, EventArgs e)
        {
            if (drop_Curncey.SelectedItem != null && drop_Curncey.SelectedItem is Currency)
            {
                _selectedCurrency = (Currency)drop_Curncey.SelectedItem;
                decimal previousQuantity = await CurrnceyQuantity(_selectedCurrency.Id);
                decimal addationQuantity = Convert.ToDecimal(btxt_Quantity.Text);
                _selectedCurrency.Quantity = previousQuantity + addationQuantity;
                try
                {
                    await UpdateQuantity(_selectedCurrency, _selectedCurrency.Quantity);
                    await _currnceyOperationRepository.AddNewOperationCurrnceyAsync(CreateCurrencyOperations("إدراج مبلغ", addationQuantity));
                    XtraMessageBox.Show("تم تحديث الكمية بنجاح");
                    ClearData();
                }
                catch (Exception ex)
                {
                    _selectedCurrency.Quantity = previousQuantity;
                    await UpdateQuantity(_selectedCurrency, _selectedCurrency.Quantity);
                    XtraMessageBox.Show("حدث خطأ أثناء تحديث الكمية: " + ex.Message);
                    ClearData();
                }
            }
            else
            {
                XtraMessageBox.Show("رجاءاً قم بأختيار عملة لكي يتم الإضافة لها");
            }
        }
        private async Task<decimal> CurrnceyQuantity(int id)
        {
            return await _context.Currency.Where(i => i.Id == id).Select(q => q.Quantity).FirstOrDefaultAsync();
        }
        private async Task UpdateQuantity(Currency selectedCurrency, decimal quantity)
        {
            _context.Currency.Attach(selectedCurrency);
            _context.Entry(selectedCurrency).State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private CurrencyOperations CreateCurrencyOperations(string operationType, decimal quantity)
        {
            return new CurrencyOperations()
            {
                CurrencyId = _selectedCurrency.Id,
                OperationsType = operationType,
                OperationDate = DateTime.Now,
                Quantity = quantity,
                UserId = GlobalUser.Id,
            };
        }
        private async void bbtn_GetQuantity_Click(object sender, EventArgs e)
        {
            if (drop_Curncey.SelectedItem != null && drop_Curncey.SelectedItem is Currency)
            {
                _selectedCurrency = (Currency)drop_Curncey.SelectedItem;
                decimal previousQuantity = await CurrnceyQuantity(_selectedCurrency.Id);
                decimal subtractionQuantity = Convert.ToDecimal(btxt_Quantity.Text);

                if (previousQuantity >= subtractionQuantity)
                {
                    _selectedCurrency.Quantity = previousQuantity - subtractionQuantity;
                    try
                    {
                        await UpdateQuantity(_selectedCurrency, _selectedCurrency.Quantity);
                        await _currnceyOperationRepository.AddNewOperationCurrnceyAsync(CreateCurrencyOperations("سحب مبلغ", subtractionQuantity));
                        XtraMessageBox.Show("تم تحديث الكمية بنجاح");
                    }
                    catch (Exception ex)
                    {
                        _selectedCurrency.Quantity = previousQuantity;
                        await UpdateQuantity(_selectedCurrency, _selectedCurrency.Quantity);
                        XtraMessageBox.Show("حدث خطأ أثناء تحديث الكمية: " + ex.Message);
                        ClearData();
                    }
                }
                else
                {
                    XtraMessageBox.Show("المبلغ المراد سحبه اكبر من المبلغ الموجود");
                }
                ClearData();
            }
            else
            {
                XtraMessageBox.Show("رجاءاً قم بأختيار عملة لكي يتم السحب منها");
            }
        }
        private void ClearData()
        {
            _selectedCurrency = null;
            drop_Curncey.SelectedIndex = -1;
            btxt_Quantity.Text = string.Empty;
        }

        private void bbtn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        private async void bbtn_Save_Click(object sender, EventArgs e)
        {
            bool isNull = CheckIsNull();
            User user = await _context.User.Where(x => x.Id == GlobalUser.Id).FirstOrDefaultAsync();
            if (!isNull)
            {
                try
                {
                    user.Id = GlobalUser.Id;
                    user.UserName = user.UserName;
                    user.Password = user.Password;
                    user.Address = btxt_Address.Text;
                    user.Email = "defualt@gmail.com";
                    user.Age = 33;
                    user.PhoneNumber = btxt_Number.Text;
                    user.Image = _image;
                    user.Name = btxt_Name.Text;
                    user.CurrnceyName = btxt_CpmapnyName.Text;
                    _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    XtraMessageBox.Show("تم حفظ التغيرات");
                    GlobalUser.Clone(user);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("حدث خطأ ما اثناء تحديث بيانات المستخدم");
                }
            }
            else
            {
                XtraMessageBox.Show("قم بتعبئة جيمع البيانات من فضلك");
            }
        }
        private bool CheckIsNull()
        {

            return (String.IsNullOrEmpty(btxt_Address.Text)
                || String.IsNullOrEmpty(btxt_CpmapnyName.Text)
                || String.IsNullOrEmpty(btxt_Name.Text)
                || String.IsNullOrEmpty(btxt_Number.Text));
        }

        private void btxt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }

        private void btxt_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }

        private void btxt_CpmapnyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }

        private void btxt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyPhoneNumber(sender, e);
        }
        private void bbtn_CreateAccount_Click(object sender, EventArgs e)
        {
            frmConfirmPass confirmPass = new frmConfirmPass(this);
            confirmPass.ShowDialog();
            if (frmConfirmPass.isConfirmPass)
            {
                _user =   _userRepository.GetById(GlobalUser.Id);
                frmCreateAccount frmCreate = new frmCreateAccount(_user);
                frmCreate.ShowDialog();
            }
        }
        private void btn_BackUp_Click(object sender, EventArgs e)
        {
            string backupFilePath = BackUpDataBase.GetBackupFilePath();
            if (!string.IsNullOrEmpty(backupFilePath))
            {
                try
                {
                    string connectionString = "data source=.;initial catalog=Alwakel;integrated security=True;MultipleActiveResultSets=True;";
                    BackUpDataBase.BackupDatabase(connectionString, backupFilePath);
                    MessageBox.Show("Backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Clipboard.SetText(ex.ToString());
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Backup canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbtn_EditLoginData_Click(object sender, EventArgs e)
        {
            frmConfirmPass confirmPass = new frmConfirmPass(this);
            confirmPass.ShowDialog();
            if (frmConfirmPass.isConfirmPass)
            {

                frmEditLoginData frmEditLogin = new frmEditLoginData();
                frmEditLogin.ShowDialog();
            }
        }
        private async void drop_Curncey_Click(object sender, EventArgs e)
        {
            if (CurrnceyMang.isUpdateing)
            {
                await LoadDate();
            }
        }

        private void btn_MangerAccount_Click(object sender, EventArgs e)
        {
            frmConfirmPass confirmPass = new frmConfirmPass(this);
            confirmPass.ShowDialog();
            if (frmConfirmPass.isConfirmPass)
            {

                FrmMangerAccount frmManger = new FrmMangerAccount();
                frmManger.ShowDialog();
            }
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drop_Curncey_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btxt_Address_TextChanged(object sender, EventArgs e)
        {
        }
        private void bbtn_MangCurrncey(object sender, EventArgs e)
        {
            frmMangerCurrncey frmManger= new frmMangerCurrncey();
            frmManger.ShowDialog();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
        }
    }
}
