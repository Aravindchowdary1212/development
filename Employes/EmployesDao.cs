using InterfaceEmployee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employes
{
    public class EmployesDao: IEmployesDao
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string classname = "Employee";
        private IConfiguration _Configuration = null;



        public string employe()
        {
            _log.Info("class:" + classname + "employe Start");
            string Employee = string.Empty;

            try
            {
                Employee = "the way how to bild the project123";
            }
            catch (Exception ex)
            {
                _log.Error("class:" + classname + "employe " + ex);
                throw ex;
            }
            _log.Info("class:" + classname + "employe end");

            return Employee;
        }
    }
}
