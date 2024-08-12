using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.UIInterfaces
{
    public interface IControl
    {
        public string Name { get; set; }

        public void Load();
        public void AddEventHandler(IEventHandler eventHandler);
    }
}
