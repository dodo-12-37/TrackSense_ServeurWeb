using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackSense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteUsersController : ControllerBase
    {
        private readonly IDepotCompteUser m_depotUser;
        public CompteUsersController(IDepotCompteUser _depotUser)
        {
            m_depotUser = _depotUser;
        }
 

        // POST api/<CompteUsersController>
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel p_signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await m_depotUser.SignUpAsync(p_signUpModel);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Succeeded);
        }
      

        // POST api/<CompteUsersController>
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel p_signInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await m_depotUser.SignInAsync(p_signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
