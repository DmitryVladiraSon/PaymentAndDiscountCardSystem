using PaymentAndDiscountCardSystemDomain.Entity.Users;

namespace PaymentAndDiscountCardSystemService.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}