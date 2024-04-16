using PaymentAndDiscountCardSystemBLL.Auth;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemBLL.Auth
{
    public class LoginService : ILoginService
    {
        private readonly ICustomerQueryService _customerQueryService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public LoginService(
            ICustomerQueryService customerQueryService,
            ICustomerRepository customerRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _customerQueryService = customerQueryService;
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string name, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var customer = Customer.Create(Guid.NewGuid(),name, email, hashedPassword);

            await _customerRepository.Create(customer);
        }

        public async Task<string> Login(string email, string password)
        {
            var customer = await _customerQueryService.GetByEmailAsync(email);

            var result = _passwordHasher.Verify(password, customer.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(customer);

            return token;
        }
    }
}
