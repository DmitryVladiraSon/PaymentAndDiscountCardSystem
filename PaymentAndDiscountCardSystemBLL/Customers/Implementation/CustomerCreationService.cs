using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Customers.Interfaces;
using PaymentAndDiscountCardSystemBLL.Customers.Validation;
using FluentValidation.Results;

namespace PaymentAndDiscountCardSystemBLL.Customers.Implementation
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

        public async Task<Guid?> Create(CustomerDTO customerDto)
        {


            var customerWithEnteringName = await _customerQueryService.GetByName(customerDto.Name);
            if(customerWithEnteringName.Count != 0)
            {
                _logger.LogError($"User creation failed. Username '{customerDto.Name}' is already taken.");

                return null;
            }

            var customer = Customer.Create(Guid.NewGuid(), customerDto.Email, customerDto.Name, "");


                var customerId = await _customerRepository.Create(customer);

                if (customerId != null)
                {
                    _logger.LogInformation($"Customer created: {customerDto.Name}");
                }
                else
                {
                    _logger.LogError($"Customer DID NOT created: {customerDto.Name}");
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
