using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Forms;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Validation;
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

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class AddingAndWithDrawing : Form
    {
        AppDataContext context = new AppDataContext();
        Currency currency;
        public AddingAndWithDrawing()
        {
            InitializeComponent();
        }
        private void btn_ShowAddCurncey_Click(object sender, EventArgs e)
        {
            frmAddCurncey frm = new frmAddCurncey();
            frm.ShowDialog();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bbtn_CurnceySave_Click(object sender, EventArgs e)
        {
            AddNewCurncey();
        }
        private void AddNewCurncey()
        {
            try
            {
                if (CheckIsNotBlank())
                {
                    XtraMessageBox.Show("قم بتعبئة جميع البيانات من فضلك");
                    return;
                }
                currency = new Currency();
                currency.Name = btxt_CurrnceyName.Text;
                currency.CurrencyCode = btxt_CurrnceyCode.Text;
                currency.Quantity = 0;
                if (!CurrencyValidation.ValidateCurrency(currency, out string errorMessage))
                {
                    XtraMessageBox.Show(errorMessage);
                    return;
                }
                context.Currency.Add(currency);
                context.SaveChanges();
                CurrnceyMang.isUpdateing = true;
                HelperMessage.DoneOpertaion(this, "تمت إضافة عملة جديدة بنجاح");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ ما الرجاء منك تصوير الخطأ والتواصل مع المبرمج \n"+ex.Message);
            }
        }

        private bool CheckIsNotBlank()
        {
            bool isNull = false;
            foreach (Control c in guna2ShadowPanel1.Controls)
            {
                if(c is BunifuTextBox textBox)
                {
                    if (String.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        textBox.BorderColorIdle = Color.Red;
                        isNull=true;
                    }
                } 
            }
            return isNull;
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyString(sender, e);
        }
    }
}
