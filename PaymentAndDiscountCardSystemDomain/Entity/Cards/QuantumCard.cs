
namespace PaymentAndDiscountCardSystem.Domain.Entity.Cards
{
    public class QuantumCard : Card
    {
        public const int VALIDITY_PERIOD = 180;
        private DateTime creationDate;
        public QuantumCard()
        {
            DiscountRate = 20;
            creationDate = DateTime.Now;
            Type = DiscountCardType.Quantum;
        }

        public bool IsExpired()
        {
            DateTime currentDate = DateTime.Now;

            DateTime expirationDate = creationDate.AddDays(VALIDITY_PERIOD);

            return currentDate >= expirationDate;
        }

        public int GetDaysBeforeExpirationDate()
        {
            DateTime currentDate = DateTime.Now;

            DateTime expirationDate = creationDate.AddDays(VALIDITY_PERIOD);

            TimeSpan difference = expirationDate - currentDate;
            return (int)difference.TotalDays;
        }

    }
}
