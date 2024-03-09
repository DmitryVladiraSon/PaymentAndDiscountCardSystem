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
            // Создаем генератор случайных чисел
            Random rnd = new Random();

            DateTime currentDate = DateTime.Today;

            for (int i = 0; i < DiscountsDays.Length; i++)
            {
                int randomDay = rnd.Next(1, DateTime.DaysInMonth(currentDate.Year, currentDate.Month) + 1);

                DiscountsDays[i] = new DateTime(currentDate.Year, currentDate.Month, randomDay);
            }
            DiscountsDays = DiscountsDays.OrderByDescending(day => day.Day).ToArray();
            

        }

        public DateTime[] DiscountsDays { get; set; } = new DateTime[10];


    }
}
