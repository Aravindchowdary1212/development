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
            string Employee=string.Empty;
            try
            {
                int j=25;
                Employee = "the way how to bild the projectghjgh";

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(Employee);
        }


        [HttpGet, Route("employee1")]
        public IActionResult Employes1()
        {
            string Employee = string.Empty;
            try
            {
                Employee = "Iam Check Branch Pullinh Requsted";
                int i=123;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(Employee);
        }
    }
}
