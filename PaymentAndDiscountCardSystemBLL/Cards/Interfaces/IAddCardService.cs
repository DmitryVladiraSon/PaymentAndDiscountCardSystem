using PaymentAndDiscountCardSystemDomain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Cards.Interfaces
{
    public interface IAddCardService
    {
        Task<Customer> ToCustomer(Guid customerId, DiscountCardType cardType);
    }
}
