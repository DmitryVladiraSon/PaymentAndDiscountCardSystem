using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Service.Customers.Implementation;
using PaymentAndDiscountCardSystemDAL.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ILogger<CreateCustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerService(ICustomerRepository customerRepository, ILogger<CreateCustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger; ;
        }
        public void Add(Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);
                _logger.LogInformation($"Customer added. Id:{customer.Id} Name:{customer.Name} ");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Customer didn't add");
                throw;
            }
        }
    }
}
