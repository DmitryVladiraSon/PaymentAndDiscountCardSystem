using PaymentAndDiscountCardSystem.Shop.Cards;
using PaymentAndDiscountCardSystem.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Shop
{
    internal class Store
    {
        private List<Card> _cards = new List<Card>();

        private List<Customer> _customers = new List<Customer>();
        public void AddCard(Card card)
        {
            
            if (!_cards.Exists(c => c.Type == card.Type))
            {
                _cards.Add(card);
                Console.WriteLine($"Карта типа {card.Type} добавлена в магазин.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Карта типа {card.Type} уже существует в магазине.");
                Console.ResetColor();
            }
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetCustomer(string name)
        {
            return _customers.Find(cusmoter => cusmoter.Name == name);
        }

        private void AddingCardToCustomer(Customer customer)
        {
            try
            {
                foreach (DiscountCard discountCard in _cards)
                {
                    if (customer.AccumulatedAmount > discountCard.ThresholdAmount)
                    {
                        if (customer.GetCard(discountCard) == null) customer.AddCard(discountCard);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                //В логи записать, что-то, но пока сам не знаю, что ;)
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="amount">Сумма товара</param>
        public void ProcessPurchase(Customer customer, decimal amount)
        {
            //процесс добавления карты
            AddingCardToCustomer(customer);

            //Вот это процесс оплаты
            var priorityCard = customer.Cards.OrderByDescending(card => card.DiscountRate).FirstOrDefault();
            int discount = 0;   
            if (priorityCard != null)
            {
                 discount = priorityCard.DiscountRate;
            }
            var amountWithDiscount = amount - (amount /100* discount);
            customer.AccumulatedAmount += amount;

            Console.WriteLine($"amount {amount} with discount {discount}% = {amountWithDiscount} | Accumulated amount {customer.AccumulatedAmount}");

        }

        public void GetCustomerFunnyCard( Customer customer)
        {
            var myCustomer = _customers.Find(c => c.Name == customer.Name);
            myCustomer.Cards.Add(_cards.Find(card => card.Type == TypeDiscountCard.Cheerful));
        }
    }
}
