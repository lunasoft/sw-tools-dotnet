using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using SW.Tools.Services.Convertion;
using SW.Tools.Entities.StampResponse;
using SW.Tools.Helpers;

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_Convertion
    {
        /// <summary>
        /// Convert Stamp V2 Response To V4 
        /// </summary>
        [TestMethod]
        public void UT_Tools_Convertion_ConvertResponseToV4_OK()
        {
            var response = File.ReadAllText(@"Resources\stampResponsev2.txt");
            var result = Convertion.ConvertResponseToV4(response);
            var basev4 = File.ReadAllText(@"Resources\stampResponsev4.txt");

            var dataResult = GetResponse<StampResponseV4>(result).data;
            var dataBaseV4 = GetResponse<StampResponseV4>(basev4).data;

            Assert.IsTrue(dataResult.cadenaOriginalSAT == dataBaseV4.cadenaOriginalSAT);
            Assert.IsTrue(dataResult.cfdi == dataBaseV4.cfdi);
            Assert.IsTrue(dataResult.noCertificadoCFDI == dataBaseV4.noCertificadoCFDI);
            Assert.IsTrue(dataResult.noCertificadoSAT == dataBaseV4.noCertificadoSAT);
            Assert.IsTrue(dataResult.fechaTimbrado == dataBaseV4.fechaTimbrado);
            Assert.IsTrue(dataResult.uuid == dataBaseV4.uuid);
            Assert.IsTrue(dataResult.selloCFDI == dataBaseV4.selloCFDI);
            Assert.IsTrue(dataResult.selloSAT == dataBaseV4.selloSAT);
        }

        private static T GetResponse<T>(string json)
        {
            return Serializer.DeserializeJson<T>(json);
        }
    }
}
