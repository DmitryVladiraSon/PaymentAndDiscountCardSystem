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
        public async Task<IActionResult> Create(CustomerDTO customerViewModel)
        {
            var customerId = await _customerCreationService.Create(customerViewModel);
            if (customerId != null)
            {
                return Ok(customerId);
            }
            
            else return BadRequest(customerId);
        }



        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            var customer = await _customerQueryService.GetById(customerId);
            
           if(customer == null)
            {
                return BadRequest(customer);
            }

            return Ok(customer);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Guid customerId, CustomerDTO customerViewModel)
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




