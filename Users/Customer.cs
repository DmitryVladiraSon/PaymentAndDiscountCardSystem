using PaymentAndDiscountCardSystem.Shop.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Users
{
    internal class Customer : User
    {
        
        private List<Card> _cards;
        
        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        public decimal AccumulatedAmount;
        
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
            _cards = new List<Card>();
        }


        public List<Card> GetCards
        {
            get { return _cards; }
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public Card? GetCard(Card card)
        {
            return Cards.Find(discountCard => discountCard.Type == card.Type);
        }
    }
}
