using SW.Tools.Entities.Cancelacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

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
        /// <summary>
        /// Crear XML de cancelacion, recibe una lista de folios con el formato uuid,motivo,uuidSustitucion
        /// </summary>
        /// <param name="foliosFiscales">Lista de folios a cancelar con el formato uuid,motivo,uuidSustitucion</param>
        /// <param name="rfcEmisor">RFC Emisor</param>
        /// <param name="isRetencion">Especifica si es un XML de retencion</param>
        /// <returns></returns>
        public static string CreateCancelationXML(List<Cancelacion> foliosFiscales, string rfcEmisor, bool isRetencion = false)
        {
            XNamespace satCancelacionXmlNamespace = isRetencion ? "http://www.sat.gob.mx/esquemas/retencionpago/1" : "http://cancelacfd.sat.gob.mx";
            var xmlSolicitud = new XElement(satCancelacionXmlNamespace + "Cancelacion",
                                            new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                            new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                                            new XAttribute("Fecha", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                                            new XAttribute("RfcEmisor", rfcEmisor),
                                            from uuid in foliosFiscales
                                            select new XElement(satCancelacionXmlNamespace + "Folios",
                                                new XElement(satCancelacionXmlNamespace + "Folio",
                                                new XAttribute("UUID", uuid.Folio.ToString()),
                                                new XAttribute("Motivo", Convert.ToInt16(uuid.Motivo).ToString().PadLeft(2, '0')),
                                                new XAttribute("FolioSustitucion", uuid.FolioSustitucion != null ? uuid.FolioSustitucion.ToString() : String.Empty)
                                                )));
            return xmlSolicitud.ToString();
        }
    }
}
