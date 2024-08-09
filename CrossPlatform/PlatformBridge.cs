namespace CrossPlatform
{
    /// <summary>
    /// Abstraction of the Bridge pattern
    /// It's implementation returns is a factory that returns specific implementations to the platform
    /// </summary>
    public class PlatformBridge
    {
        private readonly IPlatformFactory platformFactory;
        private readonly List<CrossPlatformControl> controls = new List<CrossPlatformControl>();

        public PlatformBridge(IPlatformFactory platformFactory)
        {
            this.platformFactory = platformFactory;
        }

        public ICustomTimer CreateTimer()
            => platformFactory.CreateTimer();

        /// <summary>
        /// Should be refactored to return CrossPlatformButton
        /// </summary>
        /// <returns></returns>
        public IButton CreateButton()
        {
            CrossPlatformButton button = new CrossPlatformButton();
            controls.Add(button);
            return platformFactory.CreateButton(button);
        }

        public void RunCrossPlatformApp()
        {
            var timer = CreateTimer();

            timer.Start();
            timer.Stop();

            // Normally would return the CrossPlatformButton, but because I want to test the UserSide click I return IButton
            var button = CreateButton();

            // Click normally happens on WindowsApp or UbuntuApp side by the user
            button.Click();
        }
    }
}
