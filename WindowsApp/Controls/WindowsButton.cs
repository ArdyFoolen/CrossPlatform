using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Controls
{
    public class WindowsButton : WindowsControl, IButton
    {
        public void LoadTest()
            => Console.WriteLine($"WindowsButton {Name} Load Test");
        public void ClickOkTest()
            => Console.WriteLine($"WindowsButton {Name} Click Ok Test");
        public void ClickCancelTest()
            => Console.WriteLine($"WindowsButton {Name} Click Cancel Test");
    }
}
