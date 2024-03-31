using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystemDAL.Repositories.DiscountCardRepository;
using PaymentAndDiscountCardSystemService.Cards.Implementation;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var response = await _addCardService.ToCustomer(customerId,discountCardType);
            return Ok(response.Description);
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
