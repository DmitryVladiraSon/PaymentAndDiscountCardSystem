using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.DAL.Repositories;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
