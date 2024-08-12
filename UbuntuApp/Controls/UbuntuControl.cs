using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbuntuApp.Controls
{
    public abstract class UbuntuControl : IControl
    {
        protected IEventHandler? @event;

        public string Name { get; set; }

        public void AddEventHandler(IEventHandler @event)
            => this.@event = @event;

        public void Load()
            => @event?.OnLoad(this);
        public void Click()
            => @event?.OnClick(this);
    }
}
