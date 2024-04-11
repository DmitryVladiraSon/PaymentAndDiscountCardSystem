using PaymentAndDiscountCardSystemDAL.Repositories.UserRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Users;
using PaymentAndDiscountCardSystemService.Auth;

namespace PaymentAndDiscountCardSystemService.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

            await _userRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
