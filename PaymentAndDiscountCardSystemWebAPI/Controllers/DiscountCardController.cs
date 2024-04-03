using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCardController : ControllerBase
    {
        private readonly IAddCardService _addCardService;
        private readonly IDeleteCardService _deleteCardService;

        public DiscountCardController(
            IAddCardService addCardService, 
            IDeleteCardService deleteCardService)
        {
            _addCardService = addCardService;
            _deleteCardService = deleteCardService;
        }

        [HttpPost]
        [Route("AddToCustomer")]
        public async Task<IActionResult> AddToCustomer(Guid customerId, DiscountCardType discountCardType)
        {
            var customer = await _addCardService.ToCustomer(customerId,discountCardType);
            return Ok(customer);
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
