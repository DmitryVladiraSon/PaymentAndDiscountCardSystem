using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop.Cards
{
    internal class FunnyCard : Card
    {
        public FunnyCard(TypeDiscountCard type, int discountRate) : base(type, discountRate)
        {
            DiscountsDays = GetRandomDaysInMonth(DiscountsDays);
        }

        public DateTime[] DiscountsDays { get; set; } = new DateTime[10];

        private DateTime[] GetRandomDaysInMonth(DateTime[] discountsDays)
        {
            // Создаем генератор случайных чисел
            Random rnd = new Random();

            DateTime currentDate = DateTime.Today;

            for (int i = 0; i < discountsDays.Length; i++)
            {
                int randomDay = rnd.Next(1, DateTime.DaysInMonth(currentDate.Year, currentDate.Month) + 1);

                discountsDays[i] = new DateTime(currentDate.Year, currentDate.Month, randomDay);
            }
            return  discountsDays.OrderByDescending(day => day.Day).ToArray();


        }

    }
}
