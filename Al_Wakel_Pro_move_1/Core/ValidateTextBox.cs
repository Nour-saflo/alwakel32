using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Core
{
    public class ValidateTextBox
    {
        public static void AcceptOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        public static void AcceptOnlyPhoneNumber(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }
        public static void AcceptOnlyString(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 

            }
        }
    }
}
