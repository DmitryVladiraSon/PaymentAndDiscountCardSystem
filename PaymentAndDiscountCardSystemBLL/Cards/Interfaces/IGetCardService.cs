using PaymentAndDiscountCardSystemDomain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Cards.Interfaces
{
    internal interface IGetCardService
    {
        DiscountCard ByCardType(DiscountCardType type);
        DiscountCard ByCustomer(Customer customer);
    }
}
