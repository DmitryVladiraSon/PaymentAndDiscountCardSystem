using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByName(string name);
    }
}
