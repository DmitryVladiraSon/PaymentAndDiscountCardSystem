namespace PaymentAndDiscountCardSystemDAL.Repositories
{
    public interface IBaseRepository<T, TModelDTO>
    {
        List<T> Entities { get; }

        Task<Guid> Create(TModelDTO entityDTO);

        Task<T> Get(Guid id);

        Task<List<T>> GetAll();

        Task<bool> Delete(Guid entityId);

        Task<T> Update(Guid entityId, TModelDTO entityDTO);
        Task<T> Update(T entity);

    }
}
