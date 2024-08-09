using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public class CrossPlatformButton : CrossPlatformControl
    {
        public CrossPlatformButton()
        {
            Initialize();
        }

        private void Initialize()
            => clickEvent += btn_Click;

        public void btn_Click(object sender, EventArgs e)
        {
            var button = sender as IButton;
            button?.Test();
        }
    }
}
