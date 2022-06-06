using ASP_Project.Managers;
using ASP_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignupUserModel model)
        {
            try
            {
                await authenticationManager.Signup(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("ERROR!!!");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            try
            {
                var tokens = await authenticationManager.Login(model);

                if (tokens != null)     // if we get null from manager
                    return Ok(tokens);
                else
                {
                    return BadRequest("ERROR!!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("AN EXCEPTION OCCURRED!!!");
            }
        }
    }
}
