using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemBLL.Customers.Validation
{
    public class CustomerValidator :  AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
              RuleFor(c=>c.Name).NotEmpty().NotEqual("foo");
        }

    }
}
