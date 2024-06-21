using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.XtraEditors;
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
using EntityState = System.Data.Entity.EntityState;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmSetCurrnceyQuantity : DevExpress.XtraEditors.XtraForm
    {
        private readonly Customer _customer;
        private Currency _currncey;
        private AppDataContext _context = new AppDataContext();
        public frmSetCurrnceyQuantity(Model.Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadCurrnceyData();
        }

        private void LoadCurrnceyData()
        {
            drop_Curncey.DataSource=_context.Currency.Where(x => !(bool)x.IsDelete).ToList();
            drop_Curncey.SelectedIndex = -1;
            _currncey = null;
        }

        private async void bbtn_SetQuantity_Click(object sender, EventArgs e)
        {
            if(_currncey != null && !String.IsNullOrEmpty(btxt_Quantity.Text))
            {
              decimal quantity=Convert.ToDecimal(btxt_Quantity.Text);
              bool isEngoh=await  CheckIsEngohQuantity(_currncey.Id, quantity);
                if (isEngoh)
                {
                    await UpdateQuantity(_currncey, quantity);
                    await AddNewOperation(_currncey, quantity);
                    HelperMessage.DoneOpertaion(this, "تم أيدع المبلغ ينجاح");
                }
                else
                {
                    XtraMessageBox.Show("المبلغ المراد إعطائه للزبون هو اكبر من الموجود رجاءاً قم بتغيير القيمة \nأو إضافة مبلغ إلى الصندوق");
                }

            }
            else
            {
                XtraMessageBox.Show("قم بتعبئة جميع البينات المطلوبة");
            }
        }

        private async Task AddNewOperation(Currency currncey, decimal quantity)
        {
            Operation operation = new Operation()
            {
                Quantity= Convert.ToDecimal( btxt_Quantity.Text),
                CustomerId= _customer.Id,
                Name= ChangeStateFinancial.ChangeEnumFinancialToStringsFinancial(Enum.StatusOfFinancial.Push),
                CurrencyID= currncey.Id,
                DateHis=DateTime.Now,
               UserId = GlobalUser.Id,
            };
            _context.Operation.Add(operation);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateQuantity(Currency currncey, decimal quantity)
        {
            currncey.Quantity = currncey.Quantity-quantity;
            _context.Entry(currncey).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CheckIsEngohQuantity(int currnceyId, decimal quantity)
        {
            decimal quantityInCurrncey=await _context.Currency
                                .Where(x=>x.Id==currnceyId)
                                .Select(x=>x.Quantity)
                                .FirstOrDefaultAsync();
            return quantityInCurrncey >= quantity;
        }

        private void btxt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }

        private void drop_Curncey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(drop_Curncey.SelectedItem !=null && drop_Curncey.SelectedItem is Currency)
            {
                _currncey = (Currency)drop_Curncey.SelectedItem;
            }
        }

        private void drop_Curncey_Click(object sender, EventArgs e)
        {
            if (CurrnceyMang.isUpdateing)
            {
                LoadCurrnceyData();
            }
        }
    }
}