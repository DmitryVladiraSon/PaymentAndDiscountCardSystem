using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Customers.Interfaces
{
    public interface IGetCustomerService
    {
        Customer GetById(Guid customerId);
        Customer GetByName(string name);
    }
}
