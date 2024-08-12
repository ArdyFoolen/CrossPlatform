using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbuntuApp.Controls;

namespace UbuntuApp
{
    public class UbuntuPlatformFactory : IPlatformFactory
    {
        public List<IControl> Controls = new List<IControl>();
        public ICustomTimer CreateTimer()
            => new UbuntuTimer();
        public IButton CreateButton()
        {
            var button = new UbuntuButton();
            this.Controls.Add(button);
            return button;
        }

        public IForm CreateForm()
        {
            var button = new UbuntuForm();
            this.Controls.Add(button);
            return button;
        }
    }
}
