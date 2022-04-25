using SW.Tools.Cfdi;
using SW.Tools.Cfdi.Complementos.Pagos20;
using SW.Tools.Services.Fiscal;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SW.Tools.Helpers
{
    public partial class Serializer
    {
        /// <summary>
        /// Object to XML
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns></returns>
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
        /// <summary>
        /// Oject to JSON
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns></returns>
        public static string SerializeJson<T>(T obj)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, obj);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string json = reader.ReadToEnd();
            reader.Close();
            stream.Close();

            return Fiscal.RemoverCaracteresInvalidosJson(json);
        }
        /// <summary>
        /// JSON to Object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="json">Object</param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                T obj = (T)deserializer.ReadObject(ms);
                return obj;
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
