using CrossPlatform.UIInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.CrossPlatformControls
{
    public class CrossPlatformForm : CrossPlatformControl
    {
        public override bool IsComposite { get => true; }

        public CrossPlatformForm(IControl uiControl) : base(uiControl) { }

        protected override void Initialize()
            => loadEvent += frm_Load;

        public void frm_Load(object sender, EventArgs e)
        {
            var form = sender as IForm;
            form?.LoadTest();
        }
    }
}
