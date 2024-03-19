using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Domain.Entity.Cards
{
    public class DiscountCard : Card
    {
        public ulong ThresholdAmount { get; protected set; }
        public DiscountCard(DiscountCardType type) { 

            Type = type;

            switch (type)
            {
                case DiscountCardType.Tube:
                    ThresholdAmount = 5000;
                    DiscountRate = 5;
                    break;

                case DiscountCardType.Transistor:
                    ThresholdAmount = 12500;
                    DiscountRate = 10;
                    break;

                case DiscountCardType.Integrated:
                    ThresholdAmount = 25000;
                    DiscountRate = 15;
                    break;

            }
        }
    }
}
