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
    public partial class frmAddCurncey : DevExpress.XtraEditors.XtraForm
    {
        AppDataContext context= new AppDataContext();
        public frmAddCurncey()
        {
            InitializeComponent();
        }

        private void btn_AddCurncey_Click(object sender, EventArgs e)
        {
            try
            {
                Currency currency = new Currency() { Name = txt_CurnceyName.Text };
                context.Currency.Add(currency);
                context.SaveChanges();
                XtraMessageBox.Show("تمت إضافة عملة جديدة" );
                this.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ ما في عملية إدراج العملة"+ex.Message);
            }
        }
    }
}