using PaymentAndDiscountCardSystemDomain.Entity.Cards;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public class Customer 
    {
        private Customer(Guid id, string name, string email, string passwordHash) 
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            AccumulatedAmount = 0;
        }

        public Guid Id { get; set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public string Name { get; set; }
        public decimal AccumulatedAmount { get; set; }
        public List<DiscountCard> DiscountCards { get; set; } = [];


        public static Customer Create(Guid id, string email, string name, string passwordHash)
        {
            return new Customer(id,  name, email, passwordHash);
        }
    }
}
