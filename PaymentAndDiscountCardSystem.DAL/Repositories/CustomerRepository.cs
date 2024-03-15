using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.Domain.Entity;
using System;
using System.Collections;
using System.Xml.Linq;

namespace PaymentAndDiscountCardSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly List<Customer> _entities = new List<Customer>();

        public List<Customer> Entities => _entities;

        public async Task<bool> Create(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

public async Task<Customer> Get(Guid id)
{
    var customer = _entities.FirstOrDefault(c => c.Id == id);
    if (customer == null)
    {
        throw new Exception($"Customer with id {id} not found.");
    }
    return customer;
}

        public async Task<Customer> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }

            var customer = _entities.Find(c => c.Name == name);
            return customer ?? throw new Exception($"Customer with name '{name}' not found.");
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        public Task<List<Customer>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
