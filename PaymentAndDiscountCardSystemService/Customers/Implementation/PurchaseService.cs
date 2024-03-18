

using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.DAL.Repositories;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;

namespace PaymentAndDiscountCardSystem.Service.Customers.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private CustomerService _customerService;
        private ICustomerRepository _customersRepo;
        private readonly ILogger<PurchaseService> _logger;
        public PurchaseService(ICustomerRepository customers,ILogger<PurchaseService> logger)
        {
            _customersRepo = customers;
            _logger = logger;
        }
        public async void Purchase(Guid customerId, decimal amount)
        {
            var customer = await _customersRepo.Get(customerId);

            AddingDiscountCardsToCustomer(customer);
            var priorityCard = customer.Cards.OrderByDescending(card => card.DiscountRate).Where(card => card.IsActive).FirstOrDefault();
            int discount = 0;
            if (priorityCard != null)
            {
                discount = priorityCard.DiscountRate;
            }
            var amountWithDiscount = amount - (amount / 100 * discount);
            customer.AccumulatedAmount += amount;

            Console.WriteLine($"amount {amount} with discount {discount}% = {amountWithDiscount} | Accumulated amount {customer.AccumulatedAmount}");
            _logger.LogInformation($"amount {amount} with discount {discount}% = {amountWithDiscount} | Accumulated amount {customer.AccumulatedAmount}");
            
            customer.AccumulatedAmount += amount;
        }



        private void AddingDiscountCardsToCustomer(Customer customer)
        {
            try
            {
                foreach (DiscountCard discountCard in customer.Cards)
                {
                    if (customer.AccumulatedAmount > discountCard.ThresholdAmount)
                    {
                        discountCard.IsActive = true;
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                //В логи записать, что-то, но пока сам не знаю, что ;)
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
