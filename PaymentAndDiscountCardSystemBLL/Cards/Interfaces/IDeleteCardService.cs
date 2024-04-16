using PaymentAndDiscountCardSystemDomain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Cards.Interfaces
{
    public interface IDeleteCardService
    {
        void FromCustomer(Customer customer, DiscountCardType cardType);
    }
}
