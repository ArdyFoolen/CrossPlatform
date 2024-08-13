using CrossPlatform;
using CrossPlatform.AttributeHandlers;
using CrossPlatform.UIInterfaces;
using UbuntuApp;

var factory = new UbuntuPlatformFactory();
var bridge = PlatformBridge.Create(factory);

var control = bridge.RunCrossPlatformApp();

var control1 = (IButton)factory.Controls[1];
var control2 = (IButton)factory.Controls[2];
control1.Click();
control2.Click();
