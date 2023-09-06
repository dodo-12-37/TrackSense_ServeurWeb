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

        // GET api/<CompletedRidesController>/5
        [HttpGet("{p_completedRideId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<CompletedRideModel> Get(Guid p_completedRideId)
        {
            ActionResult<CompletedRideModel> response;

            if (!this.CheckUserToken())
            {
                response = Unauthorized();
            }
            else if (p_completedRideId == Guid.Empty)
            {
                response = BadRequest();
            }
            else
            {
                try
                {
                    CompletedRide? completedRide = this.m_ridesManipulation.GetCompletedRide(p_completedRideId);

                    response = completedRide != null 
                        ? Ok(new CompletedRideModel(completedRide)) 
                        : NoContent();
                }
                catch (Exception)
                {
                    response = StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            return response;
        }

        // POST api/<CompletedRidesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult Post([FromBody] CompletedRideModel p_completedRide)
        {
            ActionResult response;

            if (this.CheckUserToken())
            {
                response = Unauthorized();
            }
            else if (p_completedRide == null)
            {
                response = BadRequest();
            }
            else
            {
                try
                {
                    CompletedRide completedRide = p_completedRide.ToEntity();
                    this.m_ridesManipulation.AddCompletedRide(p_completedRide.UserLogin, completedRide);

                    string url = $"api/completedRides/{p_completedRide.CompletedRideId}";
                    response = Created(url, new CompletedRideModel(completedRide));
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
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

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
