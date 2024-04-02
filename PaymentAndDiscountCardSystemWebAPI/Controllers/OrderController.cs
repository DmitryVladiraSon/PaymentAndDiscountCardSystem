using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemService.Orders;

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
            var response = await _orderService.Create(customerId);
            return Ok(response.Data);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            var response = await _orderService.Get(orderId);
            return Ok(response.Data);
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
