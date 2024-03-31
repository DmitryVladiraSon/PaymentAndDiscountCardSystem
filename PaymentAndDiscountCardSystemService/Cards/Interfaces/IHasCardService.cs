using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    public interface IHasCardService
    {
        bool FromCustomer(Customer customer, DiscountCardType cardType);
    }
}
