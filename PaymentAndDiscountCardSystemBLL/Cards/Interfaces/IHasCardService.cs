using PaymentAndDiscountCardSystemDomain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Cards.Interfaces
{
    public interface IHasCardService
    {
        bool FromCustomer(Customer customer, DiscountCardType cardType);
    }
}
