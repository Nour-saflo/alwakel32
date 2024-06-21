using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class Report : Form
    {
        AppDataContext _context = new AppDataContext();
        GridControl gridControl = null;
        public Report()
        {
            InitializeComponent();
            this.Load += Report_Load;
        }

        private async void bbtn_ExchangeCurrncey_Click(object sender, EventArgs e)
        {
            await LoadCurrnceyOperation();
            navigationFrame1.SelectedPage = navigationPage1;
            gridControl = gridControl1;
        }

        private async Task LoadCurrnceyOperation()
        {
            gridControl1.DataSource = await _context.CurrencyExchange.ToListAsync();
        }

        private async void bbtn_OperationCurrncey_Click(object sender, EventArgs e)
        {
            await LoadCustomerCurrnceyOperation();
            navigationFrame1.SelectedPage = navigationPage2;
            gridControl = gridControl2;
        }

        private async Task LoadCustomerCurrnceyOperation()
        {
            gridControl2.DataSource=await _context.Operation.ToListAsync();
        }

        private async void bbtn_CurrnceyBoxOpertaion_Click(object sender, EventArgs e)
        {
            await LoadCurrnceyBoxDataOperation();
            navigationFrame1.SelectedPage = navigationPage3;
            gridControl = gridControl3;
        }

        private async Task LoadCurrnceyBoxDataOperation()
        {
            gridControl3.DataSource=await _context.CurrencyOperations.ToListAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string defaultFileName = "كشف تقرير";
            string filePath = ExportData.GetSaveFilePath(defaultFileName);

            if (filePath != null)
            {
                ExportData.ExportToExcel(filePath, gridControl);
                MessageBox.Show("تم تصدير الكشف بنجاح");
            }
            else
            {
                XtraMessageBox.Show("قم بإختيار مسار صحيح");
            }
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            await LoadCurrnceyOperation();
            await LoadCustomerCurrnceyOperation();
            await LoadCurrnceyBoxDataOperation();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            bbtn_CurrnceyBoxOpertaion_Click(null, new EventArgs());
        }
    }
}
