using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Domain.Entity.Cards
{
    public class DiscountCard : Card 
    {
        public ulong ThresholdAmount { get; private set; }
        public DiscountCard(DiscountCardType type, ulong thresholdAmount, int discountRate) : base(discountRate)
        {
            ThresholdAmount = thresholdAmount;
            Type = type;
        }
    }
}
