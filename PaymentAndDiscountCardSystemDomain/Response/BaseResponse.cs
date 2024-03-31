using PaymentAndDiscountCardSystemDomain.Enum;

namespace PaymentAndDiscountCardSystem.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        string Description { get; set; }

        StatusCode StatusCode { get; }
        public T Data { get; }
    }
}
