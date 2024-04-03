using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDbContext _DbContext;

        public CustomerRepository()
        {
        }

        public CustomerRepository(StoreDbContext storeDBContext)
        {
            _DbContext = storeDBContext;
        }

        public List<Customer> Entities => throw new NotImplementedException();

        public async Task<Guid> Create(CustomerDTO customerViewModel)
        {
            if (customerViewModel == null)
            {
                throw new ArgumentNullException(nameof(customerViewModel));
            }
            await _DbContext.Customers.AddAsync(new Customer(customerViewModel.Name));
            await _DbContext.SaveChangesAsync();
            var customer = await _DbContext.Customers.FirstAsync(c=>c.Name == customerViewModel.Name);
            return customer.Id;
        }

        public async Task<bool> Delete(Guid customerId)
        {
           await _DbContext.Customers
                .Where(c => c.Id == customerId)
                .ExecuteDeleteAsync();
            return true;
        }

        public async Task<Customer> Get(Guid customerId)
        {
            var customer = await _DbContext.Customers
                    .Where(c => c.Id == customerId)
                    .Include(c => c.DiscountCards)
                    .FirstOrDefaultAsync();

            //if (customer == null)
            //{
            //    throw new Exception($"Customer with id {customerId} not found.");
            //}
            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _DbContext.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }
            else
            {
                return await _DbContext.Customers
                    .Where(c => c.Name == name)
                    .Include(c => c.DiscountCards)
                    .SingleOrDefaultAsync();
            }
        }

        public async Task<List<Customer>> GetWithoutCard()
        {
            return await _DbContext.Customers
                .AsNoTracking()
                .Where(c => c.DiscountCards.Count == 0)
                .ToListAsync();
        }

        public async Task<Customer> Update(Guid customerId, CustomerDTO customerViewModel)
        {
               await _DbContext.Customers
                    .Where(c => c.Id == customerId)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, customerViewModel.Name));

               await _DbContext.SaveChangesAsync();
               return await _DbContext.Customers.FindAsync(customerId);
        }

        public async Task<Customer> Update(Customer customer)
            {
            // Обновление свойств сущности Customer
            await _DbContext.Customers
                .Where(c => c.Id == customer.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, customer.Name)
                    .SetProperty(c => c.AccumulatedAmount, customer.AccumulatedAmount));

            // Обновление коллекции DiscountCards отдельно
            var existingCustomer = await _DbContext.Customers
                .Include(c => c.DiscountCards)
                .FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (existingCustomer != null)
            {
                // Удаление любых скидочных карт, которые были удалены из коллекции
                var removedCards = existingCustomer.DiscountCards
                    .Where(dc => !customer.DiscountCards.Contains(dc))
                    .ToList();

                foreach (var card in removedCards)
                {
                    existingCustomer.DiscountCards.Remove(card);
                }

                // Добавление любых новых скидочных карт в коллекцию
                var newCards = customer.DiscountCards
                    .Where(dc => !existingCustomer.DiscountCards.Contains(dc))
                    .ToList();

                foreach (var card in newCards)
                {
                    existingCustomer.DiscountCards.Add(card);
                }
            }

            // Сохранение изменений в базе данных
            await _DbContext.SaveChangesAsync();

            // Возврат обновленной сущности Customer
            return await _DbContext.Customers.FindAsync(customer.Id);
        }
    }
}
