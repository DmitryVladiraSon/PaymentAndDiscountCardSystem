

namespace PaymentAndDiscountCardSystem.Domain.Entity.Cards
{
    public abstract class Card
    {
        public Card( int discountRate)
        {
            DiscountRate = discountRate;
        }
        public bool IsActive = false;
        public int DiscountRate { get; private set; }
        public DiscountCardType Type { get; protected set; }

    }
}
