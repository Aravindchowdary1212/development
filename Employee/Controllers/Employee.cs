using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {

        [HttpGet ,Route("employee")]
        public IActionResult Employes()
        {
            try
            {
                string Employee = "";
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("nbggfgg");
        }
    }
}
