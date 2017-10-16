using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace SW.Tools_UT
{
    [TestClass]
    public class BuildInvoiceCFDI33
    {
        [TestMethod]
        public void GetInvoice()
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
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocumentToXml(invoice);
            Assert.IsTrue(xmlInvoice != "");
        }
        [TestMethod]
        public void GetInvoiceWithXmlComplement()
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
            var xmlInvoice = SW.Tools.Helpers.Serializer.SerializeDocumentToXml(invoice);
            Assert.IsTrue(xmlInvoice != "");
        }
    }
}
