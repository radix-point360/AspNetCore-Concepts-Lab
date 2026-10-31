using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("GetAnonymousData")]
        public IActionResult GetAnonymousData()
        {
            var currentUsername = User.Identity?.Name;
            return Ok(new { message = $"Hello { currentUsername }, you have accessed anonymous data!" });
        }

        [Authorize]
        [HttpGet("GetAuthData")]
        public IActionResult GetAuthData()
        {
            var currentUsername = User.Identity?.Name;
            return Ok(new { message = $"Hello {currentUsername}, you have accessed secured data!" });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("GetRoleData")]
        public IActionResult GetRoleData()
        {
            var currentUsername = User.Identity?.Name;
            return Ok(new { message = $"Hello {currentUsername}, you have accessed role-secured data!" });
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("GetCustomerData")]
        public IActionResult GetCustomerData()
        {
            var currentUsername = User.Identity?.Name;
            return Ok(new { message = $"Hello {currentUsername}, you have accessed customer-secured data!" });
        }
    }
}
