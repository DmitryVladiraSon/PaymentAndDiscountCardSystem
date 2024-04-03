using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class CustomerCreationService : ICustomerCreationService
    {
        private readonly ILogger<CustomerCreationService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerCreationService(
            ICustomerRepository customerRepository,
            ICustomerQueryService customerQueryService,
            ILogger<CustomerCreationService> logger)
        {
            _customerRepository = customerRepository;
            _customerQueryService = customerQueryService;
            _logger = logger;
        }

        public async Task<Guid?> Create(CustomerDTO customerViewModel)
        {

            var customerWithEnteringName = await _customerQueryService.GetByName(customerViewModel.Name);
            if(customerWithEnteringName != null)
            {
                _logger.LogError($"User creation failed. Username '{customerViewModel.Name}' is already taken.");

                return null;
            }

            var customerId = await _customerRepository.Create(customerViewModel);
            
            if (customerId != null)
            {
                _logger.LogInformation($"Customer created: {customerViewModel.Name}");
            }
            else
            {
                _logger.LogError($"Customer DID NOT created: {customerViewModel.Name}");
            }


            return customerId;
        }
        public async Task<Customer> Update(Guid customerId, CustomerDTO customerViewModel)
        {
            var customer = await _customerRepository.Update(customerId, customerViewModel);
            
            return customer;
        }
        public async Task<bool> Delete(Guid customerId)
        {
            var isDeleted = await _customerRepository.Delete(customerId);
            return isDeleted; 
        }

        public async Task<Customer> Update(Customer customer)
        {
            var updatedCustomer =  await _customerRepository.Update(customer);
            return updatedCustomer;
        }
    }
}
