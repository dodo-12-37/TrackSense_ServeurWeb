using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackSense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedRidesController 
        : ControllerBase
    {
        // GET: api/<CompletedRidesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CompletedRidesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompletedRidesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
