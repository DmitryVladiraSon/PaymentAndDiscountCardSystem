using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop.Cards
{
    internal abstract class Card
    {
        public Card(DiscountCardType type, int discountRate)
        {
            Type = type;
            DiscountRate = discountRate;

        }
        public bool IsActive = false;
        public int DiscountRate { get; private set; }
        public DiscountCardType Type { get; private set; }

    }
}
