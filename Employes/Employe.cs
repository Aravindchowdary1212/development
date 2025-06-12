using InterfaceEmployee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employes
{
    public class Employe: IEmployes
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IEmployesDao iEmployesDao = null;
        string classname = "Employee";
        private IConfiguration _Configuration = null;

        public Employe(IEmployesDao employesDao,IConfiguration configuration)
        {
            iEmployesDao = employesDao;
            _Configuration = configuration;
        }
        public string employe()
        {
            _log.Info("class:" + classname + "employe Start");
            string value = string.Empty;
            try
            {
                value=iEmployesDao.employe();
            }
            catch (Exception ex)
            {
                _log.Error("class:" + classname + "employe " + ex);
                throw ex;
            }
            _log.Info("class:" + classname + "employe end");

            return value;
        }

    }
}
