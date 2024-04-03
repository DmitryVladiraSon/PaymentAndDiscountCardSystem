using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

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

        public async Task<Customer?> GetById(Guid customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            if (customer != null)
            {
                _logger.LogInformation($"Customer found with id: {customerId}");
            }
            else
            {
                _logger.LogError($"Customer not found with id: {customerId}");
            }
            return customer;
        }

        public async Task<Customer?> GetByName(string name)
        {
            var customer = await _customerRepository.GetByName(name);
            if (customer != null)
            {
                _logger.LogInformation($"Customer found with name: {name}");
            }
            else
            {
                _logger.LogError($"Customer not found with name: {name}");
            }
            return customer;
        }
    }
}
