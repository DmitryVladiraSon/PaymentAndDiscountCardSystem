using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemBLL.Orders;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(Guid customerId)
        {
            var orderId = await _orderService.Create(customerId);
            return Ok(orderId);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            var order = await _orderService.Get(orderId);
            return Ok(order);
        }
        
        [HttpGet]
        [Route("GetFromCustomer")]
        public async Task<IActionResult> GetFromCustomer(Guid customerId)
        {
            var orders = await _orderService.GetFromCustomer(customerId);
            return Ok(orders);
        }

        //public IActionResult DeleteOrder()
        //{
        //    return Ok();
        //}
        //public IActionResult PUSH_ORDER()
        //{
        //    return Ok();
        //}
    }
}
