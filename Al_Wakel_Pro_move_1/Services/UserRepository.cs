using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context)
        {
            _context = context;
        }
        public  User GetById(int id)
        {
            return _context.User.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
