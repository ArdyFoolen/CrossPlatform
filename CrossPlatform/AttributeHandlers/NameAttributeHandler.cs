using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrossPlatform.AttributeHandlers
{
    public class NameAttributeHandler : AttributeHandler
    {
        public NameAttributeHandler(IUIBuilder uIBuilder) : base(uIBuilder) { }
        public NameAttributeHandler(IUIBuilder uIBuilder, AttributeHandler nextHandler) : base(uIBuilder, nextHandler) { }

        public override bool Handle(XmlReader reader)
        {
            if ("name".Equals(reader.Name.ToLowerInvariant()))
            {
                if (!string.IsNullOrWhiteSpace(reader.Value))
                    uIBuilder.WithName(reader.Value);
                return true;
            }
            return HandleNext(reader);
        }
    }
}
