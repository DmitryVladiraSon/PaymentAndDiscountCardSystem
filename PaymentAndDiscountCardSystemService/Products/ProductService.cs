using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystemDAL.Repositories.ProductRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemService.Products
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger,IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Guid> Create(ProductDTO productViewModel)
        {
            var productId = await _productRepository.Create(productViewModel);

            return productId;
        }

        public async Task<bool> Delete(Guid productId)
        {
            var result = await _productRepository.Delete(productId);

            return result;
        }

        public async Task<Product> Update(Guid productId, ProductDTO product)
        {
            var newProduct = await _productRepository.Update(productId, product);
            return newProduct;
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products;
        }

        public async Task<Product> Get(Guid productId)
        {
            var product = await _productRepository.Get(productId);
            return product;
        }
    }
}
