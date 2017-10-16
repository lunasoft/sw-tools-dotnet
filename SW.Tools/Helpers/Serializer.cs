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
            catch(Exception ex)
            {
                var a = ex;
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
    }
}
