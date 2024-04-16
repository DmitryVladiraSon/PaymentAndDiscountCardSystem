using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemBLL.Auth;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(ILoginService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegistrationCustomerRequest request)
        {
            await _userService.Register(request.Name, request.Email, request.Password);

            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCustomerRequest request)
        {
            var token = await _userService.Login(request.Email, request.Password);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok(token);
        }
    }
}
