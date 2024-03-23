using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
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

        public void ToCustomer(Customer customer, DiscountCardType cardType)
        {
            switch (cardType)
            {
                case DiscountCardType.Tube:

                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new AmountDiscountCard(DiscountCardType.Tube));
                        break;
                    }

                case DiscountCardType.Transistor:
                    //Check duplicate 
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new AmountDiscountCard(DiscountCardType.Transistor));
                        break;
                    }

                case DiscountCardType.Integrated:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new AmountDiscountCard(DiscountCardType.Integrated));
                        break;
                    }

                case DiscountCardType.Quantum:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new QuantumCard());
                        break;
                    }

                case DiscountCardType.FunnyCard:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new FunnyCard());
                        break;
                    }
                default:
                    break;
            };
        }

        public bool HasDuplicateCard(Customer customer, DiscountCardType checkedCardType)
        {
            foreach (DiscountCard card in customer.Cards)
            {
                if (card.Type == checkedCardType)
                {
                    _logger.LogInformation($"Customer {customer.Name} | {customer.Id} already have card {checkedCardType}");
                    return true;
                }
            }
            return false;
        }
    }
}
