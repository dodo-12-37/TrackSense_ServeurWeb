using API_web_MySQL.Models;
using API_web_MySQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_web_MySQL.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ManipulationUser m_manipulationuser;
        public UserController(ManipulationUser p_manipulationUser)
        {
            m_manipulationuser = p_manipulationUser;
        }

        //get all users
        // GET api/users
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            if (m_manipulationuser.GetAllUsers() is null)
            {
                return NotFound();
            }
            return Ok(m_manipulationuser.GetAllUsers().Select(u => new UserModel(u)).ToList());
        }
        // get user by id
        //GET api/users/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserModel>Get(int id)
        {
            Services.User ?user = m_manipulationuser.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

    }
}
