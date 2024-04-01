using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository
{
    public interface IOrderRepository 
    {
        Task<IBaseResponse<Order>> Create(Guid customerID);
    }
}
