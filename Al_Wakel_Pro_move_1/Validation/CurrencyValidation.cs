using Al_Wakel_Pro_move_1.Model;
using System.Text;

namespace Al_Wakel_Pro_move_1.Validation
{
    public class CurrencyValidation
    {
        public static bool ValidateCurrency(Currency currency, out string errorMessage)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currency.Name.Trim()))
            {
                sb.AppendLine("اسم العملة مطلوب.");
            }
            if (currency.Quantity < 0)
            {
                sb.AppendLine("يجب أن تكون كمية العملة أكبر من صفر.");
            }

            // التحقق من طول كود العملة
            if (!string.IsNullOrEmpty(currency.CurrencyCode.Trim()) && currency.CurrencyCode.Length > 20)
            {
                sb.AppendLine("يجب أن يكون طول كود العملة أقل من أو يساوي 20 حرفًا.");
            }

            if (sb.Length > 0)
            {
                errorMessage = sb.ToString();
                return false;
            }

            errorMessage = null;
            return true;
        }
    }

}
