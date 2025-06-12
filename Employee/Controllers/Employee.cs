using InterfaceEmployee;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string classname = "Employee";
        private IEmployes iEmployes = null;
        private IConfiguration _Configuration = null;

        public Employee(IConfiguration configuration,IEmployes employes)
        {
            iEmployes= employes;
            _Configuration = configuration;

        }

        [HttpGet ,Route("employee")]
        public IActionResult Employes()
        {
            _log.Info("class:"+classname+"employee Start");
            string Employee=string.Empty;
            try
            {
                Employee = iEmployes.employe();
            }
            catch(Exception e)
            {
                _log.Error("class:" + classname + "employee "+ e);
                return BadRequest(e.Message);
            }
            _log.Info("class:" + classname + "employee end");

            return Ok(Employee);
        }


        [HttpGet, Route("employee1")]
        public IActionResult Employes1()
        {
            string Employee = string.Empty;
            _log.Info("class:" + classname + "employee1 Start");

            try
            {
                Employee = "Iam Check Branch Pullinh Requsted";
            }
            catch (Exception e)
            {
                _log.Error("class:" + classname + "employee " + e);
                return BadRequest(e.Message);
            }
            _log.Info("class:" + classname + "employee1 end");
            return Ok(Employee);
        }
    }
}
