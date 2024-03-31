using PaymentAndDiscountCardSystem.Domain.Entity.Cards;

namespace PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards
{
    public class AmountDiscountCard : DiscountCard
    {
        public ulong ThresholdAmount { get; protected set; }
        public AmountDiscountCard(DiscountCardType type)
        {

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
