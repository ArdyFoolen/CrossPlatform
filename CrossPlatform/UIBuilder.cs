using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        public UIBuilder WithEvent(string eventName, string methodName);
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

        public UIBuilder WithEvent(string eventName, string methodName)
        {
            var control = stack.Pop();
            control.AddEventHandler(eventName, methodName);
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
