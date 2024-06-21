using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Services
{
    public class CurrnceyOperationRepository : ICurrnceyOperationRepository
    {
        private readonly AppDataContext _context;

        public CurrnceyOperationRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task AddNewOperationCurrnceyAsync(CurrencyOperations currencyOperations)
        {
            _context.CurrencyOperations.Add(currencyOperations);
            await _context.SaveChangesAsync();
        }
 
    }
}
