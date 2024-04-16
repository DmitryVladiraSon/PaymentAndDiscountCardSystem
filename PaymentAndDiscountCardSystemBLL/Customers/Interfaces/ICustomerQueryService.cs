using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Customers.Interfaces
{
    public interface ICustomerQueryService
    {
        Task<Customer>? GetById(Guid customerId);
        Task<List<Customer>?> GetByName(string name);
        Task<Customer>? GetByEmailAsync(string email);

    }
}
