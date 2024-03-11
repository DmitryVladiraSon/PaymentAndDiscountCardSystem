using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Models;
using PaymentAndDiscountCardSystem.Shop.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Service
{
    internal class CustomerService : ICustomerService
    {
        private List<Customer> _customers;
        private readonly ILogger _logger;
        public CustomerService(List<Customer> customers, ILogger logger)
        {
            _customers = customers;
            _logger = logger;
        }
        public void Add(Customer customer)
        {
            _customers.Add(customer);
            _logger.LogInformation($"Customer added. Id:{customer.Id} Name:{customer.Name} ");
        }

        public Customer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            return _customers.Find(c => c.Name == name);
        }

        public Card GetCard(Customer customer, DiscountCardType type)
        {
            throw new NotImplementedException();
        }
    }
}
