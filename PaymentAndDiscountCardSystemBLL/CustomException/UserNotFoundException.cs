
namespace PaymentAndDiscountCardSystemBLL.CustomException
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
