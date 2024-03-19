namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public interface IPurchaseService
    {
        void Purchase(Guid customerId, decimal amount);
    }
}
