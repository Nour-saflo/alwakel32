using Al_Wakel_Pro_move_1.Model;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Core
{
    public static class CurrnceyMang
    {
        public static bool isUpdateing = false;
        public static async Task<List<Currency>> GetCurrenciesAsync()
        {
            List<Currency> currencies;
            using (var context = new AppDataContext())
            {
                  currencies = await context.Currency.ToListAsync();  
            }
            return currencies;
        }
    }
}
