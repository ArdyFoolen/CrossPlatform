using CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbuntuApp
{
    public class UbuntuButton : IButton
    {
        private IEvent @event;
        public UbuntuButton(IEvent @event)
        {
            this.@event = @event;
        }

        public void Click()
            => this.@event.OnClick(this);

        public void Test()
            => Console.WriteLine("UbuntuButton Test");
    }
}
