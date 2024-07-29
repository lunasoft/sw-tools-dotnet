using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using SW.Services.Authentication;
using SW.Services.Stamp;
using SW.Services.Cancelation;
using SW.Tools.Entities.Complementos;
using SW.Tools.Entities;
using SW.Tools.Services.Sign;
using SW.Tools.Services.Fiscal;
using SW.Tools.Cfdi;
using SW.Tools.Cfdi.Complementos.Pagos20;
using SW.Tools.Helpers;
using Comprobante = SW.Tools.Cfdi.Comprobante;
using SW.ToolsUT.Helpers;

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_BuildInvoiceCFDI40
    {
        private readonly BuildSettings _build;
        public UT_Tools_BuildInvoiceCFDI40()
        {
            _build = new BuildSettings();
        }

        [TestMethod]
        public void UT_StampInvoice()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetConcepto(1, "84131500", "ZZ", "Prima neta", "1", "NO APLICA", 3592.83m, "02", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 3592.83m, 0.160000m, 574.85m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m, "02", 258.68m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002",  258.68m, 0.160000m, 41.38m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 550.00m, 0.160000m, 88.00m);
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "86991", "601");
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success");
        }

        [TestMethod]
        public void UT_CFDI40_InformacionGlobal()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "65000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 550.00m, 0.160000m, 88.00m);
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetReceptor("XAXX010101000", "PUBLICO EN GENERAL", "S01", "65000", "616");
            comprobante.SetInformacionGlobal("01", "04", "2023");
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success"|| response.message == "307. El comprobante contiene un timbre previo.");
        }
        [TestMethod]

        public void UT_CFDI40_AcuentaTerceros()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 550.00m, 0.160000m, 88.00m);
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetAcuentaTerceros("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "601", "01160");
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "86991", "601");
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success");
        }
        [TestMethod]
        public void UT_CFDI40_CFDIRelacionados()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetConcepto(1, "84131500", "ZZ", "Prima neta", "1", "NO APLICA", 3592.83m, "02", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 3592.83m, 0.160000m, 574.85m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m, "02", 258.68m);
            comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 258.68m, 0.160000m, 41.38m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
            comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 550.00m, 0.160000m, 88.00m);
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            string[] lista1 = new string[2];
            lista1[0] = "0aded095-b84d-4364-8f8e-59c3f650e530";
            lista1[1] = "2da2a676-f424-4898-a190-79253fdf5f7a";
            comprobante.SetCFDIRelacionado("03", lista1);
            string[] lista2 = new string[2];
            lista2[0] = "0aded095-b84d-4364-8f8e-59c3f650e531";
            lista2[1] = "2da2a676-f424-4898-a190-79253fdf5f7b";
            comprobante.SetCFDIRelacionado("04", lista2);
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "86991", "601");
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success");
        }
        [TestMethod]
        public void UT_CFDI40_CFDIExentos()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "86991", "601");
            comprobante.SetConcepto(1, "50211503", "H87", "Cigarros",null, "Pieza", 200.00m, "02", 200.00m);
            comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 1m, 0.000000m, 0.00m);
            comprobante.SetConceptoImpuestoTraslado("Exento", "002", 1m);
            comprobante.SetConceptoImpuestoRetencion(1m, "001", "Tasa", 0.000000m, 0.00m);
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success");
        }
        [TestMethod]
        public void UT_CFDI40_CFDIJustExento()
        {
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01", "SW-Tools-dotnet", Guid.NewGuid().ToString());
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "86991", "601");
            comprobante.SetConcepto(1, "50211503", "H87", "Cigarros", null, "Pieza", 200.00m, "02", 200.00m);
            comprobante.SetConceptoImpuestoTraslado("Exento", "002", 1m);
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(_build.Url, _build.User, _build.Password);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            Assert.IsTrue(response.status == "success");
        }
        private string SignInvoice(string xmlInvoice)
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xmlResult = Sign.SellarCFDIv40(pfx, password, xmlInvoice);
            return xmlResult.data.xml;
        }
    }
}
