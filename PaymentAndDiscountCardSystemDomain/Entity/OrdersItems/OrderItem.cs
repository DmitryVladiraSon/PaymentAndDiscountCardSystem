using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemDomain.Entity.OrdersItems
{
    public class OrderItem
    {
        public OrderItem(Order order, Product product, int count)
        {
            Id = Guid.NewGuid();
            Order = order;
            OrderId = order.OrderId;
            Product = product;
            ProductId = product.Id;
            CountItems = count;
            CustomerId = order.CustomerId;
        }
        public OrderItem()
        {
            
        }
        public Guid Id  { get; set; }

        public Guid OrderId  { get; set; }
        public Order? Order { get; set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int CountItems { get; set; }
    }
}
