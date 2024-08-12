using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.CrossPlatformControls;
using CrossPlatform.UIInterfaces;

namespace CrossPlatform
{
    public interface IUIBuilder
    {
        public UIBuilder WithButton();
        public UIBuilder WithForm();
        public UIBuilder WithName(string name);
        public UIBuilder WithLoad(string methodName);
        public UIBuilder WithClick(string methodName);
        public IControl Build();
    }

    public class UIBuilder : IUIBuilder
    {
        private readonly IPlatformFactory platformFactory;
        private Stack<CrossPlatformControl> stack = new Stack<CrossPlatformControl>();
        private IControl? root = null;

        public UIBuilder(IPlatformFactory platformFactory)
        {
            this.platformFactory = platformFactory;
        }

        public UIBuilder WithButton()
        {
            var control = platformFactory.CreateButton();
            CrossPlatformButton button = new CrossPlatformButton(control);
            AddToParent(button);
            stack.Push(button);
            SetRoot(control);

            return this;
        }

        public UIBuilder WithForm()
        {
            var control = platformFactory.CreateForm();
            CrossPlatformForm form = new CrossPlatformForm(control);
            AddToParent(form);
            stack.Push(form);
            SetRoot(control);

            return this;
        }

        public UIBuilder WithName(string name)
        {
            var control = stack.Pop();
            control.UIControl.Name = name;
            stack.Push(control);
            return this;
        }

        public UIBuilder WithLoad(string methodName)
        {
            var control = stack.Pop();

            var eventInfo = control.GetType().GetEvent("loadEvent", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var methodInfo = control.GetType().GetMethod(methodName, 
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, 
                new Type[] { typeof(object), typeof(EventArgs) });
            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, control, methodInfo);
            var addMethod = eventInfo.GetAddMethod(true);
            addMethod?.Invoke(control, new[] { handler });

            stack.Push(control);
            return this;
        }

        public UIBuilder WithClick(string methodName)
        {
            var control = stack.Pop();

            var eventInfo = control.GetType().GetEvent("clickEvent", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var methodInfo = control.GetType().GetMethod(methodName,
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                new Type[] { typeof(object), typeof(EventArgs) });
            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, control, methodInfo);
            var addMethod = eventInfo.GetAddMethod(true);
            addMethod?.Invoke(control, new[] { handler });

            stack.Push(control);
            return this;
        }

        private bool AddToParent(CrossPlatformControl control)
        {
            if (!stack.TryPeek(out var parent))
                return true;

            parent = stack.Pop();
            if (parent.IsComposite)
            {
                parent.Add(control);
                stack.Push(parent);
            }
            else if (!AddToParent(control))
                throw new Exception("Multiple child controls on root level");

            return true;
        }

        private void SetRoot(IControl control)
        {
            if (root != null)
                return;

            root = control;
        }

        public IControl Build()
        {
            return root;
        }
    }
}
