using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDevices
{
    public abstract class NetworkDevice
    {
        public string  IPAddress { get; private set; }
        public string MACAddress { get; private set; }
        public NetworkDevice(string ipAddress, string macAddress)
        {
            this.IPAddress = ipAddress;
            this.MACAddress = macAddress;
        }

        //Abstract method that will be overriden in the child classes
        public abstract void Connect();
    }
}
