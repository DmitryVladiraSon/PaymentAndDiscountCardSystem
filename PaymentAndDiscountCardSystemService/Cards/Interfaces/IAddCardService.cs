using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    public interface IAddCardService
    {
        Task<Customer> ToCustomer(Guid customerId, DiscountCardType cardType);
    }
}
