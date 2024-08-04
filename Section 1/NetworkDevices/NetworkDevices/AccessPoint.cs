using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDevices
{
    public class AccessPoint : NetworkDevice
    {
        public string SSID { get; private set; }
        
        public AccessPoint(string ipAddress, string macAddress, string ssid) : base(ipAddress, macAddress)
        {
            this.SSID = ssid;   
        }

        //this method will override the abstract method in the base(parent) class and simulates connection.
        public override void Connect()
        {
            Console.WriteLine("Connecting AccessPoint with IP: " + IPAddress + " and MAC: " + MACAddress + " SSID: " + SSID);
        }
    }
}
