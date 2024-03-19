

using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDAL.DiscountCardRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IGetCustomerService _getCustomerService;
        private readonly IDiscountCardRepository _discountCardRepository;
        private readonly IAddCardService _addCardService;
        private readonly ILogger<PurchaseService> _logger;
        public PurchaseService(
            IGetCustomerService getCustomerService,
            IAddCardService addCardService,
            IDiscountCardRepository discountCardRepository,
            ILogger<PurchaseService> logger)
        {
            _discountCardRepository = discountCardRepository;
            _getCustomerService = getCustomerService;
            _addCardService = addCardService;
            _logger = logger;
        }
        public void Purchase(Guid customerId, decimal amount)
        {
            var customer = _getCustomerService.GetById(customerId);

            AddingDiscountCardsToCustomer(customer);

            var priorityCard = customer.Cards.OrderByDescending(card => card.DiscountRate).FirstOrDefault();
            int discount = 0;
            if (priorityCard != null)
            {
                discount = priorityCard.DiscountRate;
            }
            
            var amountWithDiscount = amount - (amount / 100 * discount);
            customer.AccumulatedAmount += amount;

            _logger.LogInformation($"amount {amount} with discount {discount}% = {amountWithDiscount} | Accumulated amount {customer.AccumulatedAmount}");

        }

        private void AddingDiscountCardsToCustomer(Customer customer)
        {
            foreach (var discountCard in _discountCardRepository.Entities
                                            .Where(c => c.GetType() == typeof(DiscountCard))
                                            .Select(x => (DiscountCard)x).ToList())
            {
                if (discountCard.ThresholdAmount == customer.AccumulatedAmount)
                {
                    _addCardService.ToCustomer(customer, discountCard.Type);
                }
            }
        }
    }
}
