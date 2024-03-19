using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using System.ComponentModel.Design;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public class Customer
    {
        
        private List<Card> _cards;
        
        public List<Card> Cards
        {
            get { return _cards; }
            //set { _cards = value; }
        }

        public decimal AccumulatedAmount { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Customer(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
            _cards = new List<Card>();
        }
    }
}
