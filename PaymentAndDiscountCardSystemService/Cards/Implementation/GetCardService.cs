using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
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
        public Card ByCardType(DiscountCardType type)
        {
            switch (type)
            {
                case DiscountCardType.Tube:
                    return new DiscountCard(DiscountCardType.Tube,5000, 5);

                case DiscountCardType.Transistor:
                    return new DiscountCard(DiscountCardType.Transistor, 12500, 10);

                case DiscountCardType.Integrated:
                    return new DiscountCard(DiscountCardType.Integrated, 25000, 15);

                case DiscountCardType.Quantum:
                    return new QuantumCard(20);

                case DiscountCardType.FunnyCard:
                    return new FunnyCard(10);

                default:
                    return new FunnyCard(10);
            };
        }

        public Card ByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
