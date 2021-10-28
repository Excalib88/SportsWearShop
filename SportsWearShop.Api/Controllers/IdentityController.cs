using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsWearShop.Api.Domain.Identity.Models;
using SportsWearShop.Api.Domain.Identity.Services;

namespace SportsWearShop.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _userService;

        public IdentityController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _userService.Login(request);
            
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto request)
        {
            var result = await _userService.Register(request);
            
            return Ok(result);
        }
    }
}