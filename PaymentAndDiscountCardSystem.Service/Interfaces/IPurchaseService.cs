
using PaymentAndDiscountCardSystem.Domain.Entity;

namespace PaymentAndDiscountCardSystem.Service.Interfaces
{
    internal interface IPurchaseService
    {
        void Purchase(Customer customer,decimal amount);
    }
}
