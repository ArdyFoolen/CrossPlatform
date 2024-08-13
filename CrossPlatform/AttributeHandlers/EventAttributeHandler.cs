using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrossPlatform.AttributeHandlers
{
    public class EventAttributeHandler : AttributeHandler
    {
        private readonly Dictionary<string, string> EventDictionary = new Dictionary<string, string>()
        {
            { "load", "loadEvent" },
            { "click", "clickEvent" }
        };
        public EventAttributeHandler(IUIBuilder uIBuilder) : base(uIBuilder) { }
        public EventAttributeHandler(IUIBuilder uIBuilder, AttributeHandler nextHandler) : base(uIBuilder, nextHandler) { }

        public override bool Handle(XmlReader reader)
        {
            if (EventDictionary.ContainsKey(reader.Name))
            {
                if (!string.IsNullOrWhiteSpace(reader.Value))
                    uIBuilder.WithEvent(EventDictionary[reader.Name], reader.Value);
                return true;
            }

            return HandleNext(reader);
        }
    }
}
