using API_web_MySQL.Models;
using API_web_MySQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_web_MySQL.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly ManipulationUser m_manipulationUser;
        public UserController(ManipulationUser p_manipulationUser)
        {
            m_manipulationUser = p_manipulationUser;
        }

        //get all users
        // GET api/users
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            if (m_manipulationUser.GetAllUsers() is null)
            {
                return NotFound();
            }
            return Ok(m_manipulationUser.GetAllUsers().Select(u => new UserModel(u)).ToList());
        }

        // get user by id
        //GET api/users/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserModel>Get(int id)
        {
            Services.User ?user = m_manipulationUser.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

        //POST: api/users/
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] UserModel p_user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            Services.User newUser = p_user.ToEntity();
            m_manipulationUser.AddUser(newUser);
            p_user.UserId = newUser.UserId;
            return CreatedAtAction(nameof(Get), p_user );
        }
    }
}
