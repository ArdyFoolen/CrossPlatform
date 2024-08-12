using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Controls
{
    public class WindowsTimer : ICustomTimer
    {
        public void Start()
        {
            Console.WriteLine("Starting WindowsTimer");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping WindowsTimer");
        }
    }
}
