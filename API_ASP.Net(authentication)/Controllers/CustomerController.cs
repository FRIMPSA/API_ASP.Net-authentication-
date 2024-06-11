using API_ASP.Net_authentication_.Modal;
using API_ASP.Net_authentication_.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ASP.Net_authentication_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerservice service;
        public CustomerController(ICustomerservice service) 
        { 
            this.service = service;
        
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> Getall()
        {
            var data = await this.service.Getall();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetbyCode")]
        public async Task<IActionResult> GetbyCode(int code) 
        {
            var data = await this.service.GetbyCode(code);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerModal _data)
        {
            var data = await this.service.Create(_data);
           
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerModal _data, int code)
        {
            var data = await this.service.Update(_data,code);

            return Ok(data);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var data = await this.service.Remove(code);

            return Ok(data);
        }

    }
}
