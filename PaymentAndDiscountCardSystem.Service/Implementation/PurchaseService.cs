

using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Service.Interfaces;

namespace PaymentAndDiscountCardSystem.Service.Implementation
{
    internal class PurchaseService : IPurchaseService
    {
        private CustomerService _customerService;
        private List<Customer> _customers;
        public PurchaseService()
        {
          //  _customerService = customerService;
        }
        public void Purchase(Customer customer, decimal amount)
        {
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
