using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.UIInterfaces
{
    public interface IPlatformFactory
    {
        public ICustomTimer CreateTimer();
        public IButton CreateButton();
        public IForm CreateForm();
    }
}
