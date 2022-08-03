using SW.Tools.Entities.StampResponse;
using SW.Tools.Helpers;
using System;
using System.Xml;

namespace SW.Tools.Services.Convertion
{
    internal class ConvertionService
    {
        internal static string ConvertResponse(string response)
        {
            try
            {
                var stampResponse = Serializer.DeserializeJson<StampResponseV2>(response);
                var result = ConvertResponse(stampResponse.data.cfdi, stampResponse.data.tfd);
                result.status = stampResponse.status;
                return Serializer.SerializeJson<StampResponseV4>(result);
            }
            catch(Exception e)
            {
                throw new Exception("No se ha realizado la conversion, response no valido.", e);
            }
        }
        private static StampResponseV4 ConvertResponse(string cfdi, string tfd)
        {
            XmlDocument xCfdi = new XmlDocument();
            XmlDocument xTfd = new XmlDocument();
            StampResponseV4 response = new StampResponseV4();
            response.data = new StampResponse_Data_v4();
            xCfdi.LoadXml(cfdi);
            xTfd.LoadXml(tfd);
            var emisor = xCfdi.GetElementsByTagName("cfdi:Emisor")[0].Attributes;
            var receptor = xCfdi.GetElementsByTagName("cfdi:Receptor")[0].Attributes;
            string total = xCfdi.SelectSingleNode("//@Total").Value;
            response.data.fechaTimbrado = xTfd.SelectSingleNode("//@FechaTimbrado").Value;
            response.data.selloSAT = xTfd.SelectSingleNode("//@SelloSAT").Value;
            response.data.selloCFDI = xTfd.SelectSingleNode("//@SelloCFD").Value;
            response.data.noCertificadoSAT = xTfd.SelectSingleNode("//@NoCertificadoSAT").Value;
            response.data.uuid = xTfd.SelectSingleNode("//@UUID").Value;
            response.data.noCertificadoCFDI = xCfdi.SelectSingleNode("//@NoCertificado").Value;
            response.data.cfdi = cfdi;
            response.data.qrCode = QrCode.GetQrCode(total, response.data.selloCFDI, emisor.GetNamedItem("Rfc").Value, receptor.GetNamedItem("Rfc").Value, response.data.uuid);
            response.data.cadenaOriginalSAT = SignUtils.GetCadenaOriginalTfd(tfd);
            return response;
        }
    }
}
