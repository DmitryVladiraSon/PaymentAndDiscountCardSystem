using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop.Cards
{
    internal class QuantumCard : Card
    {
        public const int VALIDITY_PERIOD = 180;
        private DateTime creationDate;
        public QuantumCard(DiscountCardType type, int discountRate) : base(type, discountRate)
        {
            creationDate = DateTime.Now;
        }
        public bool IsExpired()
        {
            // Получаем текущую дату
            DateTime currentDate = DateTime.Now;

            // Добавляем 180 дней к дате создания
            DateTime expirationDate = creationDate.AddDays(VALIDITY_PERIOD);

            // Если текущая дата больше или равна дате истечения срока, возвращаем true
            return currentDate >= expirationDate;
        }

        public int GetDaysBeforeExpirationDate()
        {
            // Получаем текущую дату
            DateTime currentDate = DateTime.Now;

            // Добавляем 180 дней к дате создания
            DateTime expirationDate = creationDate.AddDays(VALIDITY_PERIOD);

            // Возвращаем количество дней до истечения срока
            TimeSpan difference = expirationDate - currentDate;
            return (int)difference.TotalDays;
        }

    }
}
