
namespace PaymentAndDiscountCardSystemDomain.Entity.Products
{
    public class Product
    { 
        public Product(string name, string description, long count, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Count = count;
            Price = price;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; } 
    }
}
