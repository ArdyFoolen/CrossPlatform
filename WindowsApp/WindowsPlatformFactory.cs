using CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp
{
    public class WindowsPlatformFactory : IPlatformFactory
    {
        public ICustomTimer CreateTimer()
            => new WindowsTimer();
        public IButton CreateButton(IEvent @event)
            => new WindowsButton(@event);
    }
}
