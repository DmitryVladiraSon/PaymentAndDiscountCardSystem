
using PaymentAndDiscountCardSystem.Domain.Entity;

namespace PaymentAndDiscountCardSystem.Service.Interfaces
{
    internal interface IPurchaseService
    {
        void Purchase(Guid id, decimal amount);
    }
}
