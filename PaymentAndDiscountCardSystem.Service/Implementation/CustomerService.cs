using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Service.Interfaces;

namespace PaymentAndDiscountCardSystem.Service.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly ILogger<CustomerService> _logger; // Логгер 
        private readonly ICustomerRepository _customerRepo;

        // IEnumerable
        // List
        //


        public CustomerService(ICustomerRepository customers, ILogger<CustomerService> logger)//, ILogger logger)
        {
            _customerRepo = customers;
            _logger = logger; ;
        }
        public void Add(Customer customer)
        {
            try
            {
                _customerRepo.Create(customer);
                _logger.LogInformation($"Customer added. Id:{customer.Id} Name:{customer.Name} ");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Customer didn't add");
                throw;
            }
              }

        public Customer GetById(Guid id) //
        {
            return _customerRepo.FirstOrDefault(c => c.Id == id); 
        }

        public Customer GetByName(string name)
        {
            return _customerRepo.FirstOrDefault(c => c.Name == name);
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
