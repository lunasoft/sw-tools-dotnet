using SW.Tools.Entities;
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
        public static string SerializeDocument(Pagos pagos)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("pago10", "http://www.sat.gob.mx/Pagos");

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

                XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                aSchemaLocation.Value = "http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd";
                doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);
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

    public partial class Serializer
    {
        static XmlSerializer cfdi33Serializer = new XmlSerializer(typeof(Comprobante));
        public static string SerializeDocument(Comprobante comprobante)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            DateTime now = DateTime.Now.CentralTime();
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("cfdi", "http://www.sat.gob.mx/cfd/3");

                string schemaValues = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd";

                if (comprobante.HasComplemento)
                {
                    foreach (ComprobanteComplemento complemento in comprobante.Complemento)
                    {
                        for (var i = 0; i < complemento?.Any?.Length; i++)
                        {
                            XmlElement element = complemento.Any[i];
                            switch (element.Name.ToLower())
                            {

                                case "detallista:detallista":
                                    schemaValues += " http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd";
                                    ns.Add("detallista", "http://www.sat.gob.mx/detallista");
                                    break;
                                case "divisas:divisas":
                                    schemaValues += " http://www.sat.gob.mx/divisas http://www.sat.gob.mx/sitio_internet/cfd/divisas/Divisas.xsd";
                                    ns.Add("divisas", "http://www.sat.gob.mx/divisas");
                                    break;
                                case "implocal:impuestoslocales":
                                    schemaValues += " http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd";
                                    ns.Add("implocal", "http://www.sat.gob.mx/implocal");
                                    break;
                                case "ecc:estadodecuentacombustible":
                                    schemaValues += " http://www.sat.gob.mx/ecc http://www.sat.gob.mx/sitio_internet/cfd/ecc/ecc.xsd";
                                    ns.Add("ecc", "http://www.sat.gob.mx/ecc");
                                    break;
                                case "ecc11:estadodecuentacombustible":
                                    schemaValues += " http://www.sat.gob.mx/EstadoDeCuentaCombustible http://www.sat.gob.mx/sitio_internet/cfd/EstadoDeCuentaCombustible/ecc11.xsd";
                                    ns.Add("ecc11", "http://www.sat.gob.mx/EstadoDeCuentaCombustible");
                                    break;
                                case "ecb:estadodecuentabancario":
                                    schemaValues += " http://www.sat.gob.mx/ecb http://www.sat.gob.mx/sitio_internet/cfd/ecb/ecb.xsd";
                                    ns.Add("ecb", "http://www.sat.gob.mx/ecb");
                                    break;
                                case "donat:donatarias":
                                    schemaValues += " http://www.sat.gob.mx/donat http://www.sat.gob.mx/sitio_internet/cfd/donat/donat11.xsd";
                                    ns.Add("donat", "http://www.sat.gob.mx/donat");
                                    break;
                                case "leyendasfisc:leyendasfiscales":
                                    schemaValues += " http://www.sat.gob.mx/leyendasFiscales http://www.sat.gob.mx/sitio_internet/cfd/leyendasFiscales/leyendasFisc.xsd";
                                    ns.Add("leyendasfisc", "http://www.sat.gob.mx/leyendasFiscales");
                                    break;
                                case "pfic:pfintegrantecoordinado":
                                    schemaValues += " http://www.sat.gob.mx/pfic http://www.sat.gob.mx/sitio_internet/cfd/pfic/pfic.xsd";
                                    ns.Add("pfic", "http://www.sat.gob.mx/pfic");
                                    break;
                                case "tpe:turistapasajeroextranjero":
                                    schemaValues += " http://www.sat.gob.mx/TuristaPasajeroExtranjero http://www.sat.gob.mx/sitio_internet/cfd/TuristaPasajeroExtranjero/TuristaPasajeroExtranjero.xsd";
                                    ns.Add("tpe", "http://www.sat.gob.mx/TuristaPasajeroExtranjero");
                                    break;
                                case "spei:complemento_spei":
                                    schemaValues += " http://www.sat.gob.mx/spei http://www.sat.gob.mx/sitio_internet/cfd/spei/spei.xsd";
                                    ns.Add("spei", "http://www.sat.gob.mx/spei");
                                    break;
                                case "registrofiscal:cfdiregistrofiscal":
                                    schemaValues += " http://www.sat.gob.mx/registrofiscal http://www.sat.gob.mx/sitio_internet/cfd/cfdiregistrofiscal/cfdiregistrofiscal.xsd";
                                    ns.Add("registrofiscal", "http://www.sat.gob.mx/registrofiscal");
                                    break;
                                case "nomina12:nomina":
                                    schemaValues += " http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd";
                                    ns.Add("nomina12", "http://www.sat.gob.mx/nomina12");
                                    break;
                                case "cce:comercioexterior":
                                    schemaValues += " http://www.sat.gob.mx/ComercioExterior http://sat.gob.mx/informacion_fiscal/factura_electronica/Documents/ComercioExterior10.xsd";
                                    ns.Add("cce", "http://www.sat.gob.mx/ComercioExterior");
                                    break;
                                case "cce11:comercioexterior":
                                    schemaValues += " http://www.sat.gob.mx/ComercioExterior11 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior11/ComercioExterior11.xsd";
                                    ns.Add("cce11", "http://www.sat.gob.mx/ComercioExterior11");
                                    break;
                                case "pagoenespecie:pagoenespecie":
                                    schemaValues += " http://www.sat.gob.mx/pagoenespecie http://www.sat.gob.mx/sitio_internet/cfd/pagoenespecie/pagoenespecie.xsd";
                                    ns.Add("pagoenespecie", "http://www.sat.gob.mx/pagoenespecie");
                                    break;
                                case "consumodecombustibles:consumodecombustibles":
                                    schemaValues += " http://www.sat.gob.mx/consumodecombustibles http://www.sat.gob.mx/sitio_internet/cfd/consumodecombustibles/consumodecombustibles.xsd";
                                    ns.Add("consumodecombustibles", "http://www.sat.gob.mx/consumodecombustibles");
                                    break;
                                case "valesdedespensa:valesdedespensa":
                                    schemaValues += " http://www.sat.gob.mx/valesdedespensa http://www.sat.gob.mx/sitio_internet/cfd/valesdedespensa/valesdedespensa.xsd";
                                    ns.Add("valesdedespensa", "http://www.sat.gob.mx/valesdedespensa");
                                    break;
                                case "aerolineas:aerolineas":
                                    schemaValues += " http://www.sat.gob.mx/aerolineas http://www.sat.gob.mx/sitio_internet/cfd/aerolineas/aerolineas.xsd";
                                    ns.Add("aerolineas", "http://www.sat.gob.mx/aerolineas");
                                    break;
                                case "notariospublicos:notariospublicos":
                                    schemaValues += " http://www.sat.gob.mx/notariospublicos http://www.sat.gob.mx/sitio_internet/cfd/notariospublicos/notariospublicos.xsd";
                                    ns.Add("notariospublicos", "http://www.sat.gob.mx/notariospublicos");
                                    break;
                                case "vehiculousado:vehiculousado":
                                    schemaValues += " http://www.sat.gob.mx/vehiculousado http://www.sat.gob.mx/sitio_internet/cfd/vehiculousado/vehiculousado.xsd";
                                    ns.Add("vehiculousado", "http://www.sat.gob.mx/vehiculousado");
                                    break;
                                case "servicioparcial:parcialesconstruccion":
                                    schemaValues += " http://www.sat.gob.mx/servicioparcialconstruccion http://www.sat.gob.mx/sitio_internet/cfd/servicioparcialconstruccion/servicioparcialconstruccion.xsd";
                                    ns.Add("servicioparcial", "http://www.sat.gob.mx/servicioparcialconstruccion");
                                    break;
                                case "destruccion:certificadodedestruccion":
                                    schemaValues += " http://www.sat.gob.mx/certificadodestruccion http://www.sat.gob.mx/sitio_internet/cfd/certificadodestruccion/certificadodedestruccion.xsd";
                                    ns.Add("destruccion", "http://www.sat.gob.mx/certificadodestruccion");
                                    break;
                                case "decreto:renovacionysustitucionvehiculos":
                                    schemaValues += " http://www.sat.gob.mx/renovacionysustitucionvehiculos http://www.sat.gob.mx/sitio_internet/cfd/renovacionysustitucionvehiculos/renovacionysustitucionvehiculos.xsd";
                                    ns.Add("decreto", "http://www.sat.gob.mx/renovacionysustitucionvehiculos");
                                    break;
                                case "obrasarte:obrasarteantiguedades":
                                    schemaValues += " http://www.sat.gob.mx/arteantiguedades http://www.sat.gob.mx/sitio_internet/cfd/arteantiguedades/obrasarteantiguedades.xsd";
                                    ns.Add("obrasarte", "http://www.sat.gob.mx/arteantiguedades");
                                    break;
                                case "ine:ine":
                                    schemaValues += " http://www.sat.gob.mx/ine http://www.sat.gob.mx/sitio_internet/cfd/ine/ine11.xsd";
                                    ns.Add("ine", "http://www.sat.gob.mx/ine");
                                    break;
                                case "pago10:pagos":
                                    schemaValues += " http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd";
                                    ns.Add("pago10", "http://www.sat.gob.mx/Pagos");
                                    break;
                            }
                        }
                    }
                }

                if (null != comprobante.Conceptos &&
                  comprobante.Conceptos.Length > 0)
                {
                    foreach (ComprobanteConcepto concepto in comprobante.Conceptos)
                    {
                        if (concepto.ComplementoConcepto != null
                            && concepto.ComplementoConcepto.Any != null)
                        {

                            foreach (XmlElement element in concepto.ComplementoConcepto.Any)
                            {
                                switch (element.Name.ToLower())
                                {
                                    case "iedu:insteducativas":
                                        schemaValues += " http://www.sat.gob.mx/iedu http://www.sat.gob.mx/sitio_internet/cfd/iedu/iedu.xsd";
                                        ns.Add("iedu", "http://www.sat.gob.mx/iedu");
                                        break;

                                    case "ventavehiculos:ventavehiculos":
                                        schemaValues += " http://www.sat.gob.mx/ventavehiculos http://www.sat.gob.mx/sitio_internet/cfd/ventavehiculos/ventavehiculos11.xsd";
                                        ns.Add("ventavehiculos", "http://www.sat.gob.mx/ventavehiculos");
                                        break;

                                    case "terceros:porcuentadeterceros":
                                        schemaValues += " http://www.sat.gob.mx/terceros http://www.sat.gob.mx/sitio_internet/cfd/terceros/terceros11.xsd";
                                        ns.Add("terceros", "http://www.sat.gob.mx/terceros");
                                        break;

                                    case "aieps:acreditamientoieps":
                                        schemaValues += " http://www.sat.gob.mx/acreditamiento http://www.sat.gob.mx/sitio_internet/cfd/acreditamiento/AcreditamientoIEPS10.xsd";
                                        ns.Add("aieps", "http://www.sat.gob.mx/acreditamiento");
                                        break;
                                }
                            }
                        }
                    }
                }

                UTF8Encoding encoding = new UTF8Encoding();
                stream = new MemoryStream();

                writer = new StreamWriter(stream, encoding);
                XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
                serializer.Serialize(writer, comprobante, ns);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                string xml = encoding.GetString(arr).Trim();
                xml = Xml.RemoveInvalidCharacters(xml);
                xml = DateTimeExtensions.DateTimeFixCFDI("Fecha", xml, "=");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                aSchemaLocation.Value = schemaValues;
                doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);

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
        public static Comprobante DeserealizeDocument(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                stream = new StringReader(xml);
                reader = new XmlTextReader(stream);
                return (Comprobante)cfdi33Serializer.Deserialize(reader);
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
