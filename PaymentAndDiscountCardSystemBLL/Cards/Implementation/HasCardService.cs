using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Cards.Interfaces;
using PaymentAndDiscountCardSystemDomain.Entity.Cards;

namespace PaymentAndDiscountCardSystemBLL.Cards.Implementation
{
    public class HasCardService : IHasCardService
    {
        private readonly ILogger<HasCardService> _logger;

        public HasCardService(ILogger<HasCardService> logger)
        {
            _logger = logger;
        }
        public bool FromCustomer(Customer customer, DiscountCardType cardType)
        {
            var card = customer.DiscountCards.FirstOrDefault(card => card.Type == cardType);
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
