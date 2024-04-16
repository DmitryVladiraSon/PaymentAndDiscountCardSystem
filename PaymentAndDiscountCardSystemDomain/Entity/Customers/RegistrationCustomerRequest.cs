using System.ComponentModel.DataAnnotations;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public record RegistrationCustomerRequest
    (
        [Required] string Name,        
        [Required] string Email,
        [Required] string Password
    );
}
