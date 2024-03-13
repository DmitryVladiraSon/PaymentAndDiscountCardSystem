using PaymentAndDiscountCardSystem.Domain.Entity.Cards;

namespace PaymentAndDiscountCardSystem.Domain.Entity
{
    public class Customer : User
    {
        
        private List<Card> _cards;
        
        public List<Card> Cards
        {
            get { return _cards; }
            //set { _cards = value; }
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
            _cards.Add(new FunnyCard(10));

            //Добавление квантовой карты
            _cards.Add(new QuantumCard(20));
        }

    }
}
