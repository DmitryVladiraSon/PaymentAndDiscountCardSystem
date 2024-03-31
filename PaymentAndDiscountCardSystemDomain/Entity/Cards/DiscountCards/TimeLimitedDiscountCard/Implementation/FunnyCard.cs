using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Interfaces;

namespace PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation
{
    public class FunnyCard : DiscountCard, ITimeLimitedCard
    {
        private DateTime[] _discountsDaysPerMonth;

        public FunnyCard()
        {
            int numberOfDiscountDaysPerMonth = 10;
            if (numberOfDiscountDaysPerMonth <= 0)
            {
                throw new ArgumentException("numberOfDiscountDaysPerMonth must be greater than zero.", nameof(numberOfDiscountDaysPerMonth));
            }
            var numberDaysInThisMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            if (numberOfDiscountDaysPerMonth > numberDaysInThisMonth)
            {
                throw new ArgumentException($"numberOfDiscountDaysPerMonth must be less than number Days In This Month {numberDaysInThisMonth}.", nameof(numberOfDiscountDaysPerMonth));
            }

            DiscountsDaysPerMonth = GetRandomDaysInMonth(numberOfDiscountDaysPerMonth);
            DiscountRate = 10;
            Type = DiscountCardType.FunnyCard;
        }

        public DateTime[] DiscountsDaysPerMonth
        {
            get => _discountsDaysPerMonth;
            set
            {
                _discountsDaysPerMonth = value.Select(d => d.ToUniversalTime()).ToArray();
            }
        }


        public bool IsExpired()
        {
            var currentDate = DateTime.Today;

            foreach (var day in DiscountsDaysPerMonth)
            {
                if (currentDate == day)
                {
                    return true;
                }
            }
            return false;
        }

        private DateTime[] GetRandomDaysInMonth(int numberOfDiscountDaysPerMonth)
        {
            DateTime[] discountsDaysPerMonth = new DateTime[numberOfDiscountDaysPerMonth];
            // Создаем генератор случайных чисел
            Random rnd = new Random();

            DateTime currentDate = DateTime.Today;

            for (int i = 0; i < discountsDaysPerMonth.Length; i++)
            {
                int randomDay = rnd.Next(1, DateTime.DaysInMonth(currentDate.Year, currentDate.Month) + 1);

                discountsDaysPerMonth[i] = new DateTime(currentDate.Year, currentDate.Month, randomDay);
            }
            return discountsDaysPerMonth.OrderByDescending(day => day.Day).ToArray();


        }

    }
}
