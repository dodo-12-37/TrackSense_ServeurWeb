using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackSense.API.Entities;
using TrackSense.API.Models;
using TrackSense.API.Services.ServiceRides;
using TrackSense.API.Services.ServiceUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackSense.API.Controllers
{
    [Route("api/users/{p_login}/completedrides")]
    [ApiController]
    public class UserCompletedRidesController : ControllerBase
    {
        private ManipulationUsers m_usersManipulation;

        public UserCompletedRidesController(ManipulationUsers p_manipulationUsers)
        {
            if (p_manipulationUsers == null)
            {
                throw new ArgumentNullException("ManipulationUsers ne doit pas etre null - ctor CompletedRideController");
            }

            this.m_usersManipulation = p_manipulationUsers;
        }

        // GET: api/<UserCompletedRidesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<IEnumerable<UserCompletedRideModel>> Get(string p_login)
        {
            ActionResult<IEnumerable<UserCompletedRideModel>> response;

            if (!this.CheckUserToken())
            {
                response = Unauthorized();
            }
            else if (!this.m_usersManipulation.UserExist(p_login))
            {
                response = BadRequest();
            }
            else
            {
                try
                {
                    IEnumerable<UserCompletedRideModel> completedRides =
                        this.m_usersManipulation.GetCompletedRides(p_login)
                        .Select(ucr => new UserCompletedRideModel(ucr));

                    response = Ok(completedRides);
                }
                catch (Exception)
                {
                    response = StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            return response;
        }

        private bool CheckUserToken()
        {
            string? token = this.GetUserToken();

            ///////////////////////////////////////////////////////////////////
            return true;
            ///////////////////////////////////////////////////////////////////
            return !String.IsNullOrWhiteSpace(token) && this.m_usersManipulation.CheckUserToken(token);
        }

        private string? GetUserToken()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString();

            string[] tokenParts = token.Split(' ');

            if (tokenParts.Length != 2 || !string.Equals(tokenParts[0], "Bearer", StringComparison.OrdinalIgnoreCase))
            {
                token = null;
            }
            else
            {
                token = tokenParts[1];
            }

            return token;
        }
    }
}
