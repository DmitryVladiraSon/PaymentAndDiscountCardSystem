

namespace PaymentAndDiscountCardSystem.Domain.Entity.Cards
{
    public abstract class Card
    {
        public Card()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int DiscountRate { get; protected set; }
        public DiscountCardType Type { get; protected set; }

    }
}
