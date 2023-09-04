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
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");
            pago.SetTotales("200.00");
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
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
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");
            pago.SetTotales("200.00");
            string[] lista = new string[1];
            lista[0] = "0aded095-b84d-4364-8f8e-59c3f650e530";
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1", "04", lista);
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
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
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");
            pago.SetTotales("200.00", null, null, null, "100.00", "16.00");
            pago.SetImpuestoTrasladoDR("Tasa", "002", 100.00m, 0.160000m, 16.00m);
            pago.SetImpuestoTraslados( "Tasa", "002", 100.00m, 0.160000m, 16.00m);
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
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
            pago.SetPago("03", null, DateTime.Now, null, "USD", 5.62m, null, null, null, null, 20.64m);

            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "02", 20.64m, 116.00m, 116.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");

            pago.SetTotales("116.00", null, null, null, "99.90", "15.89");
            pago.SetImpuestoTrasladoDR( "Tasa", "002", 100.00m, 0.160000m, 16.00m);
            pago.SetImpuestoTraslados("Tasa", "002", 4.84m, 0.160000m, 0.77m  );
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT5_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 100.00m, null, null, null, null, 1m);

            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "02", 1m, 100.00m, 100.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");

            pago.SetTotales("100.00", "16.00", "35.00", "34.40", null, null);
            pago.SetImpuestoRetencionDR( "Tasa", "001", 100.00m, 0.000000m,  0.00m);
            pago.SetImpuestoRetencionDR( "Tasa", "001", 100.00m, 0.350000m,  35.00m);
            pago.SetImpuestoRetencionDR( "Tasa", "002", 100.00m, 0.000000m,  0.00m);
            pago.SetImpuestoRetencionDR( "Tasa", "002", 100.00m, 0.160000m, 16.00m);
            pago.SetImpuestoRetencionDR( "Cuota", "003", 100.00m, 0.000000m, 0.00m);
            pago.SetImpuestoRetencionDR( "Tasa", "003", 100.00m, 0.304000m, 30.40m);
            pago.SetImpuestoRetencionDR( "Cuota", "003", 100.00m, 0.040000m, 4.00m);
            pago.SetImpuestoRetenciones(35.00m, "001");
            pago.SetImpuestoRetenciones(16.00m, "002");
            pago.SetImpuestoRetenciones(34.40m, "003");
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT6_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("03", null, DateTime.Now, null, "EUR", 100.00m, null, null, null, null, 25.00m);

            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "USD", "1", "02", 11.60m, 1160.00m, 1160.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");

            pago.SetTotales("2500.00", "3", "0", null, null, null,null,null,null,null, "215.50");
            pago.SetImpuestoRetencionDR("Tasa", "002", 100.00m, 0.012500m, 1.25m);
            pago.SetImpuestoTrasladoDR("Exento", "002", 100.00m);
            pago.SetImpuestoRetenciones(0.10m, "002");
            pago.SetImpuestoTraslados("Exento", "002", 8.62m );
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT7_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 200.00m, null, null, null, null, 1m);

            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "02", 1m, 200.00m, 100.00m, 100.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");

            pago.SetTotales("200.00", null, null, null, "200.00", "32.00", null, null, null, null, null);
            pago.SetImpuestoTrasladoDR("Tasa", "002", 100.00m, 0.160000m, 16.00m);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "02", 1m, 200.00m, 100.00m, 100.00m);
            pago.SetImpuestoTrasladoDR("Tasa", "002", 100.00m, 0.160000m, 16.00m);

            pago.SetImpuestoTraslados("Tasa", "002", 200.00m, 0.160000m,32.00m);
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            Stamp stamp = new Stamp(this.url, this.userStamp, this.passwordStamp);
            StampResponseV2 response = stamp.TimbrarV2(xmlInvoice);
            var invoiceResultStamp = SW.Tools.Helpers.Serializer.DeserealizeDocument<SW.Tools.Cfdi.Comprobante>
                (response.data.cfdi);
            Assert.IsTrue(response.status == "success");

        }
        [TestMethod]
        public void UT8_StampInvoicePagos20()
        {
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();
            pago.SetPago("01", null, DateTime.Now, null, "MXN", 7097.37m, null, null, null, null, 1m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "01160", "606");
            pago.SetTotales("14194.74", null, null, null, "12236.84", "1957.88", null, null, null, null, null);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "USD", "2", "02", 0.049693m, 352.69m, 352.69m, 0m);
            pago.SetImpuestoTrasladoDR("Tasa","002", 304.043103m, 0.160000m,48.646897m);
            pago.SetImpuestoTraslados("Tasa", "002", 6118.42m,  0.160000m, 978.94m);

            pago.SetPago("01", null, DateTime.Now, null, "MXN", 7097.37m, null, null, null, null, 1m);

            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "USD", "2", "02", 0.049693m, 352.69m, 352.69m, 0m);
            pago.SetImpuestoTrasladoDR("Tasa", "002", 304.043103m, 0.160000m, 48.646897m);
            pago.SetImpuestoTraslados("Tasa", "002", 6118.42m, 0.160000m, 978.94m);
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");
            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
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
    }
}
