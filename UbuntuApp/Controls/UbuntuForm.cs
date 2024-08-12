using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.UIInterfaces;

namespace UbuntuApp.Controls
{
    public class UbuntuForm : UbuntuControl, IForm
    {
        public void LoadTest()
            => Console.WriteLine($"UbuntuForm {Name} Load Test");
    }
}
