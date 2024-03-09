using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop.Cards
{
    internal abstract class Card
    {

        public Card(TypeDiscountCard type, int discountRate)
        {
            Type = type;
            DiscountRate = discountRate;
        }
        public int DiscountRate { get; private set; }

        public TypeDiscountCard Type { get; private set; }

    }
}
