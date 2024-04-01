using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystem
{
    internal class DataInitializer
    {
        private readonly ICustomerCreationService _createCustomerService;
        private readonly IAddCardService _addCardService;

        public DataInitializer(ICustomerCreationService createCustomerService, IAddCardService addCardService)
        {
            _createCustomerService = createCustomerService;
            _addCardService = addCardService;
        }

        public void Initialize()
        {
            Customer customer1 = new Customer("Dima");
        }
    }
}
