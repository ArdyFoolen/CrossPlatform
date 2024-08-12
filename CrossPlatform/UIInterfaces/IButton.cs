using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.UIInterfaces
{
    public interface IButton : IControl
    {
        public void Click();
        public void ClickOkTest();
        public void ClickCancelTest();
        public void LoadTest();
    }
}
