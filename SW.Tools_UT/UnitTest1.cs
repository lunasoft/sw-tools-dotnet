using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Tools.Issue;
namespace SW.Tools_UT
{
    [TestClass]
    public class BuildInvoiceCFDI33
    {
        [TestMethod]
        public void GetInvoice()
        {
            Tools.Entities.Comprobante comprobante = new Tools.Entities.Comprobante();
            comprobante.SetConcepto(10.0000m, "01010101", "LTR", "Concepto test para timbrado 33", 0, 445.50m, null, "Litros", 44.5500m);
            comprobante.SetImpuestoTraslado(118.65m, "003", 0.300000m, "Tasa");
            comprobante.SetImpuestoTraslado(63.28m, "002", 0.160000m, "Tasa");
            comprobante.SetCFDIRelacionado("aa", "asaas");
            var strInvoice= Tools.Helpers.Serializer.SerializeDocumentToXml(comprobante);


            //CFDI33 invoiceFactory = new CFDI33();
            //invoiceFactory.SetConcept(1, "1", "01", "descripcion", .5m, 1, "NoIDentificacion", "Unidad", 1);
            //invoiceFactory.SetConcept(2, "2", "02", "descripcion", .5m, 1, "NoIDentificacion", "Unidad", 2);

            //var invoice = invoiceFactory.GetInvoice();

            //SW.Tools.Entities.Comprobante comprobante = (SW.Tools.Entities.Comprobante)invoice;


        }
    }
}
