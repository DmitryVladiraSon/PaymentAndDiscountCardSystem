using Microsoft.AspNetCore.Mvc;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    public class OrderController : ControllerBase
    {
        public IActionResult CreateOrder()
        {
            return Ok();
        }

        public IActionResult PUSH_ORDER()
        {
            return Ok();
        }

        public IActionResult DeleteOrder()
        {
            return Ok();
        }
    }
}
