using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WCFService.Service1));
            host.Open();
            Console.WriteLine("Service hosted");
            Console.Read();
        }
    }
}
