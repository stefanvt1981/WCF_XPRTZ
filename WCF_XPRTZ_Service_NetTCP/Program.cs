using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_Service.Interfaces;
using WCF_XPRTZ_Service.Services;

namespace WCF_XPRTZ_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            RunNetTCP();
        }

        static void RunNetTCP()
        {
            var netTcpBinding = new NetTcpBinding(SecurityMode.None)
            {
                //PortSharingEnabled = true
            };

            var netTcpAdddress = new Uri("net.tcp://localhost:8080/");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(XprtzService), netTcpAdddress))
            {
                host.AddServiceEndpoint(typeof(IXprtzService), netTcpBinding, "XprtzService");

                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8081/");
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);                               

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", netTcpAdddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }

        static void RunHttp()
        {

        }
    }
}
