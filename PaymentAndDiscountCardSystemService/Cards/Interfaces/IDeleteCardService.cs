using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    public interface IDeleteCardService
    {
        void FromCustomer(Customer customer, DiscountCardType cardType);
    }
}
