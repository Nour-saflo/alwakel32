using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Resourse;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class frmCustmer : Form
    {
        private byte[] image;
        private Customer _customer;
        private readonly string _tag;
        AppDataContext context = new AppDataContext();
        public frmCustmer(Customer customer, string tag)
        {
            InitializeComponent();
            _customer = customer;
            _tag = tag;
            if (_tag == TagResourse.EditCustomer)
            {
                UpdateCustomerInfo();
            }
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void bbtn_Save_Click(object sender, EventArgs e)
        {
            if (_tag == TagResourse.AddCustomer)
                AddNewCustomer();
            else if (_tag == TagResourse.EditCustomer)
            {
                _customer.Address = btxt_Address.Text;
                _customer.IdentityNumber = Convert.ToInt32(btxt_IdenttityNumber.Text);
                _customer.Name = btxt_CustomerName.Text;
                _customer.ProviderName = btxt_ProviderName.Text;
                _customer.Image = image;
                _customer.PhoneNumber = btxt_PhoneNumber.Text;
                _customer.UserId = _customer.UserId;
                context.Entry(_customer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("العملية غير معروفة");
            }
        }
        private void UpdateCustomerInfo()
        {
            btxt_CustomerName.Enabled = false;
            btxt_ProviderName.Enabled = false;
            bbtn_UploadImage.Enabled = false;
            btxt_IdenttityNumber.Enabled = false;
            btxt_Address.Text = _customer.Address;
            btxt_IdenttityNumber.Text = _customer.IdentityNumber.ToString();
            btxt_CustomerName.Text = _customer.Name;
            btxt_ProviderName.Text = _customer.ProviderName;
            image = _customer.Image;
            btxt_PhoneNumber.Text = _customer.PhoneNumber;
        }
        private void AddNewCustomer()
        {
            try
            {
                _customer.Address = btxt_Address.Text;
                _customer.IdentityNumber = Convert.ToInt32(btxt_IdenttityNumber.Text);
                _customer.Name = btxt_CustomerName.Text;
                _customer.ProviderName = btxt_ProviderName.Text;
                _customer.Image = image;
                _customer.PhoneNumber = btxt_PhoneNumber.Text;
                _customer.UserId = GlobalUser.Id;
                context.Customer.Add(_customer);
                HelperMessage.DoneOpertaion(this, "تم إدراج عميل بنجاح");
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }
        private void bbtn_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the binary data of the selected file into the image property
                image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        private void btxt_PhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyPhoneNumber(sender, e);
        }
    }
}
