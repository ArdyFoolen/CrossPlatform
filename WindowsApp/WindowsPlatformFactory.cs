using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Controls;

namespace WindowsApp
{
    public class WindowsPlatformFactory : IPlatformFactory
    {
        public List<IControl> Controls = new List<IControl>();

        public ICustomTimer CreateTimer()
            => new WindowsTimer();

        public IButton CreateButton()
        {
            var button = new WindowsButton();
            this.Controls.Add(button);
            return button;
        }

        public IForm CreateForm()
        {
            var button = new WindowsForm();
            this.Controls.Add(button);
            return button;
        }
    }
}
