using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Enum;
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

        public async Task<IBaseResponse<Customer>> ToCustomer(Guid customerId, DiscountCardType addedDiscountCardType)
        {
            var response = await _customerQueryService.GetById(customerId);
            if(response.StatusCode == StatusCode.BadRequest)
            {
                return response;
            }

            var customer = response.Data;
            var log = string.Empty;
            
            bool isAddedCard = false;
            foreach(DiscountCardType typeDiscountCard in Enum.GetValues(typeof(DiscountCardType)))
            {
                if(typeDiscountCard == addedDiscountCardType && !HasCustomerDuplicateCard(customer, addedDiscountCardType))
                {
                    switch (addedDiscountCardType)
                    {
                        case DiscountCardType.Tube:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Tube));
                            log = $"A discount card {addedDiscountCardType} has been added to the customer {customerId}";
                            _logger.LogInformation(log);
                            break;

                        case DiscountCardType.Transistor:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Transistor));
                            log = $"A discount card {addedDiscountCardType} has been added to the customer {customerId}";
                            _logger.LogInformation(log);
                            break;

                        case DiscountCardType.Integrated:
                            customer.DiscountCards.Add(new AmountDiscountCard(DiscountCardType.Integrated));
                            log = $"A discount card {addedDiscountCardType} has been added to the customer {customerId}";
                            _logger.LogInformation(log);
                            break;

                        case DiscountCardType.Quantum:
                            customer.DiscountCards.Add(new QuantumCard());
                            log = $"A discount card {addedDiscountCardType} has been added to the customer {customerId}";
                            _logger.LogInformation(log);
                            break;

                        case DiscountCardType.FunnyCard:
                            customer.DiscountCards.Add(new FunnyCard());
                            log = $"A discount card {addedDiscountCardType} has been added to the customer {customerId}";
                            _logger.LogInformation(log);
                            break;
                        default:
                            log = $"this type of card '{addedDiscountCardType}' does not exist";
                            _logger.LogError(log);
                            break;
                    }

                    break;
                }
                else
                {
                    log = $"Customer '{customerId}' already has a Discount card '{addedDiscountCardType}'";
                    _logger.LogError(log);
                }
            }
            response.Description = log;
            await _customerCreationService.Update(customer);

            return response;
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
