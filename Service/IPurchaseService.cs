using PaymentAndDiscountCardSystem.Models;

namespace PaymentAndDiscountCardSystem.Service
{
    internal interface IPurchaseService
    {
        void Purchase(Customer customer,decimal amount);
    }
}
