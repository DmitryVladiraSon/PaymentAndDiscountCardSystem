using System.ComponentModel.DataAnnotations;

namespace PaymentAndDiscountCardSystemDomain.Entity.Users
{
    public record LoginUserRequest
    (
        [Required] string Email,
        [Required] string Password
    );
}

