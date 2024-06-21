using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Resourse;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmMainCustomerAcount : DevExpress.XtraEditors.XtraForm
    {
        AppDataContext context;
        private byte[] image;
        Customer _customer;
        string _tag;
        public frmMainCustomerAcount(Customer customer, string tag)
        {
            InitializeComponent();
            _customer = customer;
            _tag = tag;
            context = new AppDataContext();
        }



        private void btn_UploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the binary data of the selected file into the image property
                image = File.ReadAllBytes(openFileDialog.FileName);
                using (MemoryStream memoryStream = new MemoryStream(image))
                {
                    // Create a new Bitmap from the MemoryStream
                    Bitmap bitmap = new Bitmap(memoryStream);

                    // Set the PictureBox SizeMode to Zoom
                    piB_IdentityImage.SizeMode = PictureBoxSizeMode.Zoom;

                    // Assign the bitmap to the Image property of the PictureBox
                    piB_IdentityImage.Image = bitmap;
                }
            }
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if(_tag==TagResourse.AddCustomer)
                    AddNewCustomer();
                else if(_tag==TagResourse.EditCustomer) 
                    EditCustomer();
                 

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ ما اعد المحاولة لاحقاً او تواصل مع المبرمج مع تصوير الخطأ \n" + ex.Message);
            }

        }

        private void EditCustomer()
        {

        }

        private void AddNewCustomer()
        {
            _customer.Address = txt_CustomerAddress.Text;
            _customer.IdentityNumber = Convert.ToInt32(txt_IdentityNumber.Text);
            _customer.Name = txt_CustomerName.Text;
            _customer.ProviderName = txt_ProviderName.Text;
            _customer.Image = image;
            _customer.UserId = GlobalUser.Id;
            context.Customer.Add(_customer);
            context.SaveChanges();
            XtraMessageBox.Show("تم إدراج عميل بنجاح");
            this.Close();
        }
    }
}