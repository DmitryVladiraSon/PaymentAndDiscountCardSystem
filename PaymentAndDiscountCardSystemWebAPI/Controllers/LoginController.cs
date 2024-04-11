using Microsoft.AspNetCore.Mvc;
using PaymentAndDiscountCardSystemDomain.Entity.Users;
using PaymentAndDiscountCardSystemService.Users;

namespace PaymentAndDiscountCardSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        {
            await _userService.Register(user.Name, user.Email, user.Password);



            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var token = await _userService.Login(request.Email, request.Password);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok(token);
        }
    }
}
