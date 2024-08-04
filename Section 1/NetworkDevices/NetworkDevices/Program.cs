using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDevices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example object of the Router class
            Router router = new Router("192.168.1.1", "00:1A:2B:3C:4D:5E", 6);

            //Example object of the Switch class
            Switch networkSwitch = new Switch("192.168.1.2", "00:1A:2B:3C:4D:5F", 20);

            //Example object of the AccessPoint class
            AccessPoint accessPoint = new AccessPoint("192.168.1.3", "00:1A:2B:3C:4D:60", "PrivateNetwork");

            //Simulation of connection
            router.Connect();
            networkSwitch.Connect();
            accessPoint.Connect();

        }
    }
}
