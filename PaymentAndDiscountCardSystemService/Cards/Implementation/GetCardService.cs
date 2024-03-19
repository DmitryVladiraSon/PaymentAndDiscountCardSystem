using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    internal class GetCardService : IGetCardService
    {
        private readonly IGetCustomerService _getCustomerService;
        private readonly ILogger _logger;

        public GetCardService(ILogger logger)
        {
            _logger = logger;
        }

        public Card ByCardType(DiscountCardType type)
        {
            switch (type)
            {
                case DiscountCardType.Tube:
                    return new DiscountCard(DiscountCardType.Tube);

                case DiscountCardType.Transistor:
                    return new DiscountCard(DiscountCardType.Transistor );

                case DiscountCardType.Integrated:
                    return new DiscountCard(DiscountCardType.Integrated);

                case DiscountCardType.Quantum:
                    return new QuantumCard();

                case DiscountCardType.FunnyCard:
                    return new FunnyCard();

                default:
                    return new FunnyCard();
            };
        }
        
        public Card ByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
