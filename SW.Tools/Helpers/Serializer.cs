using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SW.Tools.Helpers
{
    public partial class Serializer
    {
        public static string SerializeDocumentToXml<T>(T obj)
        {
            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlString = Helpers.Encodins.UTF8ByteArrayToString(memoryStream.ToArray());
                return Helpers.Xml.RemoveInvalidCharacters(xmlString);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static T DeserealizeDocument<T>(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                stream = new StringReader(xml);
                reader = new XmlTextReader(stream);
                return (T)serializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (reader != null) reader.Close();
            }
        }
        //public static string SerializarComplemento<T>(T complemento, string nsPrefix, string satPath, string xsdPath)
        //{
        //    MemoryStream stream = null;
        //    TextWriter writer = null;
        //    try
        //    {
        //        UTF8Encoding encoding = new UTF8Encoding();
        //        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        //        ns.Add(nsPrefix, satPath);

        //        stream = new MemoryStream();
        //        writer = new StreamWriter(stream, encoding);

        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        serializer.Serialize(writer, complemento, ns);
        //        int count = (int)stream.Length;
        //        byte[] arr = new byte[count];
        //        stream.Seek(0, SeekOrigin.Begin);
        //        stream.Read(arr, 0, count);
        //        string xml = encoding.GetString(arr).Trim();
        //        xml = SW.Commons.Helpers.Xml.RemoveInvalidCharacters(xml);

        //        XmlDocument doc = new XmlDocument();
        //        doc.LoadXml(xml);

        //        XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
        //        aSchemaLocation.Value = satPath + " " + xsdPath;
        //        doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);

        //        return doc.OuterXml;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        if (stream != null) stream.Close();
        //        if (writer != null) writer.Close();
        //    }
        //}
    //    public static T DeserealizeDocument<T>(byte[] xml)
    //    {
    //        StringReader stream = null;
    //        XmlTextReader reader = null;
    //        try
    //        {
    //            XmlSerializer serializer = new XmlSerializer(typeof(T));
    //            stream = new StringReader(Encoding.UTF8.GetString(xml));
    //            reader = new XmlTextReader(stream);
    //            return (T)serializer.Deserialize(reader);
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception(e.Message);
    //        }
    //        finally
    //        {
    //            if (stream != null) stream.Close();
    //            if (reader != null) reader.Close();
    //        }
    //    }
    //    public static TimbreFiscalDigital GetTFD(SW.CFDISDK.CFDI32.Comprobante comprobante)
    //    {
    //        var tfd = new TimbreFiscalDigital();
    //        //Complementos
    //        if (null != comprobante.Complemento && null != comprobante.Complemento.Any)
    //        {
    //            foreach (XmlElement element in comprobante.Complemento.Any)
    //            {

    //                switch (element.Name.ToLower())
    //                {
    //                    case "tfd:timbrefiscaldigital":
    //                    case "timbrefiscaldigital":
    //                        StringBuilder xmlOutputTimbre = new StringBuilder();
    //                        using (XmlWriter writer = XmlWriter.Create(xmlOutputTimbre))
    //                        {
    //                            element.WriteTo(writer);
    //                        }
    //                        tfd = Serializer.DeserealizeEntity<TimbreFiscalDigital>(xmlOutputTimbre.ToString());
    //                        break;
    //                }
    //            }
    //        }
    //        return tfd;
    //    }
    //    public static T DeserealizeEntity<T>(string xml)
    //    {
    //        xml = SW.Commons.Helpers.Xml.RemoveInvalidCharacters(xml);
    //        XmlSerializer xs = new XmlSerializer(typeof(T));
    //        MemoryStream memoryStream = new MemoryStream(SW.Commons.Helpers.SwEncoding.StringToUTF8ByteArray(xml));
    //        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
    //        return (T)xs.Deserialize(memoryStream);
    //    }
    }
}
