using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.DTO;
using Al_Wakel_Pro_move_1.Forms;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.Charts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class CustomerInformation : Form
    {
        private Customer _customer;
        private AppDataContext _context = new AppDataContext();
        public CustomerInformation(Customer selectedCustomer)
        {
            InitializeComponent();
            _customer = selectedCustomer;
            LoadInformationData(_customer);
            LoadAllData();

        }

        private async void LoadAllData()
        {
            await LoadCustomerData();
             await LoadDetaileData();
        }
        private async Task LoadDetaileData()
        {
            var currnceyPull = await GetMoneyQuantityStatusForCustomer(Enum.StatusOfFinancial.Pull);
            gridControl2.DataSource = currnceyPull;
            var currnceyPush = await GetMoneyQuantityStatusForCustomer(Enum.StatusOfFinancial.Push);
            gridControl3.DataSource = currnceyPush;
        }

        private async void bbtn_Referch_Click(object sender, EventArgs e)
        {
            var currnceyPull = await GetMoneyQuantityStatusForCustomer(Enum.StatusOfFinancial.Pull);
            gridControl2.DataSource = currnceyPull;
            (gridControl2.MainView as GridView)?.RefreshData();

            var currnceyPush = await GetMoneyQuantityStatusForCustomer(Enum.StatusOfFinancial.Push);
            gridControl3.DataSource = currnceyPush;
            (gridControl3.MainView as GridView)?.RefreshData(); // تحديث البيانات في الـ GridView
            LoadCustomerData();
        }
        public async Task<List<CurrnceyStatusDtos>> GetMoneyQuantityStatusForCustomer(Enum.StatusOfFinancial status)
        {
            var operationsGroupedByCurrency = await _context.Operation
               .Where(o => o.CustomerId == _customer.Id)
               .GroupBy(o => o.Currency.Name)
               .ToListAsync();
            var customerCurrency = operationsGroupedByCurrency.Select(group => new CurrnceyStatusDtos
            {
                CurrnceyName = group.Key,
                QuantityStatus = group
                    .Where(x => x.Name == ChangeStateFinancial.ChangeEnumFinancialToStringsFinancial(status))
                    .Sum(x => x.Quantity)
            }).ToList();
            return customerCurrency;
        }
        private async Task LoadCustomerData()
        {
            gridControl1.DataSource = await _context.Operation.Where(i => i.CustomerId == _customer.Id).ToListAsync();
        }

        private void LoadInformationData(Customer selectedCustomer)
        {
            lbl_Address.Text = _customer.Address;
            lbl_CustomerName.Text = _customer.Name;
            lbl_ProviderName.Text = _customer.ProviderName;
            lbl_IdentityNumber.Text = _customer.IdentityNumber.ToString();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void guna2CirclePictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form popupForm = new Form();
            popupForm.Width = 500;
            popupForm.Height = 500;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            using (MemoryStream ms = new MemoryStream(_customer.Image))
            {
                Image image = Image.FromStream(ms);
                pictureBox.Image = image;
            }
            popupForm.Controls.Add(pictureBox);
            popupForm.ShowDialog();
        }




        private void bbtn_GetQuantityCurrncey_Click(object sender, EventArgs e)
        {
            frmGetCurrnceyQuantity frmGetCurrnceyQuantity = new frmGetCurrnceyQuantity(_customer);
            frmGetCurrnceyQuantity.ShowDialog();
        }

        private void bbtn_SetQuantityCurrncey_Click(object sender, EventArgs e)
        {
            frmSetCurrnceyQuantity frmSetCurrnceyQuantity = new frmSetCurrnceyQuantity(_customer);
            frmSetCurrnceyQuantity.ShowDialog();
        }

        private void bbtn_ExportToExcel_Click(object sender, EventArgs e)
        {
            string defaultFileName = "كشف حساب العميل " + _customer.Name;
            string filePath = ExportData.GetSaveFilePath(defaultFileName);

            if (filePath != null)
            {
                ExportData.ExportToExcel(filePath, gridControl1);
                MessageBox.Show("تم تصدير الكشف بنجاح");
            }
            else
            {
                XtraMessageBox.Show("قم بإختيار مسار صحيح");
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                frmConfirmPass frmConfirmPass = new frmConfirmPass(this);
                frmConfirmPass.ShowDialog();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbl_CustomerName_Click(object sender, EventArgs e)
        {

        }

        private async void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            CultureInfo en = CultureInfo.GetCultureInfo("en-Us");
            string op1 = "";
            string op2 = "";
            string headerMsg = " السلام عليكم ورحمة الله وبركاته";
            string comapnyName = "مطابقة الأرصدة- شركة : 🏢 " + GlobalUser.CompanyName;
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " : " +
                DateTime.Now.ToString("HH-mm", CultureInfo.InvariantCulture) + " " +
                    "تاريخ المطابقة ... ⏳  ";
            string footerMsg = "يرجى الرد على المطابقة وتأكيدها \n" + " مع فائق الاحترام والتقدير";

            var additionSums = await _context.Operation
                .Where(cc => cc.Name.Equals("إضافة") && cc.CustomerId == _customer.Id)
                .GroupBy(cc => cc.Currency)
                .Select(group => new { Currency = group.Key, TotalQuantity = group.Sum(q => q.Quantity),currnceyAddtionId=group.Key.Id })
                .ToListAsync();
            var additionSummary = new StringBuilder();
            foreach (var sum in additionSums)
            {
                additionSummary.AppendLine($"إجمالي لنا بالعملة {sum.Currency.Name}: {sum.TotalQuantity}");
            }

            var receiptSums = await _context.Operation
                .Where(cc => cc.Name.Equals("قبض") && cc.CustomerId == _customer.Id)
                .GroupBy(cc => cc.Currency)
                .Select(group => new { Currency = group.Key, TotalQuantity = group.Sum(q => q.Quantity) })
                .ToListAsync();
            var matchedCurrencies = additionSums.Join(receiptSums,
                add => add.Currency,
                rec => rec.Currency,
                (add, rec) => new
                {
                    Currency = add.Currency,
                    Difference = add.TotalQuantity - rec.TotalQuantity 
                }).ToList();


            var unmatchedReceiptCurrencies = receiptSums.Where(rec => !additionSums.Any(add => add.Currency == rec.Currency))
             .Select(rec => new
                {
                 Currency = rec.Currency,
                 ReceiptSum = rec.TotalQuantity  // Add a negative sign if the value is negative
             }).ToList();


            foreach (var sum in matchedCurrencies)
            {
                if (sum.Difference > 0)
                {
                    op2 = op2 + "\n" + $"إجمالي لنا بالعملة {sum.Currency.Name}: {sum.Difference}";
                }
                
                else if(sum.Difference<0)
                {
                    op2 = op2 + "\n" + $"إجمالي له بالعملة {sum.Currency.Name}: {sum.Difference*-1}";
                }
                else
                {

                }
            }

            //foreach (var sum in unmatchedReceiptCurrencies)
            //{
            //    if (sum.ReceiptSum != 0)
            //    {
            //        op2 = op2 + "\n" + $"إجمالي له بالعملة {sum.Currency.Name}: {sum.ReceiptSum}";
            //    }
            //}

            string combinedText = headerMsg + "\n" +
                "\n" +
                comapnyName
                + "\n" +
                dateTime
                + op1
                 + "\n"
                + "\n"
                + "----------------------------------------"
                + op2
                + "\n"
                + "----------------------------------------"
                + "\n"
                + footerMsg;

            XtraMessageBox.Show(combinedText);
            var clpiord = XtraMessageBox.Show("تم وضع الرسالة في الحافظة \n بعد فتح رقم الوتس أب من فضلك من لوحة المفاتيح \n ctrl + v اضغط على  \nاذا كنت موافق اضغط على نعم", "خدمة", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (clpiord == DialogResult.Yes)
            {

                System.Windows.Forms.Clipboard.SetText(combinedText);

                string whatsappNumber = $"{_customer.PhoneNumber}";
                string whatsappUrl = "https://wa.me/" + whatsappNumber;
                try
                {
                    Process.Start(whatsappUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to open WhatsApp: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
