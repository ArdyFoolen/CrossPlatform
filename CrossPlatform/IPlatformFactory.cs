using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public interface IPlatformFactory
    {
        public ICustomTimer CreateTimer();
        public IButton CreateButton(IEvent @event);
    }
}
