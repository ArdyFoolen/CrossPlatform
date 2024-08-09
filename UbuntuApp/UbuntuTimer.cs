using CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbuntuApp
{
    public class UbuntuTimer : ICustomTimer
    {
        public void Start()
        {
            Console.WriteLine("Starting UbuntuTimer");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping UbuntuTimer");
        }
    }
}
