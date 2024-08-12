using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.UIInterfaces;

namespace CrossPlatform.CrossPlatformControls
{
    public class CrossPlatformButton : CrossPlatformControl
    {
        public override bool IsComposite { get => false; }

        public CrossPlatformButton(IControl uiControl) : base(uiControl) { }

        protected override void Initialize()
        {
            //loadEvent += btn_Load;
            //clickEvent += btn_Click;
        }

        public void btn_Load(object sender, EventArgs e)
        {
            var button = sender as IButton;
            button?.LoadTest();
        }

        public void btn_Ok(object sender, EventArgs e)
        {
            var button = sender as IButton;
            button?.ClickOkTest();
        }

        public void btn_Cancel(object sender, EventArgs e)
        {
            var button = sender as IButton;
            button?.ClickCancelTest();
        }
    }
}
