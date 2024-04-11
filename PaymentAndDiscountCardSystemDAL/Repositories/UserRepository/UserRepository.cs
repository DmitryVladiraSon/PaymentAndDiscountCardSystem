using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDomain.Entity.Users;

namespace PaymentAndDiscountCardSystemDAL.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
