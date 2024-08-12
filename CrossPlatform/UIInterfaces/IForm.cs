using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.UIInterfaces
{
    public interface IForm : IControl
    {
        public void Load();

        public void LoadTest();
    }
}
