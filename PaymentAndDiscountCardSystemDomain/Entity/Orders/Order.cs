using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;

namespace PaymentAndDiscountCardSystemDomain.Entity.Orders
{
    public class Order
    {
        public Order(Guid customerId)
        {
            OrderID = Guid.NewGuid();
            CustomerId = customerId;
        }
        public Guid OrderID { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderItem> orderItems { get; set; }

    }
}
