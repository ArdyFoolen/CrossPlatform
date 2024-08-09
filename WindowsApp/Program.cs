using CrossPlatform;
using WindowsApp;

var factory = new WindowsPlatformFactory();
var bridge = new PlatformBridge(factory);

bridge.RunCrossPlatformApp();
