using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    public class AddCardService : IAddCardService
    {
        private readonly IGetCustomerService _getCustomerService;
        private readonly ILogger<AddCardService> _logger;

        public AddCardService(IGetCustomerService getCustomerService, ILogger<AddCardService> logger)
        {
            _getCustomerService = getCustomerService;
            _logger = logger;
        }

        public bool ToCustomer(Customer customer, DiscountCardType cardType)
        {
            switch (cardType)
            {
                case DiscountCardType.Tube:
                    
                    foreach(Card card in customer.Cards)
                    {
                        if (card.Type == cardType) return false;
                    }
                    customer.Cards.Add(new DiscountCard(DiscountCardType.Tube));
                    return true;

                case DiscountCardType.Transistor:
                    //Check duplicate 
                    foreach (Card card in customer.Cards)
                    {
                        if (card.Type == cardType) return false; 
                    }
                    customer.Cards.Add(new DiscountCard(DiscountCardType.Transistor));
                    return true;

                case DiscountCardType.Integrated:
                    foreach (Card card in customer.Cards)
                    {
                        if (card.Type == cardType) return false;
                    }
                    customer.Cards.Add(new DiscountCard(DiscountCardType.Integrated));
                    return true;

                case DiscountCardType.Quantum:
                    foreach (Card card in customer.Cards)
                    {
                        if (card.Type == cardType) return false;
                    }
                    customer.Cards.Add(new QuantumCard());
                    return true;

                case DiscountCardType.FunnyCard:
                    foreach (Card card in customer.Cards)
                    {
                        if (card.Type == cardType) return false;
                    }
                    customer.Cards.Add(new FunnyCard());
                    return true;
                default:
                    return false;
            };
        }
    }
}
