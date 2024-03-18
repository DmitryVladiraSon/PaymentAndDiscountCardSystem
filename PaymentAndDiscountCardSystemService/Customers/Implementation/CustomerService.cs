using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;

namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger; 
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger; ;
        }
        //public void Add(Customer customer)
        //{
        //    try
        //    {
        //        _customerRepository.Create(customer);
        //        _logger.LogInformation($"Customer added. Id:{customer.Id} Name:{customer.Name} ");
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Customer didn't add");
        //        throw;
        //    }
        //}

        //public Customer GetById(Guid id)
        //{
        //    return _customerRepository.FirstOrDefault(c => c.Id == id);
        //}

        public Customer GetByName(string name)
        {
            return _customerRepository.FirstOrDefault(c => c.Name == name);
        }

        public Card GetCard(Customer customer, DiscountCardType type)
        {
            throw new NotImplementedException();
        }

        public void GetCustomerFunnyCard(Customer customer)// Метод называется выдача карты, но по логике она активируется.
        {
            customer.Cards.Find(c => c.Type == DiscountCardType.FunnyCard).IsActive = true;
        }
    }
}
