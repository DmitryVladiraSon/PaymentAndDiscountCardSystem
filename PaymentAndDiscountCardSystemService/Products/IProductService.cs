using PaymentAndDiscountCardSystemDomain.Entity.Products;


namespace PaymentAndDiscountCardSystemService.Products
{
    public interface IProductService
    {
        Task<Guid> Create(ProductDTO product);
        Task<Product> Update(Guid productId, ProductDTO product);
        Task<Product> Update(Product product);
        Task<Product> Get(Guid productId);
        Task<List<Product>> GetAll();
        Task<bool> Delete(Guid productId);
    }
}
