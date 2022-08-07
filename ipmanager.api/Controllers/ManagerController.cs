using ipmanager.api.Validations;
using ipmanager.aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using IpModel = System.String;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ipmanager.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController( IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET api/<Manager>/5
        [HttpGet("{ip}")]
        public async Task<IActionResult> Get(IpModel ip)
        {
            IpModel model = ip;
            var val = new ModelValidator();
            var res =  val.Validate(model);

            if (!res.IsValid)
                return BadRequest(res.ToString());

            var response = await _managerService.GetInfoByIp(ip);
            return Ok(response);
        }

        // PUT api/<Manager>/5
        [HttpPut("{ip}")]
        public async Task<IActionResult> Put(IpModel ip)
        {
            await _managerService.BanRemove(ip);
            return Ok();
        }

        // DELETE api/<Manager>/5
        [HttpDelete("{ip}")]
        public async Task<IActionResult> Delete(IpModel ip)
        {
            await _managerService.Ban(ip);
            return Ok();
        }
    }
}