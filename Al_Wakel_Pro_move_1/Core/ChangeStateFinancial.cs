using Al_Wakel_Pro_move_1.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Core
{
    public class ChangeStateFinancial
    {
        public static string ChangeEnumFinancialToStringsFinancial(Enum.StatusOfFinancial statusOf)
        {
            string state = "";
            if (statusOf == StatusOfFinancial.Push)
            {
                state = "إضافة";
            }
            else if (statusOf == StatusOfFinancial.Pull)
            {
                state = "قبض";
            }
            return state;
        }
        public static Enum.StatusOfFinancial ChangeStringFinancialToEnumsFinancial(string state)
        {

            var statusOf = StatusOfFinancial.None;
            if (state.Equals("إضافة")  )
            {
                statusOf= StatusOfFinancial.Push;
            }
            else if (state.Equals("قبض"))
            {
                statusOf = Enum.StatusOfFinancial.Pull;
            }

             

            return statusOf;  
        }
    }
}
