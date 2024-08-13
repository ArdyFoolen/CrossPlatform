using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using CrossPlatform.UIInterfaces;
using CrossPlatform.CrossPlatformControls;
using CrossPlatform.AttributeHandlers;
using System.Xml.Linq;

namespace CrossPlatform
{
    public interface IUIParser
    {
        public IControl Parse();
    }

    public class UIParser : IUIParser
    {
        private readonly IUIBuilder uIBuilder;
        private readonly IAttributeHandler attributeHandler;

        public UIParser(IUIBuilder uIBuilder, IAttributeHandler attributeHandler)
        {
            this.uIBuilder = uIBuilder;
            this.attributeHandler = attributeHandler;
        }

        public IControl Parse()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;
            XmlReader reader = XmlReader.Create("CrossPlatform.xml", settings);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    ParseControl(reader);
                    ParseAttributes(reader);
                }
            }

            return uIBuilder.Build();
        }

        private void ParseAttributes(XmlReader reader)
        {
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    if (!attributeHandler.Handle(reader))
                        throw new NotImplementedException($"Attribute {reader.Name} not implemented");
                }
                reader.MoveToElement();
            }
        }

        private void ParseControl(XmlReader reader)
        {
            switch (reader.Name.ToLowerInvariant())
            {
                case "button":
                    uIBuilder.WithButton();
                    break;
                case "form":
                    uIBuilder.WithForm();
                    break;
                default: throw new Exception("Invalid control");
            }
        }
    }
}
