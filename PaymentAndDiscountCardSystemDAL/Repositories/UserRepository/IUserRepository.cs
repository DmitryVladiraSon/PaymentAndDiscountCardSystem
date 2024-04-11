using PaymentAndDiscountCardSystemDomain.Entity.Users;

namespace PaymentAndDiscountCardSystemDAL.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmailAsync(string email);
    }
}