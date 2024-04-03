using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerDTO>
    {
        Task<Customer> GetByName(string name);
        Task<List<Customer>> GetWithoutCard();
    }
}
