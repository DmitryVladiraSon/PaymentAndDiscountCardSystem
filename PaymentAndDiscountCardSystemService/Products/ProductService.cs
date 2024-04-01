using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Response;
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

        public async Task<IBaseResponse<Guid>> Create(ProductViewModel productViewModel)
        {
            var response = new BaseResponse<Guid>();
            var productId = await _productRepository.Create(productViewModel);
            response.Data = productId;

            return response;
        }

        public async Task<IBaseResponse<bool>> Delete(Guid productId)
        {
            var response = new BaseResponse<bool>();
            var result = await _productRepository.Delete(productId);
            response.Data = result;

            return response;
        }

        public async Task<IBaseResponse<Product>> Update(Guid productId, ProductViewModel product)
        {
            var response = new BaseResponse<Product>();
            var newProduct = await _productRepository.Update(productId, product);
            response.Data = newProduct;
            return response;
        }

        public Task<IBaseResponse<Product>> Update(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<List<Product>>> GetAll()
        {
            var response = new BaseResponse<List<Product>>();
            response.Data = await _productRepository.GetAll();
            return response;
        }

        public async Task<IBaseResponse<Product>> Get(Guid productId)
        {
            var response = new BaseResponse<Product>();
            response.Data = await _productRepository.Get(productId);
            return response;
        }
    }
}
