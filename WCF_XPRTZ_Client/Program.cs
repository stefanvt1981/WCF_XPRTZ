using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_XPRTZ_Client
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Press enter when the service is opened.");
            Console.ReadLine();

            var endPoint = new EndpointAddress("net.tcp://localhost:8080/XprtzService/");
            var binding = new NetTcpBinding(SecurityMode.None)
            { };

            var channel = new ChannelFactory<IXprtzService>(binding, endPoint);
            var client = channel.CreateChannel();

            try
            {
                Console.WriteLine("Invoking HelloWorld on TcpService.");
                var list = client.GetAll().Xprts;

                foreach(var xprt in list)
                {
                    Console.WriteLine($"Naam: {xprt.FirstName} {xprt.LastName}, Badge: {xprt.BadgeNumber}");
                }

                Console.WriteLine("Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }            

            Console.WriteLine("Press enter to quit.");
            Console.ReadLine();

            channel.Close();
        }
    }
}
