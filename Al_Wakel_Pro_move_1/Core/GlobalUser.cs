using Al_Wakel_Pro_move_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Core
{
    public static class GlobalUser
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static int Age { get; set; }
        public static string PhoneNumber { get; set; }
        public static string Email { get; set; }
        public static string CompanyName { get; set; }
        public static string Address { get; set; }
        public static string PasswordForEditQuantity { get; set; }
        public static string Role { get; set; }
        public static string UserName { get; set; }
        public static byte [] Image { get; set; }

        public static void Clone(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            Role = user.Role;
            Email = user.Email;
            CompanyName = user.CurrnceyName;
            Address = user.Address;
            PasswordForEditQuantity = user.PasswordForEditQuantity;
            Role = user.Role;
            PhoneNumber=user.PhoneNumber;
            UserName=user.UserName;
            Image=user.Image;
        }
    }
}
