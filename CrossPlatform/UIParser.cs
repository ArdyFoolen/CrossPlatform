using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using CrossPlatform.UIInterfaces;
using CrossPlatform.CrossPlatformControls;

namespace CrossPlatform
{
    public interface IUIParser
    {
        public IControl Parse();
    }

    public class UIParser : IUIParser
    {
        private readonly IUIBuilder uIBuilder;

        public UIParser(IUIBuilder uIBuilder)
        {
            this.uIBuilder=uIBuilder;
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
                    AddNameAttribute(reader);
                    AddLoadEvent(reader);
                    AddClickEvent(reader);
                }
            }

            return uIBuilder.Build();
        }

        private void AddNameAttribute(XmlReader reader)
        {
            if (reader.MoveToAttribute("name"))
            {
                var name = reader.GetAttribute("name");
                if (!string.IsNullOrWhiteSpace(name))
                    uIBuilder.WithName(name);
            }
        }

        private void AddLoadEvent(XmlReader reader)
        {
            if (reader.MoveToAttribute("load"))
            {
                var name = reader.GetAttribute("load");
                if (!string.IsNullOrWhiteSpace(name))
                    uIBuilder.WithLoad(name);
            }
        }

        private void AddClickEvent(XmlReader reader)
        {
            if (reader.MoveToAttribute("click"))
            {
                var name = reader.GetAttribute("click");
                if (!string.IsNullOrWhiteSpace(name))
                    uIBuilder.WithClick(name);
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
