using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.UIInterfaces;

namespace WindowsApp.Controls
{
    public class WindowsForm : WindowsControl, IForm
    {
        public void LoadTest()
            => Console.WriteLine($"WindowsForm {Name} Load Test");
    }
}
