using CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp
{
    public class WindowsButton : IButton
    {
        private IEvent @event;
        public WindowsButton(IEvent @event)
        {
            this.@event = @event;
        }

        public void Click()
            => this.@event.OnClick(this);

        public void Test()
            => Console.WriteLine("WindowsButton Test");
    }
}
