using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WCF_XPRTZ_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress endPoint;
            Binding binding;

            Console.WriteLine("Kies een type binding:");
            Console.WriteLine("1. NetTCP");
            Console.WriteLine("2. WSHttp");
            Console.WriteLine("Gevolgd door enter.");

            var nr = Console.ReadLine();
            if (nr == "1")
            {
                endPoint = new EndpointAddress("net.tcp://localhost:8080/XprtzService/");
                binding = new NetTcpBinding(SecurityMode.None)
                { };
            }
            else if (nr == "2")
            {
                endPoint = new EndpointAddress("http://localhost:8090/XprtzService/");
                binding = new WSHttpBinding(SecurityMode.None)
                { };
            }
            else
            {
                Console.WriteLine($"Input: [{nr}] niet begrepen; exiting...");
                return;
            }            

            var channel = new ChannelFactory<IXprtzService>(binding, endPoint);
            var client = channel.CreateChannel();

            try
            {                
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
