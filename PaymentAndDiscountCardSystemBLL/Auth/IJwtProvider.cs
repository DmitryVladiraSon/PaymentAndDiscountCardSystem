using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(Customer customer);
    }
}