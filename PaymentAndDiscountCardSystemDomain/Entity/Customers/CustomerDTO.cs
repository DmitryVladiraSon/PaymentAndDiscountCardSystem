using System.ComponentModel.DataAnnotations;

namespace PaymentAndDiscountCardSystemDomain.Entity.Customers
{
    public class CustomerDTO
    {
        [Required]
        [MaxLength(7)]
        public string Name { get; set; }
    }
}
