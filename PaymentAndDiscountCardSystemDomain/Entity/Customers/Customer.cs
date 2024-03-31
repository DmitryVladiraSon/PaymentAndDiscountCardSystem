using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using System.ComponentModel.Design;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public class Customer
    {
        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            AccumulatedAmount = 0;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AccumulatedAmount { get; set; }
        public List<DiscountCard> DiscountCards { get; set; } = [];
       
    }
}
