using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;


namespace PaymentAndDiscountCardSystemService.Cards.Implementation
{
    public class AddCardService : IAddCardService
    {
        private readonly ICustomerQueryService _customerQueryService;
        private readonly ICustomerCreationService _customerCreationService;
        private readonly ILogger<AddCardService> _logger;

        public AddCardService(ICustomerQueryService customerQueryService,
            ICustomerCreationService customerCreationService,
            ILogger<AddCardService> logger)
        {
            _customerQueryService = customerQueryService;
            _customerCreationService = customerCreationService;
            _logger = logger;
        }

        public async Task<Customer> ToCustomer(Guid customerId, DiscountCardType addedDiscountCardType)
        {
            var customer = await _customerQueryService.GetById(customerId);


            
            bool isAddedCard = false;
            foreach(DiscountCardType typeDiscountCard in Enum.GetValues(typeof(DiscountCardType)))
            {
                if(typeDiscountCard == addedDiscountCardType && !HasCustomerDuplicateCard(customer, addedDiscountCardType))
                {
                    switch (addedDiscountCardType)
                    {
                        case DiscountCardType.Tube:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Tube));
                            _logger.LogInformation($"A discount card {addedDiscountCardType} has been added to the customer {customerId}");
                            break;

                        case DiscountCardType.Transistor:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Transistor));
                            _logger.LogInformation($"A discount card {addedDiscountCardType} has been added to the customer {customerId}");
                            break;

                        case DiscountCardType.Integrated:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Integrated));
                            _logger.LogInformation($"A discount card {addedDiscountCardType} has been added to the customer {customerId}");
                            break;

                        case DiscountCardType.Quantum:
                            customer.DiscountCards.Add(new QuantumCard());
                            _logger.LogInformation($"A discount card {addedDiscountCardType} has been added to the customer {customerId}");
                            break;

                        case DiscountCardType.FunnyCard:
                            customer.DiscountCards.Add(new FunnyCard());
                            _logger.LogInformation($"A discount card {addedDiscountCardType} has been added to the customer {customerId}");
                            break;
                        default:
                            _logger.LogError($"this type of card '{addedDiscountCardType}' does not exist");
                            break;
                    }

                    break;
                }
                else
                {
                    _logger.LogError($"Customer '{customerId}' already has a Discount card '{addedDiscountCardType}'");
                }
            }
            await _customerCreationService.Update(customer);

            return customer;
        }

        public bool HasCustomerDuplicateCard(Customer customer, DiscountCardType checkedCardType)
        {
            foreach (DiscountCard card in customer.DiscountCards)
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
