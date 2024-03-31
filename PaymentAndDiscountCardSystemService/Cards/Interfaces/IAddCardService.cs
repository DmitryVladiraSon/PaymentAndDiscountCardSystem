using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    public interface IAddCardService
    {
        Task<IBaseResponse<Customer>> ToCustomer(Guid customerId, DiscountCardType cardType);
    }
}
