using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackSense.API.Entities;
using TrackSense.API.Models;
using TrackSense.API.Services.ServiceRides;
using TrackSense.API.Services.ServiceUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackSense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedRidesController
        : ControllerBase
    {
        private ManipulationRides m_ridesManipulation;
        private ManipulationUsers m_usersManipulation;

        public CompletedRidesController(ManipulationRides p_manipulationRides, ManipulationUsers p_manipulationUsers)
        {
            if (p_manipulationRides == null)
            {
                throw new ArgumentNullException("ManipulationRides ne doit pas etre null - ctor CompletedRideController");
            }
            if (p_manipulationUsers == null)
            {
                throw new ArgumentNullException("ManipulationUsers ne doit pas etre null - ctor CompletedRideController");
            }

            this.m_ridesManipulation = p_manipulationRides;
            this.m_usersManipulation = p_manipulationUsers;
        }


        // GET: api/<CompletedRidesController>
        [HttpGet]
        public ActionResult<IEnumerable<CompletedRideModel>> Get()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString();







            return Ok();
        }

        // GET api/<CompletedRidesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompletedRidesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] CompletedRideModel p_completedRide)
        {
            ActionResult response;

            string token = HttpContext.Request.Headers["Authorization"].ToString();

            //string[] tokenParts = token.Split(' ');
            //if (tokenParts.Length != 2 || !string.Equals(tokenParts[0], "Bearer", StringComparison.OrdinalIgnoreCase))
            //{
            //    return BadRequest("Mauvais format de jeton.");
            //}
            //string bearerToken = tokenParts[1];

            if (p_completedRide == null || String.IsNullOrWhiteSpace(token))
            {
                response = BadRequest();
            }
            else
            {
                try
                {
                    UserTokenModel userToken = new UserTokenModel()
                    {
                        Token = token,
                        UserLogin = p_completedRide.UserLogin
                    };

                    if (this.m_usersManipulation.CheckUserToken(token, p_completedRide.UserLogin))
                    {
                        CompletedRide completedRide = p_completedRide.ToEntity();
                        this.m_ridesManipulation.AddCompletedRide(token, completedRide);

                        string url = $"api/completedRides/{p_completedRide.CompletedRideId}";
                        response = Created(url, new CompletedRideModel(completedRide));
                    }
                    else
                    {
                        response = Unauthorized();
                    }
                }
                catch (Exception)
                {
                    response = StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            return response;
            
        }

        // PUT api/<CompletedRidesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompletedRidesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
