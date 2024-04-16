using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Customers.Interfaces;
using PaymentAndDiscountCardSystemBLL.CustomException;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ILogger<CustomerQueryService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerQueryService(ICustomerRepository customerRepository, ILogger<CustomerQueryService> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<Customer>? GetByEmailAsync(string email)
        {
            var customers = await _customerRepository.GetAllAsync();

            return await customers
                .Where(c => c.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<Customer>? GetById(Guid customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            if (customer != null)
            {
                _logger.LogInformation($"Customer found with id: {customerId}");
            }
            else
            {
                _logger.LogError($"Customer don't found with id: {customerId}");
                throw new UserNotFoundException($"Customer don't found with id: {customerId}");
            }
            return customer;
        }

        public async Task<List<Customer>?> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }

            var customers = await _customerRepository.GetAll();
            var customersWithName = customers
                .Where(c => c.Name == name)
                .ToList();

            if (customersWithName.Count == 0)
            {
                _logger.LogError($"Customer(s) do not found with name: {name}");
                //throw new UserNotFoundException($"Customer(s) do not found with name: {name}");
            }
            else
            {
                _logger.LogInformation($"Customer(s) found with name: {name}");
            }

            return customersWithName;
        }
    }
}
