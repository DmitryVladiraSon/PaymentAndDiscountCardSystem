using PaymentAndDiscountCardSystem.Shop;
using PaymentAndDiscountCardSystem.Shop.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Models
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
        

        public Customer(string name,string password) : base(name, password)
        {
            _cards = new List<Card>();
            AddingCards();
        }

        void AddingCards()
        {
            _cards.Add(new DiscountCard(DiscountCardType.Tube, 5000, 5));
            _cards.Add(new DiscountCard(DiscountCardType.Transistor, 12500, 10));
            _cards.Add(new DiscountCard(DiscountCardType.Integrated, 25000, 15));
            _cards.Add(new DiscountCard(DiscountCardType.Transistor, 12500, 10));

            //Добавь веселую карту 
            _cards.Add(new FunnyCard(DiscountCardType.Cheerful, 10));

            //Добавление квантовой карты
            _cards.Add(new QuantumCard(DiscountCardType.Quantum, 20));
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }


    }
}
