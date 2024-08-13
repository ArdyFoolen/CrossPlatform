using CrossPlatform.CrossPlatformControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public static class ReflectionExtensions
    {
        public static EventInfo? GetEvent(this object obj, string eventName)
            => obj.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
        public static Type[]? GetParameterTypes(this EventInfo? eventInfo)
            => eventInfo?.EventHandlerType?.GetMethod("Invoke")?.GetParameters()?.Select(p => p.ParameterType)?.ToArray();
        public static MethodInfo? GetMethod(this object obj, string methodName, Type[]? parameterTypes)
            => obj.GetType().GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                parameterTypes ?? []);
        public static Delegate? CreateDelegate(this EventInfo? eventInfo, object obj, MethodInfo? method)
            => eventInfo != null && eventInfo.EventHandlerType != null && method != null
                ? Delegate.CreateDelegate(eventInfo.EventHandlerType, obj, method)
                : null;
        public static void AddEventHandler(this object control, string eventName, string methodName)
        {
            var eventInfo = control.GetEvent(eventName);
            if (eventInfo == null)
                throw new ArgumentException($"Event {eventName} not found");

            Type[]? parameterTypes = eventInfo.GetParameterTypes();

            var methodInfo = control.GetMethod(methodName, parameterTypes);
            control.AddEventHandler(eventInfo, methodInfo);
        }
        public static void AddEventHandler(this object obj, EventInfo? eventInfo, MethodInfo? method)
        {
            Delegate? handler = eventInfo.CreateDelegate(obj, method);
            var addMethod = eventInfo?.GetAddMethod(true);
            addMethod?.Invoke(obj, [handler]);
        }
    }
}
