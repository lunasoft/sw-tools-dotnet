using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;

namespace SW.ToolsUT
{
    /// <summary>
    /// Descripción resumida de UT_Tools_CreateInvoice
    /// </summary>
    [TestClass]
    public class UT_Tools_BuildInvoiceCFDI33
    {
        [TestMethod]
        public void UT_GetInvoice()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<PSG:Factura division='VW' tipoDocumentoFiscal='FA' tipoDocumentoVWM='PSG' version='1.0' xmlns:PSG='http://www.vwnovedades.com/volkswagen/kanseilab/shcp/2009/Addenda/PSG'>
			<PSG:Moneda codigoImpuesto='1A' tipoCambio='1.00' tipoMoneda='MXN'/>
			<PSG:Proveedor correoContacto=''/>
			<PSG:Referencias/>
			<PSG:Solicitante/>
			<PSG:Archivo datos='' tipo='PDF'/>
			<PSG:Partes>
				<PSG:Parte cantidadMaterial='1.0000' codigoImpuesto='1A' descripcionMaterial='DERECHO DE POLIZA' montoLinea='550.0000' posicion='1' precioUnitario='550.0000' unidadMedida=''/>
				<PSG:Parte cantidadMaterial='1.0000' codigoImpuesto='1A' descripcionMaterial='DERECHO DE POLIZA' montoLinea='550.0000' posicion='1' precioUnitario='550.0000' unidadMedida=''/>
				<PSG:Parte cantidadMaterial='1.0000' codigoImpuesto='1A' descripcionMaterial='DERECHO DE POLIZA' montoLinea='550.0000' posicion='1' precioUnitario='550.0000' unidadMedida=''/>
			</PSG:Partes>
		</PSG:Factura>");
            XmlElement addenda = doc.DocumentElement;

