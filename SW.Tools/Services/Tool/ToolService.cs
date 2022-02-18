using SW.Tools.Entities.StampResponse;
using SW.Tools.Helpers;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace SW.Tools.Services.Tool
{
    internal static class ToolService
    {
        internal static string ConvertResponse(string response)
        {
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(response));
            var serialized = new DataContractJsonSerializer(typeof(StampResponseV2));
            StampResponseV2 stampResponse = (StampResponseV2)serialized.ReadObject(ms);
            var result = ConvertResponse(stampResponse.data.cfdi, stampResponse.data.tfd);
            result.status = stampResponse.status;
            return Serializer.SerializeJson<StampResponseV4>(result);
        }
        private static StampResponseV4 ConvertResponse(string cfdi, string tfd)
        {
            cfdi = Fiscal.RemoverCaracteresInvalidosXml(cfdi);
            tfd = Fiscal.RemoverCaracteresInvalidosXml(tfd);
            XmlDocument xml = new XmlDocument();
            StampResponseV4 response = new StampResponseV4();
            response.data = new StampResponse_Data_v4();
            xml.LoadXml(cfdi);
            var emisor = xml.GetElementsByTagName("cfdi:Emisor")[0].Attributes;
            var receptor = xml.GetElementsByTagName("cfdi:Receptor")[0].Attributes;
            var timbreFiscal = xml.GetElementsByTagName("tfd:TimbreFiscalDigital")[0].Attributes;
            response.data.fechaTimbrado = timbreFiscal.GetNamedItem("FechaTimbrado").Value;
            response.data.selloSAT = timbreFiscal.GetNamedItem("SelloSAT").Value;
            response.data.selloCFDI = timbreFiscal.GetNamedItem("SelloCFD").Value;
            response.data.noCertificadoSAT = timbreFiscal.GetNamedItem("NoCertificadoSAT").Value;
            response.data.uuid = timbreFiscal.GetNamedItem("UUID").Value;
            response.data.noCertificadoCFDI = xml.SelectSingleNode("//@NoCertificado").Value;
            response.data.cfdi = cfdi;
            string total = xml.SelectSingleNode("//@Total").Value;
            response.data.qrCode = Helpers.QrCode.GetQrCode(total, response.data.selloCFDI, emisor.GetNamedItem("Rfc").Value, receptor.GetNamedItem("Rfc").Value, response.data.uuid);
            response.data.cadenaOriginalSAT = SignUtils.GetCadenaOriginalTfd(tfd);
            return response;
        }
    }
}
