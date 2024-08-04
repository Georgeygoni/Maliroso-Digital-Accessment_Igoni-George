using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDevices
{
    public class Switch : NetworkDevice
    {

        public int NumberOfPorts { get;  private set; }

        public Switch(string ipAddress, string macAddress, int numberOfPorts) : base(ipAddress, macAddress)
        {
            this.NumberOfPorts = numberOfPorts;
        }

        //this method will override the abstract method in the base(parent) class and simulates connection.
        public override void Connect()
        {
            Console.WriteLine("Connecting Switch with IP: " + IPAddress + " and MAC: " + MACAddress + " Number of Ports: " + NumberOfPorts);
        }
    }
}
