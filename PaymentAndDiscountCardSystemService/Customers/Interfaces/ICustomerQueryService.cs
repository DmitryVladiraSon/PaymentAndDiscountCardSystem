using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICustomerQueryService
    {
        Task<Customer> GetById(Guid customerId);
        Task<Customer> GetByName(string name);
    }
}
