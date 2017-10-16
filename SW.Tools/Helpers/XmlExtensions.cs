using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SW.Tools.Helpers
{
    public static class XmlExtensions
    {
        public static XmlDocument ToXmlDocument(this string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return doc;
            }
            catch
            {
                return null;
            }
        }
    }
}
