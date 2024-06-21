using Al_Wakel_Pro_move_1.Model;
using System.Text;

namespace Al_Wakel_Pro_move_1.Validation
{
    public class CustomerValidation
    {
        public static bool ValidateCustomer(Customer customer, out string errorMessage)
        {
            StringBuilder sb = new StringBuilder();

            // التحقق من اسم العميل
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                sb.AppendLine("اسم العميل مطلوب.");
            }
            else if (customer.Name.Length > 50)
            {
                sb.AppendLine("يجب أن يكون طول اسم العميل أقل من أو يساوي 50 حرفًا.");
            }

            // التحقق من عنوان العميل
            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                sb.AppendLine("عنوان العميل مطلوب.");
            }
            else if (customer.Address.Length > 100)
            {
                sb.AppendLine("يجب أن يكون طول عنوان العميل أقل من أو يساوي 100 حرفًا.");
            }

            // التحقق من اسم المزود
            if (string.IsNullOrWhiteSpace(customer.ProviderName))
            {
                sb.AppendLine("اسم المزود مطلوب.");
            }
            else if (customer.ProviderName.Length > 100)
            {
                sb.AppendLine("يجب أن يكون طول اسم المزود أقل من أو يساوي 100 حرفًا.");
            }

            // التحقق من رقم الهوية
            if (customer.IdentityNumber <= 0)
            {
                sb.AppendLine("رقم الهوية يجب أن يكون أكبر من صفر.");
            }

            // يمكنك إضافة المزيد من التحققات هنا...

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
