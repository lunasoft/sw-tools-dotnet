using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_Sign
    {
        /// <summary>
        /// Sign
        /// </summary>
        [TestMethod]
        public void UT_Tools_Sign_CrearPFX_OK()
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.key");
            string password = "12345678a";
            var pfx = SW.Tools.Sign.CrearPFX(bytesCer, bytesKey, password);
            Assert.IsTrue(pfx != null);
            X509Certificate x509 = new X509Certificate(pfx, password);
            Assert.IsTrue(x509.GetPublicKey() != null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Los datos del Certificado CER KEY o Password son incorrectos.No es posible leer la llave privada.")]
        public void UT_Tools_Sign_CrearPFX_ERROR()
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.key");
            string password = "12345678";
            var pfx = SW.Tools.Sign.CrearPFX(bytesCer, bytesKey, password);
            Assert.IsTrue(pfx != null);
            X509Certificate x509 = new X509Certificate(pfx, password);
            Assert.IsTrue(x509.GetPublicKey() != null);
        }
        [TestMethod]
        public void UT_Tools_Sign_SellarCFDIv33_OK()
        {
            string selloOriginal = @"SJcA/1ZujR8EzZdAfStXwE5PfM9d2jAuzdLl7VJybm+IGRVXMonYOQWyr9O65s84UAgdXA2lERpj0wKieXeekliFNfq11imGJ+b1qcfrUk/03p+urWCGG16aICE9vySszWnpyyqCL1T+o6aa+lbAs6P0J6mnRYXhrjtICw+vNtGUU0EzucBrTZUKL2cKiCXAFXIdMpzq1zzae9HWCvOA41XtO5muBhd9hoD/wz5Ueenhy6Ge517RxqEGZ5sZVFRDTdwiVTBTNlMagN5Pefw2riZZL0NRwDJRP9eVWzAxoSlSq36dF1Dcv8jd1fZ2tAIzLkYKKmMsb+RKWqnX/cW2Vg==";
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.key");
            string password = "12345678a";
            var pfx = SW.Tools.Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            var xmlResult = SW.Tools.Sign.SellarCFDIv33(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            var sello = doc.DocumentElement.GetAttribute("Sello");
            Assert.IsTrue(selloOriginal.Equals(sello));
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalCFDIv33_OK()
        {

            var xml = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            string CadenaOriginal = "||3.3|RogueOne|HNFK231|2017-09-13T13:49:07|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||";
            var result_ = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml(SW.Tools.Sign.CadenaOriginalCFDIv33(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
            
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalCFDIv33_ERROR()
        {

            var xml = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml( Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            string CadenaOriginal = "||3.3|RogueOne|HNFK231|2017-09-13T13:49:07|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||";
            var result_ = SW.Tools.Sign.CadenaOriginalCFDIv33(xml);
            Assert.IsTrue(CadenaOriginal.Equals(result_));

        }
    }
}
