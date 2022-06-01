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

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_BuildInvoicePagos20
    {
        private string userStamp;
        private string passwordStamp;
        private string url;
        public UT_Tools_BuildInvoicePagos20()
        {
            userStamp = "pruebas_ut@sw.com.mx";
            passwordStamp = "swpass";
            url = "http://services.test.sw.com.mx";
        }

        [TestMethod]
        public void UT_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 200.00m, null, null, null, null, 1m);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "01", 1m, 200.00m, 200.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "29133", "606");
            pago.SetTotales("200.00");
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);

            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT2_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 200.00m, null, null, null, null, 1m);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "01", 1m, 200.00m, 200.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "29133", "606");
            pago.SetTotales("200.00");
            string[] lista = new string[1];
            lista[0] = "0aded095-b84d-4364-8f8e-59c3f650e530";
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1", "04", lista);
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT3_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 200.00m, null, null, null, null, 1m);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "02", 1m, 200.00m, 200.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "29133", "606");
            pago.SetTotales("200.00", null, null, null, "100.00", "16.00");
            pago.SetImpuestoTrasladoDR(0.160000m, "Tasa", "002", 100.00m, 16.00m);
            pago.SetImpuestoTraslados(100.00m, 16.00m, "002", 0.160000m, "Tasa");
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
    public void UT4_StampInvoicePagos20()
    {
        SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
        pago.SetPago("03", "551515122345647888", DateTime.Now, "010203056598051664", "MXN", 200.00m, "NomBancoOrdExt1", "NumOperacion1", "BBA830831LJ2", "BMI9704113PA", 1m);
        
        pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
            "MXN", "1", "02", 1m, 200.00m, 200.00m, 0.00m);
        pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
        pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "29133", "606");

        pago.SetTotales("200.00", null, null, null, "100.00", "16.00");
        pago.SetImpuestoTrasladoDR(0.160000m, "Tasa", "002", 100.00m, 16.00m);
        pago.SetImpuestoTraslados(100.00m, 16.00m, "002", 0.160000m, "Tasa");
        var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
        var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
        xmlInvoice = SignInvoice(xmlInvoice);
        Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
        StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
        var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
            (response.data.cfdi);
        Assert.IsTrue(response.status == "success");

    }

        private string SignInvoice(string xmlInvoice)
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xmlResult = Sign.SellarCFDIv40(pfx, password, xmlInvoice);
            return xmlResult;
        }
        [TestMethod]
        public void DeserailizeXml()
        {
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33Invoice.xml")));
            var xmlInvoicess = Tools.Helpers.Serializer.DeserealizeDocument<Comprobante>(xml);
        }
    }
}
