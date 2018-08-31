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

            ServiceHost svcHost = new ServiceHost(typeof(ServiceEmployees), new Uri("http://localhost:8834/tsi1/"));
            try
            {
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = svcHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                svcHost.Description.Behaviors.Add(smb);
                // Add MEX endpoint
                svcHost.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );
                // Add application endpoint
                svcHost.AddServiceEndpoint(typeof(IServiceEmployees), new WSHttpBinding(), "");
                // Open the service host to accept incoming calls
                svcHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                svcHost.Close();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
        }
    }
    
}
