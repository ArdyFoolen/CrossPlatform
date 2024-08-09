using CrossPlatform;
using UbuntuApp;

var factory = new UbuntuPlatformFactory();
var bridge = new PlatformBridge(factory);

bridge.RunCrossPlatformApp();
