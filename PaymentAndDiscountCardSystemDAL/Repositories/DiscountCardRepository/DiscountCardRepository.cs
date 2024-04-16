using PaymentAndDiscountCardSystemDomain.Entity.Cards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;

namespace PaymentAndDiscountCardSystemDAL.Repositories.DiscountCardRepository
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        public List<DiscountCard> Entities { get; set; }
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

        public async Task<bool> Create(DiscountCard entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(DiscountCard entity)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountCard> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountCard> Update(DiscountCard entity)
        {
            throw new NotImplementedException();
        }
        public Task<List<DiscountCard>> GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Guid> IBaseRepository<DiscountCard, DiscountCard>.Create(DiscountCard entityModelView)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountCard> Update(Guid entityId, DiscountCard entityModelView)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
