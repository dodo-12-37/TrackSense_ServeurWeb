using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackSense.API.Models;
using TrackSense.API.Services.ServiceUsers;

namespace TrackSense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ManipulationUsers m_manipulationUsers;

        public UsersController(ManipulationUsers manipulationUsers)
        {
            m_manipulationUsers = manipulationUsers;
        }
        // GET: api/Users/availibityLogin
        [HttpGet("availibityLogin")]
        public ActionResult<AvailibilityModel> GetAvailibityLogin(string p_userLogin)
        {
            bool isExist = m_manipulationUsers.UserExist(p_userLogin);

            return Ok(new AvailibilityModel(!isExist));
        }


    }
}
