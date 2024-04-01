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

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            var response =  await _productService.Create(model);
            return Ok(response.Data);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Guid productId, ProductViewModel model)
        {
            var response =  await _productService.Update(productId,model);
            return Ok(response.Data);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var response =  await _productService.Get(productId);
            return Ok(response.Data);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Update(Guid productId)
        {
            var response =  await _productService.Delete(productId);
            return Ok(response.Data);
        }
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response =  await _productService.GetAll();
            return Ok(response.Data);
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
