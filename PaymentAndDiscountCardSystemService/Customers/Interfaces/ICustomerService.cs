using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;


namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public interface ICustomerService
    {
     
        public Card GetCard(Customer customer, DiscountCardType type);
        public void GetCustomerFunnyCard(Customer customer);

    }
}
