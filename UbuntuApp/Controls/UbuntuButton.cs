using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbuntuApp.Controls
{
    public class UbuntuButton : UbuntuControl, IButton
    {
        public void LoadTest()
            => Console.WriteLine($"UbuntuButton {Name} Load Test");
        public void ClickOkTest()
            => Console.WriteLine($"UbuntuButton {Name} Click Ok Test");
        public void ClickCancelTest()
            => Console.WriteLine($"UbuntuButton {Name} Click Cancel Test");
    }
}
