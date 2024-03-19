using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
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
                        customer.Cards.Add(new DiscountCard(DiscountCardType.Tube));
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
                        customer.Cards.Add(new DiscountCard(DiscountCardType.Transistor));
                        break;
                    }

                case DiscountCardType.Integrated:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new DiscountCard(DiscountCardType.Integrated));
                        break;
                    }

                case DiscountCardType.Quantum:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new DiscountCard(DiscountCardType.Quantum));
                        break;
                    }

                case DiscountCardType.FunnyCard:
                    if (HasDuplicateCard(customer, cardType))
                    {
                        break;
                    }
                    else
                    {
                        customer.Cards.Add(new DiscountCard(DiscountCardType.FunnyCard));
                        break;
                    }
                default:
                    break;
            };
        }

        public bool HasDuplicateCard(Customer customer, DiscountCardType checkedCardType)
        {
            foreach (Card card in customer.Cards)
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
