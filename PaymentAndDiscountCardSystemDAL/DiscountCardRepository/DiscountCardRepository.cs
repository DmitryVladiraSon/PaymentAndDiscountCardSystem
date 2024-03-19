using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystemDAL.DiscountCardRepository
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        public List<Card> Entities {get;set;}
        public DiscountCardRepository()
        {
            Entities = new List<Card>
            {
                new DiscountCard(DiscountCardType.Tube),
                new DiscountCard(DiscountCardType.Transistor),
                new DiscountCard(DiscountCardType.Integrated),
                new FunnyCard(),
                new QuantumCard()
            };
        }
        
        public void Create(Card entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<Card> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Task<List<Card>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<Card> Update(Card entity)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
