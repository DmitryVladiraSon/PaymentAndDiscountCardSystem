using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemService.OrderItems;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        [Route("AddToOrder")]
        public async Task<IActionResult> AddToOrder(Guid orderId, Guid productId)
        {
            var response = await _orderItemService.AddToOrder(orderId, productId);
            return Ok(response.Data); 
        }

        [HttpPut]
        [Route("UpdateFormOrder")]
        public async Task<IActionResult> UpdateFormOrder(Guid orderItemId, int countOrderItem)
        {
            var response = await _orderItemService.UpdateFromOrder(orderItemId, countOrderItem);
            return Ok(response.Data);
        }

        [HttpDelete]
        [Route("RemoveFromOrder")]
        public async Task<IActionResult> Delete(Guid orderItemId)
        {
            var response = await _orderItemService.Delete(orderItemId);
            return Ok(response.Data);
        }
    }
}
