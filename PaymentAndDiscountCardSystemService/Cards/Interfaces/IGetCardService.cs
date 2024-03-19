﻿using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Interfaces
{
    internal interface IGetCardService
    {
        Card ByCardType(DiscountCardType type);
        Card ByCustomer(Customer customer);
    }
}
