using CrossPlatform.CrossPlatformControls;
using CrossPlatform.UIInterfaces;

namespace CrossPlatform
{
    /// <summary>
    /// Abstraction of the Bridge pattern
    /// It's implementation returns is a factory that returns specific implementations to the platform
    /// </summary>
    public class PlatformBridge
    {
        private readonly IPlatformFactory platformFactory;
        private readonly IUIParser uIParser;
        private readonly List<CrossPlatformControl> controls = new List<CrossPlatformControl>();

        public PlatformBridge(IPlatformFactory platformFactory, IUIParser uiParser)
        {
            this.platformFactory = platformFactory;
            this.uIParser = uiParser;
        }

        public ICustomTimer CreateTimer()
            => platformFactory.CreateTimer();

        public IControl RunCrossPlatformApp()
        {
            var timer = CreateTimer();

            timer.Start();
            timer.Stop();

            var control = this.uIParser.Parse();
            control.Load();

            return control;
        }
    }
}
