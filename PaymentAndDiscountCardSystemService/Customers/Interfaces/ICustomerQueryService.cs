using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICustomerQueryService
    {
        Task<Customer>? GetById(Guid customerId);
        Task<List<Customer>?> GetByName(string name);
    }
}