            Tools.Entities.Comprobante comprobante = new Tools.Entities.Comprobante();
            comprobante.SetComprobante(Tools.Catalogs.c_Moneda.MXN, Tools.Catalogs.c_TipoDeComprobante.I, Tools.Catalogs.c_FormaPago.Item01, Tools.Catalogs.c_MetodoPago.PPD, "2000");
            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Prima neta", "1", "NO APLICA", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 3592.83m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 258.68m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "derecho de poliza", "1", "NO APLICA", 550.00m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 550.00m);
            comprobante.SetAddenda(addenda);
            comprobante.SetEmisor("AAA010101AAA", "ACCEM SERVICIOS EMPRESARIALES SC", Tools.Entities.c_RegimenFiscal.Item601);
            comprobante.SetReceptor("XAXX010101000", "MIGUEL LANGARKA GENESTA", Tools.Entities.c_UsoCFDI.G03);
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = Tools.Helpers.Serializer.SerializeDocument(invoice);
            Assert.IsTrue(xmlInvoice != "");
        }
        [TestMethod]
        public void UT_GetInvoiceWithXmlComplement()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<cce11:ComercioExterior CertificadoOrigen='0' ClaveDePedimento='A1' Incoterm='DDP' Subdivision='0' TipoCambioUSD='18.5000' TipoOperacion='2' TotalUSD='100.73' Version='1.1' xmlns:cce11='http://www.sat.gob.mx/ComercioExterior11'>
      <cce11:Emisor>
        <cce11:Domicilio Calle='AV PROLONGACION COLON' CodigoPostal='45610' Estado='JAL' Localidad='09' Municipio='098' NumeroExterior='6013' Pais='MEX'/>
      </cce11:Emisor>
      <cce11:Receptor>
        <cce11:Domicilio Calle='1320 S MAIN ST' CodigoPostal='19044-0000' Estado='OH' Municipio='MANSFIELD' NumeroExterior='123' Pais='USA'/>
      </cce11:Receptor>
      <cce11:Destinatario>
        <cce11:Domicilio Calle='2905 Miller Park North ' CodigoPostal='19044-0000' Estado='TX' Municipio='Garland' Pais='USA'/>
      </cce11:Destinatario>
      <cce11:Mercancias>
        <cce11:Mercancia FraccionArancelaria='48191001' NoIdentificacion='CHI-ESU9000' ValorDolares='100.73'/>
      </cce11:Mercancias></cce11:ComercioExterior>");
            XmlElement addenda = doc.DocumentElement;
            Tools.Entities.Comprobante comprobante = new Tools.Entities.Comprobante();
            comprobante.SetComprobante(Tools.Catalogs.c_Moneda.MXN, Tools.Catalogs.c_TipoDeComprobante.I, Tools.Catalogs.c_FormaPago.Item01, Tools.Catalogs.c_MetodoPago.PPD, "2000");
            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Prima neta", "1", "NO APLICA", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 3592.83m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 258.68m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "derecho de poliza", "1", "NO APLICA", 550.00m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 550.00m);
            comprobante.SetComplemento(addenda);
            comprobante.SetEmisor("AAA010101AAA", "ACCEM SERVICIOS EMPRESARIALES SC", Tools.Entities.c_RegimenFiscal.Item601);
            comprobante.SetReceptor("XAXX010101000", "MIGUEL LANGARKA GENESTA", Tools.Entities.c_UsoCFDI.G03);
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = Tools.Helpers.Serializer.SerializeDocument(invoice);
            Assert.IsTrue(xmlInvoice != "");
        }

        [TestMethod]
        public void UT_GetInvoicePagos10()
        {
            SW.Tools.Entities.Pagos pago = new Tools.Entities.Pagos();
            pago.SetPago(Tools.Catalogs.c_FormaPago.Item01, null, DateTime.Now, null, Tools.Catalogs.c_Moneda.USD, 15000.00m, null, "1", null, null, 21.5m);
            pago.SetDoctoRelacionado("RogueOne", "Folio1", "0aded095-b84d-4364-8f8e-59c3f650e530", Tools.Catalogs.c_MetodoPago.PPD, Tools.Catalogs.c_Moneda.MXN, "1", 30000, 15000, 15000);
            pago.SetEmisor("LAN7008173R5", "CINDEMEX SA DE CV", Tools.Entities.c_RegimenFiscal.Item601);
            pago.SetReceptor("AAQM610917QJA", "EMPLEADO SMARTERWEB");
            var invoice = pago.GetInvoice("99056");
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
        }

        [TestMethod]
        public void UT_SignInvoicePagos10()
        {
            SW.Tools.Entities.Pagos pago = new Tools.Entities.Pagos();
            pago.SetPago(Tools.Catalogs.c_FormaPago.Item01, null, DateTime.Now, null, Tools.Catalogs.c_Moneda.USD, 15000.00m, null, "1", null, null, 21.5m);
            pago.SetDoctoRelacionado("RogueOne", "Folio1", "0aded095-b84d-4364-8f8e-59c3f650e530", Tools.Catalogs.c_MetodoPago.PPD, Tools.Catalogs.c_Moneda.MXN, "1", 1, 30000, 15000);
            pago.SetEmisor("LAN8507268IA", "CINDEMEX SA DE CV", Tools.Entities.c_RegimenFiscal.Item601);
            pago.SetReceptor("AAQM610917QJA", "EMPLEADO SMARTERWEB");
            var invoice = pago.GetInvoice("99056");
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
        }
        [TestMethod]
        public void UT_SignInvoice()
        {
            Tools.Entities.Comprobante comprobante = new Tools.Entities.Comprobante();
            comprobante.SetComprobante(Tools.Catalogs.c_Moneda.MXN, Tools.Catalogs.c_TipoDeComprobante.I, Tools.Catalogs.c_FormaPago.Item01, Tools.Catalogs.c_MetodoPago.PPD, "20000");
            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Prima neta", "1", "NO APLICA", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 3592.83m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 258.68m);

            comprobante.SetConcepto(1, Tools.Catalogs.c_ClaveProdServ.Item84131500, Tools.Catalogs.c_ClaveUnidad.ZZ, "derecho de poliza", "1", "NO APLICA", 550.00m);
            comprobante.SetConceptoImpuestoTraslado(0.1600000m, Tools.Entities.c_TipoFactor.Tasa, "002", 550.00m);
            comprobante.SetEmisor("LAN8507268IA", "ACCEM SERVICIOS EMPRESARIALES SC", Tools.Entities.c_RegimenFiscal.Item601);
            comprobante.SetReceptor("XAXX010101000", "MIGUEL LANGARKA GENESTA", Tools.Entities.c_UsoCFDI.G03);
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = Tools.Helpers.Serializer.SerializeDocument(invoice);

            xmlInvoice = SignInvoice(xmlInvoice);
        }
        private string SignInvoice(string xmlInvoice)
        {
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Prueba_CFDI_LAN8507268IA.key");
            string password = "12345678a";
            var pfx = SW.Tools.Sign.CrearPFX(bytesCer, bytesKey, password);
            var xmlResult = SW.Tools.Sign.SellarCFDIv33(pfx, password, xmlInvoice);
            return xmlResult;
        }
    }
}
