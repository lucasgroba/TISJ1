using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    class Program
    {
        public static IBLEmployees blHandler;

        static void Main(string[] args)
        {
            SetupDependencies();
            SetupService();
        }

        private static void SetupDependencies()
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
        }

        private static void SetupService()
        {
            ServiceHost host = new ServiceHost(typeof(ServiceEmployees), new Uri("http://localhost:8834/tsi1"));
            host.AddServiceEndpoint(typeof(IServiceEmployees), new BasicHttpBinding(), "Soap");
            host.Open();
        }
    }
}
