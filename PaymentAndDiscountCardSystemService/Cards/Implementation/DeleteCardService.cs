using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    public class DeleteCardService : IDeleteCardService
    {
        private readonly ILogger<DeleteCardService> _logger;
        public DeleteCardService(ILogger<DeleteCardService> logger) 
        {
            _logger = logger;
        }
        public void FromCustomer(Customer customer, DiscountCardType cardType)
        {
            var cardToRemove = customer.Cards.Find(card => card.Type == cardType);
            if (cardToRemove != null)
            {
                customer.Cards.Remove(cardToRemove);
                _logger.LogInformation($"the card {cardType} has been deleted form customer {customer.Name} | {customer.Id}");
            }
            else
            {
                _logger.LogInformation($"The card {cardType} does not exist form customer {customer.Name} | {customer.Id}");
            }
        }
    }
}
