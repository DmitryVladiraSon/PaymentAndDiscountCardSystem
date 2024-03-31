using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICustomerQueryService
    {
        Task<IBaseResponse<Customer>> GetById(Guid customerId);
        Task<IBaseResponse<Customer>> GetByName(string name);
    }
}
