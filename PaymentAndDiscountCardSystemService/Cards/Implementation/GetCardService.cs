using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    internal class GetCardService : IGetCardService
    {
        private readonly ICustomerQueryService _getCustomerService;
        private readonly ILogger _logger;

        public GetCardService(ILogger logger)
        {
            _logger = logger;
        }

        public DiscountCard ByCardType(DiscountCardType type)
        {
            switch (type)
            {
                case DiscountCardType.Tube:
                    return new AmountDiscountCard(DiscountCardType.Tube);

                case DiscountCardType.Transistor:
                    return new AmountDiscountCard(DiscountCardType.Transistor );

                case DiscountCardType.Integrated:
                    return new AmountDiscountCard(DiscountCardType.Integrated);

                case DiscountCardType.Quantum:
                    return new QuantumCard();

                case DiscountCardType.FunnyCard:
                    return new FunnyCard();

                default:
                    return new FunnyCard();
            };
        }
        
        public DiscountCard ByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
