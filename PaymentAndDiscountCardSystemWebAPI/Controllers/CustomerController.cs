using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueryService _customerQueryService;
        private readonly ICustomerCreationService _customerCreationService;

        public CustomerController(
            ICustomerQueryService getCustomerService,
            ICustomerCreationService customerCreationService)
        {
            _customerQueryService = getCustomerService;
            _customerCreationService = customerCreationService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            var response = await _customerCreationService.Create(customerViewModel);
            if (response.StatusCode == PaymentAndDiscountCardSystemDomain.Enum.StatusCode.OK)
            {
                return Ok(response.Data);
            }
            
            else return BadRequest(response.Description);
        }



        [HttpGet]
        public async Task<IActionResult> Get(Guid customerId)
        {
            var response = await _customerQueryService.GetById(customerId);
            
           if(response == null)
            {
                return BadRequest(response.Description);
            }

            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid customerId, CustomerViewModel customerViewModel)
        {
            await _customerCreationService.Update(customerId, customerViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid customerId)
        {
            await _customerCreationService.Delete(customerId);
            return Ok();
        }
    }
}




