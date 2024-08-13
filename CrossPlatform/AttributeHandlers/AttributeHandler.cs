using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrossPlatform.AttributeHandlers
{
    public interface IAttributeHandler
    {
        public bool Handle(XmlReader reader);
    }

    public abstract class AttributeHandler : IAttributeHandler
    {
        protected readonly IUIBuilder uIBuilder;
        private readonly AttributeHandler? nextHandler = null;
        protected AttributeHandler(IUIBuilder uIBuilder)
        {
            this.uIBuilder = uIBuilder;
        }
        protected AttributeHandler(IUIBuilder uIBuilder, AttributeHandler nextHandler)
        {
            this.uIBuilder = uIBuilder;
            this.nextHandler = nextHandler;
        }

        protected bool HandleNext(XmlReader reader)
        {
            if (nextHandler == null)
                return false;

            return nextHandler.Handle(reader);
        }

        public abstract bool Handle(XmlReader reader);
    }
}
