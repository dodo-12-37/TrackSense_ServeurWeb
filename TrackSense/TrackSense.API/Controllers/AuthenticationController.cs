using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.ComponentModel.DataAnnotations;
using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Models;
using TrackSense.API.Services.ServiceUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackSense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ManipulationUsers m_depotUser;
        public AuthenticationController(ManipulationUsers _depotUser)
        {
            m_depotUser = _depotUser;
        }


        // POST api/<AuthenticationController>

        [HttpPost("SignUp")]
        public ActionResult SignUp(SignUpModel p_signUpModel)
        {
            ActionResult result;
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            if(p_signUpModel.Password != p_signUpModel.PasswordConfirmed)
            {
                return BadRequest("Password not match");
            }

            try
            {
               m_depotUser.Signup(p_signUpModel.UserLogin,p_signUpModel.Password,p_signUpModel.Email,p_signUpModel.FirstName,p_signUpModel.LastName);
                result = CreatedAtAction(nameof(Created),new UserModel(p_signUpModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

            return result;
        }


        // POST api/<AuthenticationController>
        [HttpPost("Login")]
        public ActionResult Login(SignInModel p_signInModel)
        {
            ActionResult result;
            string token;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                token = m_depotUser.Login(p_signInModel.UserLogin,p_signInModel.Password);

                Response.Cookies.Append("auth_token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(30)
                });
                var userToken = new UserToken() { Token = token, UserLogin = p_signInModel.UserLogin };
                return Ok(new UserTokenModel(userToken));
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

                                  
        }
    }
}
