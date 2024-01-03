using Backery.Interface;
using Backery.Modell;
using Microsoft.AspNetCore.Mvc;

namespace Backery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication authServices;

        public AuthController(IAuthentication authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await authServices.Registration(model);

            if (!result.IsAuth)
            {
                return Ok(new Data { Message = result.Massege });
            }
            var ret = new Data { Message = "Succedd" };
            return Ok(ret);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await authServices.Login(model);

            if (!result.IsAuth)
            {
                return Ok(new Data { Message = result.Massege });
            }
            var ret = new Data { Message = "Succedd", Token = result.Token };
            return Ok(ret);

        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authServices.AddRole(model);

            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }

            return Ok(model);

        }
    }
}
