using SW.Tools.Cfdi.Complementos.Pagos20;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SW.Tools.Helpers
{
    public partial class SerializerP
    {
        public static string SerializeDocument(Pagos pagos)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("pago20", "http://www.sat.gob.mx/Pagos20");

                stream = new MemoryStream();
                writer = new StreamWriter(stream, encoding);

                XmlSerializer serializer = new XmlSerializer(typeof(Pagos));
                serializer.Serialize(writer, pagos, ns);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                string xml = encoding.GetString(arr).Trim();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                return doc.OuterXml;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (writer != null) writer.Close();
            }
        }
    }
}
