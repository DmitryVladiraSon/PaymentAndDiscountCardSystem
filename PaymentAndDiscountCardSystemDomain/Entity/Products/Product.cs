
namespace PaymentAndDiscountCardSystemDomain.Entity.Products
{
    public class Product
    { 
        private Product(Guid id, string name, string description, long count, decimal price)
        {
            Id = id;
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

        public static Product Create(Guid id, string name, string description, long count, decimal price)
        {
            return new Product(id, name, description, count, price);
        }
    }
}
