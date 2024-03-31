using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    public interface IDeleteCardService
    {
        void FromCustomer(Customer customer, DiscountCardType cardType);
    }
}
