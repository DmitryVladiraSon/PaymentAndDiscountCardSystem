using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDAL.Repositories.DiscountCardRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Interfaces;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ICustomerQueryService _customerProviderService;
        private readonly IDiscountCardRepository _discountCardRepository;
        private readonly IAddCardService _addCardService;
        private readonly ILogger<PurchaseService> _logger;
        public PurchaseService(
            ICustomerQueryService getCustomerService,
            IAddCardService addCardService,
            IDiscountCardRepository discountCardRepository,
            ILogger<PurchaseService> logger)
        {
            _discountCardRepository = discountCardRepository;
            _customerProviderService = getCustomerService;
            _addCardService = addCardService;
            _logger = logger;
        }
        public async void Purchase(Guid customerId, decimal amount)
        {
            var customer = await _customerProviderService.GetById(customerId);

            AddingDiscountCardsToCustomer(customer);

            int discount = 0;
            DiscountCardType? usedCardType = null;
            var timeLimitedCard = customer.DiscountCards.OfType<ITimeLimitedCard>()
                                                .OrderBy(card => card.IsExpired())
                                                .Select(x => (DiscountCard)x)
                                                .OrderByDescending(card => card.DiscountRate)
                                                .ToList()
                                                .FirstOrDefault();

            if (timeLimitedCard != null)
            {
                discount = timeLimitedCard.DiscountRate;
                usedCardType = timeLimitedCard.Type;
            }
            else
            {
                var priorityCard = customer.DiscountCards.OrderByDescending(card => card.DiscountRate).FirstOrDefault();

                if (priorityCard != null)
                {
                    discount = priorityCard.DiscountRate;
                    usedCardType = priorityCard.Type;

                }
            }
            
            var amountWithDiscount = amount - (amount / 100 * discount);
            customer.AccumulatedAmount += amount;
            
            _logger.LogInformation($"amount: {amount} with discount {discount}% = {amountWithDiscount} | Accumulated amount: {customer.AccumulatedAmount} | used card: {usedCardType}");

        }

        private void AddingDiscountCardsToCustomer(Customer customer)
        {
            foreach (var discountCard in _discountCardRepository.Entities
                                            .Where(c => c.GetType() == typeof(AmountDiscountCard))
                                            .Select(x => (AmountDiscountCard)x).ToList())
            {
                if (discountCard.ThresholdAmount <= customer.AccumulatedAmount)
                {
                    _addCardService.ToCustomer(customer.Id, discountCard.Type);
                }
            }
        }
    }
}
