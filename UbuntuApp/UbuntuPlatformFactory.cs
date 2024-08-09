using CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbuntuApp
{
    public class UbuntuPlatformFactory : IPlatformFactory
    {
        public ICustomTimer CreateTimer()
            => new UbuntuTimer();
        public IButton CreateButton(IEvent @event)
            => new UbuntuButton(@event);
    }
}
