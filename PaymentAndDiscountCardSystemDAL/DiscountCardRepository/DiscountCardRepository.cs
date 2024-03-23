using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
using System.Collections;

namespace PaymentAndDiscountCardSystemDAL.DiscountCardRepository
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        public List<DiscountCard> Entities {get;set;}
        public DiscountCardRepository()
        {
            Entities = new List<DiscountCard>
            {
                new AmountDiscountCard(DiscountCardType.Tube),
                new AmountDiscountCard(DiscountCardType.Transistor),
                new AmountDiscountCard(DiscountCardType.Integrated),
                new FunnyCard(),
                new QuantumCard()
            };
        }
        
        public void Create(DiscountCard entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DiscountCard entity)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountCard> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DiscountCard> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Task<List<DiscountCard>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<DiscountCard> Update(DiscountCard entity)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
