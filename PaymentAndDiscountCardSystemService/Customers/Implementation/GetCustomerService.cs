using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class GetCustomerService : IGetCustomerService
    {
        private readonly ILogger<GetCustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerService(ICustomerRepository customerRepository, ILogger<GetCustomerService> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public Customer? GetById(Guid customerId)
        {
            Customer? customer = _customerRepository.FirstOrDefault(customer => customer.Id == customerId);

            if (customer != null)
            {
                _logger.LogInformation($"Customer found with id: {customerId}");
                return customer;
            }
            else
            {
                _logger.LogError($"Customer not found with id: {customerId}");
                return null;
            }
        }

        public Customer GetByName(string name)
        {
            var customer = _customerRepository.GetByName(name);

            if (customer != null)
            {
                _logger.LogInformation($"Customer found with name: {name}");
                return customer;
            }
            else
            {
                _logger.LogError($"Customer not found with name: {name}");
                return customer;
            }
        }

        public Task<Customer?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
