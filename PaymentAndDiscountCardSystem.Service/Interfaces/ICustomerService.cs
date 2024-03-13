using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Service.Interfaces
{
    internal interface ICustomerService
    {
        Customer GetById(Guid id);
        Customer GetByName(string name);
        void Add(Customer customer);
        public Card GetCard(Customer customer, DiscountCardType type);
        public void GetCustomerFunnyCard(Customer customer);

    }
}
