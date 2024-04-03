using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICustomerCreationService
    {
        Task<Guid?> Create(CustomerDTO customer);
        Task<Customer> Update(Guid customerId, CustomerDTO customer);
        Task<Customer> Update(Customer customer);
        Task<bool> Delete(Guid customerId);
    }
}
