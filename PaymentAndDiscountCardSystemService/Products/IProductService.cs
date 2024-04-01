using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Products;


namespace PaymentAndDiscountCardSystemService.Products
{
    public interface IProductService
    {
        Task<IBaseResponse<Guid>> Create(ProductViewModel product);
        Task<IBaseResponse<Product>> Update(Guid productId, ProductViewModel product);
        Task<IBaseResponse<Product>> Update(Product product);
        Task<IBaseResponse<Product>> Get(Guid productId);
        Task<IBaseResponse<List<Product>>> GetAll();
        Task<IBaseResponse<bool>> Delete(Guid productId);
    }
}
