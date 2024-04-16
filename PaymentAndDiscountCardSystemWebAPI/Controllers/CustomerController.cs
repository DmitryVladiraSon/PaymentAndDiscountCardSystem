using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Customers.Interfaces;
using PaymentAndDiscountCardSystemBLL.Customers.Validation;
using FluentValidation.Results;

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
        public async Task<IActionResult> Create(CustomerDTO customerDto)
        { 
            var customerId = await _customerCreationService.Create(customerDto);
            return Ok(customerId);
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            var customer = await _customerQueryService.GetById(customerId);

            if (customer == null)
            {
                return BadRequest();
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




