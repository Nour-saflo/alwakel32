using Al_Wakel_Pro_move_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Repository
{
    public interface ICurrnceyOperationRepository
    {
        Task AddNewOperationCurrnceyAsync(CurrencyOperations currencyOperations);
    }
}
