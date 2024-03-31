using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemDAL.Entity
{
    public class CustomerEntity
    {
        [Key]
       public Guid Id { get; set; }
    }
}
