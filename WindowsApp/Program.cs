using CrossPlatform;
using CrossPlatform.UIInterfaces;
using WindowsApp;

var factory = new WindowsPlatformFactory();
var builder = new UIBuilder(factory);
var parser = new UIParser(builder);
var bridge = new PlatformBridge(factory, parser);

var control = bridge.RunCrossPlatformApp();

var control1 = (IButton)factory.Controls[1];
var control2 = (IButton)factory.Controls[2];
control1.Click();
control2.Click();
