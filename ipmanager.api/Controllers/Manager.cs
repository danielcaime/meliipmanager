using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ipmanager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manager : ControllerBase
    {
        // GET api/<Manager>/5
        [HttpGet("{ip}")]
        public async Task<IActionResult> Get(string ip)
        {
            var model = new { ip = ip };
            return Ok(model);
        }

        // PUT api/<Manager>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Manager>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}