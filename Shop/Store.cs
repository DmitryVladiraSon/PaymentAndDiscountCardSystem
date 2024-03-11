using PaymentAndDiscountCardSystem.Shop.Cards;
using PaymentAndDiscountCardSystem.Models;

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



        public void GetCustomerFunnyCard( Customer customer)
        {
            var myCustomer = _customers.Find(c => c.Name == customer.Name);
            myCustomer.Cards.Add(_cards.Find(card => card.Type == DiscountCardType.Cheerful));
        }
    }
}