using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem
{
    internal class DataInitializer
    {
        private readonly ICreateCustomerService _createCustomerService;
        private readonly IAddCardService _addCardService;

        public DataInitializer(ICreateCustomerService createCustomerService, IAddCardService addCardService)
        {
            _createCustomerService = createCustomerService;
            _addCardService = addCardService;
        }

        public void Initialize()
        {
            Customer customer1 = new Customer("Dima");
            _createCustomerService.Add(customer1);
            _addCardService.ToCustomer(customer1, DiscountCardType.Tube);
            _addCardService.ToCustomer(customer1, DiscountCardType.Tube);
        }
    }
}
