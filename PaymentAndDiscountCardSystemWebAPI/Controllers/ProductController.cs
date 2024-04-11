using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.Products;
using PaymentAndDiscountCardSystemService.Products;
using PaymentAndDiscountCardSystemWebAPI.Data;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly DataInitializer _dataInitializer;

        public ProductController(IProductService productService, DataInitializer dataInitializer)
        {
            _productService = productService;
            _dataInitializer = dataInitializer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]

        [Route("Create")]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            var idNewCustomer =  await _productService.Create(model);
            return Ok(idNewCustomer);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Guid productId, ProductDTO model)
        {
            var newProduct =  await _productService.Update(productId,model);
            return Ok(newProduct);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var product =  await _productService.Get(productId);
            return Ok(product);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var wasDeleted =  await _productService.Delete(productId);
            return Ok(wasDeleted);
        }
        
        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var products =  await _productService.GetAll();
            return Ok(products);
        }      
        
        [HttpGet]
        [Route("AddProducts")]
        public async Task<IActionResult> AddProducts(int countProducts)
        {
            _dataInitializer.InitializeProducts(countProducts);
            return Ok();
        }
    }
}
