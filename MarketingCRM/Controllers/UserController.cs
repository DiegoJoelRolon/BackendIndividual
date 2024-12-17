using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponse>), 200)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
