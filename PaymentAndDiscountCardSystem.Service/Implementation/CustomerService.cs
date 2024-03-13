using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Service.Interfaces;

namespace PaymentAndDiscountCardSystem.Service.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly List<Customer> _customers; // Вот это сделать интерфесом
        private readonly ILogger _logger; // Логгер 

        // IEnumerable
        // List
        //

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        public CustomerService(List<Customer> customers)//, ILogger logger)
        {
            _customers = customers;
            _logger = loggerFactory.CreateLogger<CustomerService>();
        }
        public void Add(Customer customer)
        {
            try
            {
                _customers.Add(customer);
                _logger.LogInformation($"Customer added. Id:{customer.Id} Name:{customer.Name} ");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Customer didn't add");
                throw;
            }
              }

        public Customer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            return _customers.Find(c => c.Name == name);
        }

        public Card GetCard(Customer customer, DiscountCardType type)
        {
            throw new NotImplementedException();
        }

        public void GetCustomerFunnyCard(Customer customer)// Метод называется выдача карты, но по логике она активируется.
        {
            customer.Cards.Find(c => c.Type == DiscountCardType.Cheerful).IsActive = true;
        }
    }
}
