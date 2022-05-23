using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using SW.Tools.Services.Sign;
using SW.Tools.Services.Fiscal;
using System.Collections.Generic;
using SW.Services.Cancelation;
using SW.ToolsUT.Helpers;
using System.Security.Cryptography;
using SW.Tools.Entities.Cancelacion;

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
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            Assert.IsTrue(pfx != null);
            X509Certificate x509 = new X509Certificate(pfx, password);
            Assert.IsTrue(x509.GetPublicKey() != null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Los datos del Certificado CER KEY o Password son incorrectos.No es posible leer la llave privada.")]
        public void UT_Tools_Sign_CrearPFX_ERROR()
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            Assert.IsTrue(pfx != null);
            X509Certificate x509 = new X509Certificate(pfx, password);
            Assert.IsTrue(x509.GetPublicKey() != null);
        }
        [TestMethod]
        public void UT_Tools_Sign_SellarCFDIv33_OK()
        {
            string selloOriginal = @"Hm4Lc+sWGUf+D74bm1yej73532b1FcKNdKvM5aoYVkcFUwCTrdNYmpOQv5u+GjqyTd458NT+CmaJYHXSq7pjTDr8r5D+weP5xgZcfgdxC+FGuXpvhN++Kn4/WCMSQTvzeeDeigl3rsJKKAdu4rcVYpMrb8gEdrT6ajXfARHgiQasQL7aIuB1J9RWj3Ay/9ZZjRPtos6VYqZirrcKCyy1dPTQsqzpLpLU8sxwdUX12Eu1HXR7HGrIee/fboq+bwd/rA/FINnZHhEJH9qnyd7AOYHKGCfwltqJcY1FuaunVp6Dc14I90JVNKxNzaEkmeuAym5QE3nUio/oIDp8GQcznA==";
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            var xmlResult = Sign.SellarCFDIv33(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            var sello = doc.DocumentElement.GetAttribute("Sello");
            Assert.IsTrue(selloOriginal.Equals(sello));
        }
        [TestMethod]
        public void UT_Tools_Sign_SellarCFDIv40_OK()
        {
            string selloOriginal = @"h4On+n0hpaZ13iDhyhXk9xDLRO3H3+4JWaTgw8S07ctKvrloHHP4K3tHNeT55ckDDxG6uXOvmpYA6nJ5aqH+h0LzJN/NDLAeaipxGgAZbelrN+gZ/AwgfIVaioVJ0f5pqpE4ReDUOcrtH8diXmeY2/yVw1hggXVJpUVf/y3uW9YvmsGyefAZh3zuupmWe9D3Xde/hqzYfhmsP86R5dROixiHkSIPjsCD4t2PnmxOZeGuKE7eHAB+766zoH/drKhru9hVWhn3+BtU/xFYRFQPu5lVmpbj9y5C+gWix+Rlp/krBNzLbdSBDCK5wqBfuC+vQZH7Z/h+EtHPms16tgCrtQ==";
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi40.xml")));
            var xmlResult = Sign.SellarCFDIv40(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            var sello = doc.DocumentElement.GetAttribute("Sello");
            Assert.IsTrue(selloOriginal.Equals(sello));
        }
        [TestMethod]
        public void UT_Tools_Sign_SellarRetencionv20_OK()
        {
            string selloOriginal = @"TEOLSNcpyqoEd3PIrJaD9mXMaG6IFcgAmupCvlGj2QY1wl3SxzdiFCudAo9IvL4Rt2ih3OZXgUImhEr/VwOBX4z8RlBY2OafNLNtBSs+TNiQeoYaT1fwr+y1fQusoeKx+kkIaBaFmm53OS61Kh3CZkThvAMgGTpOUsetHF+xauj1u6dnziq28u45jbwvOv7bM7Y5s1krosRxnx0kqd3LGtM5vyCeckQqOWhW4IPc58h5ci7PSv57S+7hcuy3Z8Wyeg0AqSXinaU+svf9D5VcWihVcP4kefdqWqGRr3huG6uVscTCubSwKWwPJHAEuzYqGx3N65POZFjArgG+OonvjQ==";
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion20.xml")));
            var xmlResult = Sign.SellarRetencionv20(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            var sello = doc.DocumentElement.GetAttribute("Sello");
            Assert.IsTrue(selloOriginal.Equals(sello));
        }
        [TestMethod]
        public void UT_Tools_Sign_SellarRetencionv10_OK()
        {
            string selloOriginal = @"QoeC1EjhMBQIRCsPNzLWpBVqFuWyhpRXC94fQ49X1G0j0FYkLGnGcdvrC0kvNkHO3i9oUQvu1bDyYYlELsQpk2xCyLbP93B38rTFox63dbIceq4Qke4MSZiq5CdZjoWL2C1y2EIKmXKqsnl2R22ImN/bEblgUjaPPHLGTePdUO5nRuSpWZDujXo1PZSJSaKM4XM1pA4+BOalUpYiODZBsxkfmCQ1MnVlhMFGvyUdCBnkRtn2vJbCSj5WBpywmzeAJ+u7IFLOJVWX2WGylyBAO2i4dU1o1X2tc6Ax7otHfFOPKwFn1QNce4e90PmlT+uS9ZupiLA8KG60pIiS4/BalA==";
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion10.xml")));
            var xmlResult = Sign.SellarRetencionv10(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            var sello = doc.DocumentElement.GetAttribute("Sello");
            Assert.IsTrue(selloOriginal.Equals(sello));
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalCFDIv33_OK()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            string CadenaOriginal = "||3.3|RogueOne|HNFK231|2022-01-04T00:00:00|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|EKU9003173C9|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalCFDIv33(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        /// <summary>
        /// Cadena Original Carta Porte 2.0
        /// </summary>
        [TestMethod]
        public void UT_Tools_CadenaOriginalCFDIv33_CP20_OK() 
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33_cp20.xml")));
            string CadenaOriginal = "||3.3|RogueOne|HNFK231|2022-01-04T00:14:54|01|20001000000300022816|25000.00|MXN|1|28000.00|I|PUE|06300|EKU9003173C9|SW TRANSPORTES|601|AAA010101AAA|SW SMARTERWEB|G03|78101500|01|1|E48|SERVICIO|FLETE|25000.00|25000.00|25000.00|002|Tasa|0.160000|4000.00|25000.00|002|Tasa|0.040000|1000.00|002|1000.00|1000.00|002|Tasa|0.160000|4000.00|4000.00|2.0|No|2|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca 1|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca 2|004|COA|MEX|25350|Destino|DE202021|AAA010101AAA|2021-11-01T02:00:00|1|calle|220|0347|23|casa blanca 3|004|COA|MEX|25350|2.0|XBX|2|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202020|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202021|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros Ambientales|123456789|SW Seguros|CTR021|ABC123|01|VAAM130719H60|a234567890||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalCFDIv33(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException), "Assert.IsTrue failed.")]
        public void UT_Tools_CadenaOriginalCFDIv33_ERROR()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml( Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            string CadenaOriginal = "||3.3|RogueOne|HNFK231|2017-09-13T13:49:07|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||";
            var result_ = Sign.CadenaOriginalCFDIv33(xml);
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalCFDIv40_OK()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi40.xml")));
            string CadenaOriginal = "||4.0|Serie|Folio|2022-02-08T00:18:10|30001000000400002434|CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE SA DE CV|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA SA DE CV|65000|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalCFDIv40(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException), "Assert.IsTrue failed.")]
        public void UT_Tools_CadenaOriginalCFDIv40_Error()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi40.xml")));
            string CadenaOriginal = "||4.0|Serie|Folio|2022-02-08T00:18:11|30001000000400002434|CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE SA DE CV|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA SA DE CV|65000|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalCFDIv40(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalRetencionv20_OK()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion20.xml")));
            string CadenaOriginal = "||2.0|30001000000400002434|9|2022-02-15T02:48:02|45110|01|EKU9003173C9|ESCUELA KEMPER URGATE SA DE CV|601|Nacional|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA SA DE CV|65000|01|03|2021|2000.00|2000.00|0|580.00|2000|002|580.00|01||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalRetencionv20(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException), "Assert.IsTrue failed.")]
        public void UT_Tools_CadenaOriginalRetencionv20_Error()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion20.xml")));
            string CadenaOriginal = "||2.0|30001000000400002234|9|2022-02-15T02:48:02|45110|01|EKU9003173C9|ESCUELA KEMPER URGATE SA DE CV|Nacional|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA SA DE CV|65000|01|03|2021|2000.00|2000.00|0|580.00|2000|002|580.00|01||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalRetencionv20(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        public void UT_Tools_CadenaOriginalRetencionv10_OK()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion10.xml")));
            string CadenaOriginal = "||1.0|30001000000400002434|R-1|2022-05-22T12:49:36-06:00|02|Derechos de autor por regalias de obra intelectual|EKU9003173C9|ESCUELA KEMPER URGATE|Extranjero|SMARTERWEB|5|5|2022|1000|1000.00|0.00|400|02|400|Pago definitivo|1.0|NO|XEXX010101000|XEXX010101HNEXXXA4|SMARTERWEB|3|Derechos de autor por regalias de obra intelectual||";
            var result_ = Fiscal.RemoverCaracteresInvalidosXml(Sign.CadenaOriginalRetencionv10(xml));
            Assert.IsTrue(CadenaOriginal.Equals(result_));
        }
        [TestMethod]
        public void UT_Tools_SellarCancelacion_OK()
        {
            var build = new BuildSettings();
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion()
            {
                Folio = Guid.Parse("b6a15ce8-0fb8-401a-bfe7-8930983e182e"),
                Motivo = CancelacionMotivo.Motivo01,
                FolioSustitucion = Guid.Parse("63187375-3433-4ae8-ad5a-3323872026fc")
            });
            folios.Add(new Cancelacion()
            {
                Folio = Guid.Parse("63187375-3433-4ae8-ad5a-3323872026fc"),
                Motivo = CancelacionMotivo.Motivo02
            });
            var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            Cancelation cancelation = new Cancelation(build.Url, build.Token);
            var cancelacion = cancelation.CancelarByXML(Encoding.UTF8.GetBytes(xml));
            Assert.IsTrue(cancelacion.status == "success");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Los folios no tienen un formato válido.")]
        public void UT_Tools_SellarCancelacion_Error()
        {
            var build = new BuildSettings();
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion()
            {
                Motivo = CancelacionMotivo.Motivo02
            });
            try
            {
                var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            }
            catch
            {
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(CryptographicException), "Error al sellar el XML.")]
        public void UT_Tools_SellarCancelacion_Error_2()
        {
            var build = new BuildSettings();
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion() { 
                Folio = Guid.NewGuid(),
                Motivo = CancelacionMotivo.Motivo02
            });
            try
            {
                var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, Encoding.Default.GetBytes("My pfx"), build.CerPassword);
            }
            catch
            {
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "El listado de folios esta vacio.")]
        public void UT_Tools_SellarCancelacion_Error_3()
        {
            var build = new BuildSettings();
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            try
            {
                var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            }
            catch
            {
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "El motivo de cancelación no es válido.")]
        public void UT_Tools_SellarCancelacion_Error_4()
        {
            var build = new BuildSettings();
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion()
            {
                Folio = Guid.NewGuid(),
                Motivo = CancelacionMotivo.Motivo01
            });
            try
            {
                var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            }
            catch
            {
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "No se ha especificado un motivo de cancelacion.")]
        public void UT_Tools_SellarCancelacion_Error_5()
        {
            var build = new BuildSettings();
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion()
            {
                Folio = Guid.NewGuid()
            });
            try
            {
                var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            }
            catch
            {
                throw;
            }
        }
    }
}
