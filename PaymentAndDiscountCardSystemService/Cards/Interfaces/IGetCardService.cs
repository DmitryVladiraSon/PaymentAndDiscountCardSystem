using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    internal interface IGetCardService
    {
        DiscountCard ByCardType(DiscountCardType type);
        DiscountCard ByCustomer(Customer customer);
    }
}
