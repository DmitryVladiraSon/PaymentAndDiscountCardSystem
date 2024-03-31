using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerViewModel>
    {
        Task<Customer> GetByName(string name);
        Task<List<Customer>> GetWithoutCard();
    }
}
