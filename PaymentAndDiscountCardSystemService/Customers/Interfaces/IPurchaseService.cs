namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public interface IPurchaseService
    {
        void Purchase(Guid id, decimal amount);
    }
}
