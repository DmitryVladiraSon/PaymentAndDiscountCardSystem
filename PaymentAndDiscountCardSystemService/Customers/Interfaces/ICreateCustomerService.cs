using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface ICreateCustomerService
    {
        void Add(Customer customer);
    }
}
