using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerDTO>
    {
        Task<List<Customer>> GetWithoutCard();
        Task<IQueryable<Customer>> GetAllAsync();
    }
}
