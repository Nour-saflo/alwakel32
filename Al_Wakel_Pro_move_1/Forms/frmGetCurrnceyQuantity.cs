using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityState = System.Data.Entity.EntityState;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmGetCurrnceyQuantity : DevExpress.XtraEditors.XtraForm
    {
        private readonly Customer _customer;
        private AppDataContext _context = new AppDataContext();
        private Currency _currency = null;
        public frmGetCurrnceyQuantity(Model.Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadData();
        }
        private void LoadData()
        {
            drop_Curncey.DataSource = _context.Currency.Where(x=>!(bool)x.IsDelete).ToList();
            drop_Curncey.SelectedIndex = -1;
            _currency = null;
        }
        private void btxt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.AcceptOnlyNumbers(sender, e);
        }

        private void drop_Curncey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_Curncey.SelectedItem != null && drop_Curncey.SelectedItem is Currency)
            {
                _currency = (Currency)drop_Curncey.SelectedItem;
            }
        }
        private async void bbtn_GetQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currency != null && !String.IsNullOrEmpty(btxt_Quantity.Text))
                {
                    decimal quantity = Convert.ToDecimal(btxt_Quantity.Text);
                    //(bool isEnogh, decimal sumQuatnty) = await CheckSumQuantityForCustomer(quantity);
                    //if (isEnogh)
                    //{
                        await UpdateQuantity(_currency, quantity);
                        await AddOperation();
                        HelperMessage.DoneOpertaion(this, "تم استرجاع المبلغ من العميل : " + " " + _customer.Name + " بنجاح");
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("إجمالي المبلغ المترتب على العميل هو : " + sumQuatnty + " " + _currency.CurrencyCode + "\n" + "المبلغ المدخل أو المراد استيلامه أكبر  راجع حساباتك من فضلك");
                    //}
                }
                else
                {
                    XtraMessageBox.Show("قم بتعبئة كل البيانات من فضلك");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدثت مشكلة ما اثناء الايداع");
            }
        }
        private async Task AddOperation()
        {
            Operation operation = new Operation()
            {
                CurrencyID = _currency.Id,
                Quantity = Convert.ToDecimal(btxt_Quantity.Text),
                DateHis = DateTime.Now,
                CustomerId = _customer.Id,
                Name = ChangeStateFinancial.ChangeEnumFinancialToStringsFinancial(Enum.StatusOfFinancial.Pull),
                UserId = GlobalUser.Id,
            };
            _context.Operation.Add(operation);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateQuantity(Currency currncey, decimal quantity)
        {
            currncey.Quantity = _currency.Quantity + quantity;
            _context.Entry(currncey).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private async Task<(bool, decimal)> CheckSumQuantityForCustomer(decimal quantity)
        {
            var operations = await _context.Operation
                    .Where(x => x.CustomerId == _customer.Id && x.CurrencyID == _currency.Id)
                    .ToListAsync();

            decimal sumQuantityForCustomerPush = operations
                .Where(x => ChangeStateFinancial.ChangeStringFinancialToEnumsFinancial(x.Name) == Enum.StatusOfFinancial.Push)
                .Sum(x => x.Quantity);

            decimal sumQuantityForCustomerPull = operations
                .Where(x => ChangeStateFinancial.ChangeStringFinancialToEnumsFinancial(x.Name) == Enum.StatusOfFinancial.Pull)
                .Sum(x => x.Quantity);
            decimal result = sumQuantityForCustomerPush - sumQuantityForCustomerPull;
            return (result >= quantity, result);
        }
        private void drop_Curncey_Click(object sender, EventArgs e)
        {
            if (CurrnceyMang.isUpdateing)
            {
                LoadData();
            }
        }
    }
}