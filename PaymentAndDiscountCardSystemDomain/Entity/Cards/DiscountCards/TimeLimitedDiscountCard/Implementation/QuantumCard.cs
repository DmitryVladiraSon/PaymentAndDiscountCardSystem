using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Interfaces;

namespace PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation
{
    public class QuantumCard : DiscountCard, ITimeLimitedCard
    {
        public const int VALIDITY_PERIOD = 180;
        public QuantumCard()
        {
            DiscountRate = 20;
            Type = DiscountCardType.Quantum;
        }

        public bool IsExpired()
        {
            DateTime currentDate = DateTime.Now;

            DateTime expirationDate = CreationDate.AddDays(VALIDITY_PERIOD);

            return currentDate >= expirationDate;
        }

        public int GetDaysBeforeExpirationDate()
        {
            DateTime currentDate = DateTime.Now;

            DateTime expirationDate = CreationDate.AddDays(VALIDITY_PERIOD);

            TimeSpan difference = expirationDate - currentDate;
            return (int)difference.TotalDays;
        }

    }
}
