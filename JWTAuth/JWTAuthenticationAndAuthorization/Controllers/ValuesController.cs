using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecureData()
        {
            var currentUsername = User.Identity?.Name;
            return Ok(new { message = $"Hello {currentUsername}, you have accessed secured data!" });
        }
    }
}
