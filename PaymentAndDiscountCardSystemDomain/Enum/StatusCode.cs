using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemDomain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,

        OK = 200,
        BadRequest = 400, 
        InternalServerError = 500
    }
}
