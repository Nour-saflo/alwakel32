using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using System.Diagnostics;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class OprationForMaine : Form
    {
        AppDataContext _context = new AppDataContext();
        Currency _selctedCurnceyFrom = null;
        Currency _selctedCurnceyTo = null;
        public OprationForMaine()
        {
            InitializeComponent();
            repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemTextEdit1.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            repositoryItemTextEdit1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            LoadAllData();
            InitSummry();
        }

        private void InitSummry()
        {
            GridView gridView2 = gridControl2.MainView as GridView;
            gridView2.Columns["Quantity"].Summary.Clear();
            GridColumnSummaryItem quantitySummaryItem = new GridColumnSummaryItem();
            quantitySummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            quantitySummaryItem.DisplayFormat = "Total: {0}";
            gridView2.Columns["Quantity"].Summary.Add(quantitySummaryItem);
            gridView2.OptionsView.ShowFooter = true;
        }

        private async void LoadAllData()
        {
            LoadCurrnceyData();
            await LoadData();
        }
        private void LoadCurrnceyData()
        {
            bbdrop_CurrnceyINBox.DataSource = _context.Currency.Where(x => (bool)!x.IsDelete).ToList();
            bbdrop_CurrnceyoutBox.DataSource = _context.Currency.Where(x => (bool)!x.IsDelete).ToList();
            NonSelectedDrop();
        }
        private async Task LoadData()
        {
            DateTime currentDate = DateTime.Now.Date;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            var currnceyOperation = await _context.CurrencyOperations.ToListAsync();
            gridControl2.DataSource = currnceyOperation.Where(x => x.OperationDate == DateTime.Now.Date);

            var currencyExchanges = await _context.CurrencyExchange.ToListAsync();

            gridControl1.DataSource = currencyExchanges
                .Where(x => x.TimeAndDate.HasValue && x.TimeAndDate.Value.ToString("yyyy-MM-dd") == formattedDate)
                .ToList();
        }
        private void NonSelectedDrop()
        {
            bbdrop_CurrnceyINBox.SelectedIndex = -1;
            bbdrop_CurrnceyoutBox.SelectedIndex = -1;
            _selctedCurnceyFrom = null;
            _selctedCurnceyTo = null;
        }
        private void ClearAndMove()
        {
            NonSelectedDrop();
            btxt_CurrnceyOutBox.Text = string.Empty;
            btxt_CurrnceyInBox.Text = string.Empty;
            txt_DooliresCurrncey.Text = string.Empty;
            navigationFrame1.SelectedPage = navigationPage1;

        }
        private async void bbtn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selctedCurnceyTo != null && _selctedCurnceyFrom != null)
                {
                    decimal quantityTo = Convert.ToDecimal(btxt_CurrnceyInBox.Text);
                    decimal quantityFrom = Convert.ToDecimal(btxt_CurrnceyOutBox.Text);
                    bool isItEnough = await ChecekIsItEnoughCurrnceyQuantity(quantityFrom, _selctedCurnceyFrom);
                    if (isItEnough)
                    {
                        decimal quantityToBefore = _selctedCurnceyTo.Quantity;
                        decimal quantityFromBefore = _selctedCurnceyFrom.Quantity;
                        _selctedCurnceyTo.Quantity = quantityToBefore + quantityTo;
                        _selctedCurnceyFrom.Quantity = quantityFromBefore - quantityFrom;
                        await UpdateQuantityCurrncey(_selctedCurnceyTo, _selctedCurnceyTo.Quantity);
                        await UpdateQuantityCurrncey(_selctedCurnceyFrom, _selctedCurnceyFrom.Quantity);
                        await AddCurrnceyExchinge(_selctedCurnceyTo, quantityTo, _selctedCurnceyFrom, quantityFrom);
                        XtraMessageBox.Show("تمت العملية بنجاح");
                        ClearAndMove();
                    }
                    else
                    {
                        XtraMessageBox.Show("المبلغ المراد تصريف منه غير كافي راجع حساباتك من فضلك");
                    }
                }
                else
                {
                    XtraMessageBox.Show("قم باختيار العملتين من فضلك");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ أثناء حفظ البيانات. الرجاء المحاولة مرة أخرى.");
            }
        }

        private async Task AddCurrnceyExchinge(Currency selctedCurnceyTo, decimal quantityTo, Currency selctedCurnceyFrom, decimal quantityFrom)
        {
            CurrencyExchange exchange = new CurrencyExchange();
            exchange.CurrencyFromId = _selctedCurnceyFrom.Id;
            exchange.CurrencyToId = _selctedCurnceyTo.Id;
            exchange.QuantityFrom = quantityFrom;
            exchange.QuantityTo = quantityTo;
            exchange.TimeAndDate = DateTime.Now;
            _context.CurrencyExchange.Add(exchange);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateQuantityCurrncey(Currency currncey, decimal newQuantity)
        {
            try
            {
                currncey.Quantity = newQuantity;
                _context.Currency.Attach(currncey);
                _context.Entry(currncey).Property(x => x.Quantity).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> ChecekIsItEnoughCurrnceyQuantity(decimal quantityFrom, Currency selctedCurnceyFrom)
        {
            try
            {
                var currncey = await _context.Currency.FirstOrDefaultAsync(i => i.Id == selctedCurnceyFrom.Id);
                return quantityFrom <= currncey.Quantity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btxt_CurrnceyTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }
        private void btxt_CurrnceyFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }

        private void bbdrop_CurrnceyTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bbdrop_CurrnceyINBox.SelectedItem != null && bbdrop_CurrnceyINBox.SelectedItem is Currency)
            {
                _selctedCurnceyTo = (Currency)bbdrop_CurrnceyINBox.SelectedItem;
            }
        }

        private void bbdrop_CurrnceyFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bbdrop_CurrnceyoutBox.SelectedItem != null && bbdrop_CurrnceyoutBox.SelectedItem is Currency)
            {
                _selctedCurnceyFrom = (Currency)bbdrop_CurrnceyoutBox.SelectedItem;
            }
        }

        private async void bbtn_Referch_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void bbdrop_CurrnceyTo_Click(object sender, EventArgs e)
        {
            if (CurrnceyMang.isUpdateing)
            {
                LoadCurrnceyData();
            }
        }

        private void bbdrop_CurrnceyFrom_Click(object sender, EventArgs e)
        {
            //if (CurrnceyMang.isUpdateing)
            //{
            //      LoadCurrnceyData();
            //}
        }

        private void OprationForMaine_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void bbtn_QuantityInBox_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_DooliresCurrncey.Text.Trim()) || bbdrop_CurrnceyINBox.SelectedItem == null)
            {
                XtraMessageBox.Show("قم باختيار العملة الداخلة وسعر الشراء.");
            }
            else
            {
                try
                {
                    decimal buyRate = 0;
                    decimal amountInDollar = 0;
                    decimal amountInLocalCurrency = 0;
                    if (String.IsNullOrEmpty(btxt_CurrnceyOutBox.Text.Trim()) || Convert.ToDecimal(btxt_CurrnceyOutBox.Text) <= 0)
                    {
                        buyRate = Convert.ToDecimal(txt_DooliresCurrncey.Text);
                        amountInDollar = Convert.ToDecimal(btxt_CurrnceyInBox.Text);
                        amountInLocalCurrency = amountInDollar * buyRate;
                        btxt_CurrnceyOutBox.Text = amountInLocalCurrency.ToString("F3");
                    }
                    else
                    {
                        buyRate = Convert.ToDecimal(txt_DooliresCurrncey.Text);
                        amountInDollar = Convert.ToDecimal(btxt_CurrnceyOutBox.Text);
                        amountInLocalCurrency = amountInDollar / buyRate;
                        btxt_CurrnceyInBox.Text = amountInLocalCurrency.ToString("F3");
                    }

                  
                }
                catch (FormatException)
                {
                    XtraMessageBox.Show("يرجى إدخال قيم صحيحة للمبلغ وسعر الشراء.");
                }
            }
        }
        private void bbtn_QuantityOutBox_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_DooliresCurrncey.Text.Trim()) || bbdrop_CurrnceyoutBox.SelectedItem == null)
            {
                XtraMessageBox.Show("قم بتعبئة العملة الخارجة وسعر البيع.");
            }
            else
            {
                try
                {
                    decimal sellRate = 0;
                    decimal amountInLira = 0;
                    decimal amountInDollar = 0;
                    if (String.IsNullOrEmpty(btxt_CurrnceyInBox.Text.Trim()) || Convert.ToDecimal(btxt_CurrnceyInBox.Text) <= 0)
                    {
                        sellRate = Convert.ToDecimal(txt_DooliresCurrncey.Text);
                        amountInLira = Convert.ToDecimal(btxt_CurrnceyOutBox.Text);
                        amountInDollar = amountInLira * sellRate;
                        btxt_CurrnceyInBox.Text = amountInDollar.ToString("F3");
                    }
                    else
                    {
                        sellRate = Convert.ToDecimal(txt_DooliresCurrncey.Text);
                        amountInLira = Convert.ToDecimal(btxt_CurrnceyInBox.Text);
                        amountInDollar = amountInLira / sellRate;
                        btxt_CurrnceyOutBox.Text = amountInDollar.ToString("F3");
                    }
                }
                catch (FormatException)
                {
                    XtraMessageBox.Show("يرجى إدخال قيم صحيحة للمبلغ وسعر البيع.");
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعذر فتح الآلة الحاسبة: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label68.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
