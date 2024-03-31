
namespace PaymentAndDiscountCardSystem.DAL.Interfaces
{
    public interface IBaseRepository<T, TModelView>
    {
        List<T> Entities { get; }

        Task<Guid> Create(TModelView entityModelView);

        Task<T> Get(Guid id);

        Task<List<T>> GetAll();

        Task<bool> Delete(T entity);

        Task<T> Update(Guid entityId, TModelView entityModelView);
        Task<T> Update(T entity);

    }
}
