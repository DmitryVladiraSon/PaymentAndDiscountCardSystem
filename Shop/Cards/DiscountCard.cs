using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop.Cards
{
    internal class DiscountCard : Card 
    {
        public ulong ThresholdAmount { get; private set; }
        public DiscountCard(DiscountCardType type, ulong thresholdAmount, int discountRate) : base(type, discountRate)
        {
            ThresholdAmount = thresholdAmount;
        }
    }
}
