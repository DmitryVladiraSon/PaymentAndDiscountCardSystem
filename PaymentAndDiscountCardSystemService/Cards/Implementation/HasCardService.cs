using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    internal class HasCardService : IHasCardService
    {
        private readonly ILogger<HasCardService> _logger;

        public HasCardService(ILogger<HasCardService> logger)
        {
            _logger = logger;
        }
        public bool FromCustomer(Customer customer, DiscountCardType cardType)
        {
            var card = customer.Cards.FirstOrDefault(card => card.Type == cardType);
            if (card == null)
            {
                _logger.LogInformation($"The card {cardType} WAS NOT found form customer {customer.Name} | {customer.Id}.");
               return false; 
            }
            else
            {
                _logger.LogInformation($"The card {cardType} WAS found form customer {customer.Name} | {customer.Id}.");
                return true;
            }
        }
    }
}
