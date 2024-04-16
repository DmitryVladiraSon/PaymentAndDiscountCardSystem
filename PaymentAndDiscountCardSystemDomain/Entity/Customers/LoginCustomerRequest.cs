using System.ComponentModel.DataAnnotations;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public record LoginCustomerRequest
    (
        [Required] string Email,
        [Required] string Password
    );
}
