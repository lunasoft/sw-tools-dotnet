using System.IO;
using System.Text;
using System.Xml;

namespace SW.Tools.Helpers
{
    public static class Xml
    {
        public static XmlElement GetXMLElement(string xmlSerialized)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlSerialized);
            return doc.DocumentElement;
        }
        public static string RemoveInvalidCharacters(string xmlInvoice)
        {
            xmlInvoice = xmlInvoice.Replace("\r\n", "");
            xmlInvoice = xmlInvoice.Replace("\r", "");
            xmlInvoice = xmlInvoice.Replace("\n", "");
            xmlInvoice = xmlInvoice.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", @"<?xml version=""1.0"" encoding=""utf-8""?>").Trim();
            xmlInvoice = xmlInvoice.Replace("﻿", "");
            xmlInvoice = xmlInvoice.Replace(@"
", "");
            return xmlInvoice;
        }
    }
}
