using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICustomerCreationService
    {
        Task<IBaseResponse<Customer>> Create(CustomerViewModel customer);
        Task<IBaseResponse<Customer>> Update(Guid customerId, CustomerViewModel customer);
        Task<IBaseResponse<Customer>> Update(Customer customer);
        Task<IBaseResponse<bool>> Delete(Guid customerId);
    }
}
