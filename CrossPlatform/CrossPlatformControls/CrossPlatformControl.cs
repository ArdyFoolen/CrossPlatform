using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.UIInterfaces;

namespace CrossPlatform.CrossPlatformControls
{
    public abstract class CrossPlatformControl : IEventHandler
    {
        private List<CrossPlatformControl> children = new List<CrossPlatformControl>();
        public IControl UIControl { get; private set; }
        protected CrossPlatformControl(IControl uIControl)
        {
            UIControl = uIControl;
            this.UIControl.AddEventHandler(this);

            Initialize();
        }

        protected event Click? clickEvent;
        protected event Load? loadEvent;

        protected virtual void Initialize() { }
        public abstract bool IsComposite { get; }

        public void OnClick(IControl control)
            => clickEvent?.Invoke(control, new EventArgs());
        public void OnLoad(IControl control)
        {
            if (loadEvent == null)
                return;
            loadEvent?.Invoke(control, new EventArgs());
            children.ForEach(x => x.UIControl.Load());
        }

        public void Add(CrossPlatformControl control)
        {
            children.Add(control);
        }
    }
}
