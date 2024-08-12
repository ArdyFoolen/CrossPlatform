using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.UIInterfaces
{
    public interface IEventHandler
    {
        public void OnClick(IControl control);
        public void OnLoad(IControl control);
    }
}
