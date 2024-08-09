using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public abstract class CrossPlatformControl : IEvent
    {
        protected event Click? clickEvent; // event

        public void OnClick(IButton button)
            => clickEvent?.Invoke(button, new EventArgs());
    }
}
