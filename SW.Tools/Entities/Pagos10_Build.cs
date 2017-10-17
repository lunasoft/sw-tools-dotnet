using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Tools.Helpers;
using SW.Tools.Catalogs;
using System.Xml;

namespace SW.Tools.Entities
{
    public partial class Pagos
    {

        public void SetPago(c_FormaPago formaDePagoP, string ctaBeneficiario, DateTime fechaPago, string ctaOrdenante, 
            c_Moneda monedaP, decimal monto, string numBancoOrdenante, string numOperacion, string rfcEmisorCtaBenef, string rfcEmisorCtaOrd, decimal tipoCambioP)
        {
            if (this.PagoList == null)
                this.PagoList = new List<PagosPago>();
            this.PagoList.Add(new PagosPago()
            {
                FechaPago = fechaPago.CentralTime(),
                FormaDePagoP = formaDePagoP.GetString(),
                CtaBeneficiario = ctaBeneficiario,
                CtaOrdenante = ctaOrdenante,
                MonedaP = monedaP.GetString(),
                Monto = monto,
                NomBancoOrdExt = numBancoOrdenante,
                NumOperacion = numOperacion,
                RfcEmisorCtaBen = rfcEmisorCtaBenef,
                RfcEmisorCtaOrd = rfcEmisorCtaOrd,
                TipoCambioP = tipoCambioP
            });
            this.PagoList.Last().Monto = Math.Round(monto, this.Pago.Last().Moneda_Info.Decimales);
            this.PagoList.Last().TipoCambioP = this.PagoList.Last().MonedaP != "MXN" ? tipoCambioP : 0;
            this.PagoList.Last().TipoCambioPSpecified = this.PagoList.Last().TipoCambioP != 0 ? false : true;
        }

        public void SetTipoCadPago(string tipoCatPago, byte[] selloPago, byte[] cerPago, string cadPago)
        {
            if (this.PagoList == null)
                this.PagoList = new List<PagosPago>();
            if (this.PagoList.Count > 0)
            {
                this.PagoList.Last().TipoCadPago = tipoCatPago;
                this.PagoList.Last().TipoCadPagoSpecified = true;
                this.PagoList.Last().CertPago = cerPago;
                this.PagoList.Last().SelloPago = selloPago;
                this.PagoList.Last().CadPago = cadPago;
            }
            else
                this.PagoList.ToList().Add(new PagosPago()
                { TipoCadPago = tipoCatPago, TipoCadPagoSpecified = true, CadPago = cadPago, CertPago = cerPago, SelloPago= selloPago });
        }

        public void SetDoctoRelacionado(string serie, string folio, string idDocumento, c_MetodoPago metodoDePagoDr, c_Moneda monedaDr, string numParcialidad, decimal impSalgoAnt=0, decimal impPagado=0, decimal impSaldoInoluto=-1 )
        {
            if (this.PagoList == null)
                this.PagoList = new List<PagosPago>();
            if (this.PagoList.Last().DoctoRelacionadoList == null)
                this.PagoList.Last().DoctoRelacionadoList = new List<PagosPagoDoctoRelacionado>();
            this.PagoList.Last().DoctoRelacionadoList.Add(new PagosPagoDoctoRelacionado()
            { Folio = folio, IdDocumento = idDocumento, MetodoDePagoDR = metodoDePagoDr.GetString(), MonedaDR = monedaDr.GetString(), NumParcialidad = numParcialidad,
                Serie = serie,ImpPagado = impPagado, ImpSaldoAnt= impSalgoAnt, ImpSaldoInsoluto = impSaldoInoluto });

            Math.Round(this.PagoList.Last().DoctoRelacionadoList.Last().ImpPagado, this.PagoList.Last().DoctoRelacionadoList.Last().Moneda_Info.Decimales);
            Math.Round(this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoAnt, this.PagoList.Last().DoctoRelacionadoList.Last().Moneda_Info.Decimales);
            Math.Round(this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoInsoluto, this.PagoList.Last().DoctoRelacionadoList.Last().Moneda_Info.Decimales);

            this.PagoList.Last().DoctoRelacionadoList.Last().ImpPagadoSpecified = this.PagoList.Last().DoctoRelacionadoList.Last().ImpPagado <= 0 ? false : true;
            this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoAntSpecified = this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoAnt <= 0 ? false : true;
            this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoInsolutoSpecified = this.PagoList.Last().DoctoRelacionadoList.Last().ImpSaldoInsoluto < 0 ? false : true;
        }

        public void SetImpuestoRetenciones(decimal importe, c_Impuesto impuesto)
        {
            if (this.PagoList == null)
                this.PagoList = new List<PagosPago>();
            if (this.PagoList.Last().ImpuestosList != null)
                this.PagoList.Last().ImpuestosList.Add(new PagosPagoImpuestos());
            if (this.PagoList.Last().ImpuestosList.Last().RetencionesList != null)
                this.PagoList.Last().ImpuestosList.Last().RetencionesList = new List<PagosPagoImpuestosRetencion>();
            this.PagoList.Last().ImpuestosList.Last().RetencionesList.Add(new PagosPagoImpuestosRetencion()
            { Importe = importe, Impuesto = impuesto.GetString() });
            this.PagoList.Last().ImpuestosList.Last().TotalImpuestosRetenidos += importe;
            this.PagoList.Last().ImpuestosList.Last().TotalImpuestosRetenidosSpecified = true;
        }

        public void SetImpuestoTraslados(decimal importe, c_Impuesto impuesto, c_TasaOCuota tasaOCuota, c_TipoFactor tipoFactor)
        {
            if (this.PagoList == null)
                this.PagoList = new List<PagosPago>();
            if (this.PagoList.Last().ImpuestosList != null)
                this.PagoList.Last().ImpuestosList.Add(new PagosPagoImpuestos());
            if (this.PagoList.Last().ImpuestosList.Last().TrasladosList != null)
                this.PagoList.Last().ImpuestosList.Last().TrasladosList = new List<PagosPagoImpuestosTraslado>();
            this.PagoList.Last().ImpuestosList.Last().TrasladosList.Add(new PagosPagoImpuestosTraslado()
            { Importe = importe, Impuesto = impuesto.GetString(), TasaOCuota = tasaOCuota.GetString(), TipoFactor = tipoFactor.GetString()});
            this.PagoList.Last().ImpuestosList.Last().TotalImpuestosTrasladados += importe;
            this.PagoList.Last().ImpuestosList.Last().TotalImpuestosTrasladadosSpecified = true;
        }
        private Comprobante invoice;
        public Pagos()
        {
            this.versionField = "1.0";
            this.invoice = new Comprobante();
        }
        public void SetEmisor(string rfc, string nombre, c_RegimenFiscal regimenFiscal)
        {
            this.invoice.Emisor.Nombre = nombre;
            this.invoice.Emisor.RegimenFiscal = regimenFiscal.GetString();
            this.invoice.Emisor.Rfc = rfc;
        }

        public void SetReceptor(string rfc, string nombre, string residenciaFiscal = null, string numRegIdTrib = null)
        {
            this.invoice.Receptor.Rfc = rfc;
            this.invoice.Receptor.Nombre = nombre;
            this.invoice.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.invoice.Receptor.ResidenciaFiscalSpecified = true;
            this.invoice.Receptor.NumRegIdTrib = numRegIdTrib;
            this.invoice.Receptor.UsoCFDI = "P01";
        }
        public Comprobante GetInvoice()
        {
            invoice.TipoDeComprobante = "P";
            invoice.SubTotal = 0;
            invoice.Moneda = "XXX";
            invoice.Total = 0;
            invoice.conceptsList = new List<ComprobanteConcepto>();
            invoice.conceptsList.Add(new ComprobanteConcepto()
            { ClaveProdServ = "84111506", Cantidad = 1, ClaveUnidad = "ACT", Descripcion = "Pago", ValorUnitario = 0, Importe = 0 });
            var xmlPagos = Serializer.SerializeDocument(this);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlPagos);
            invoice.SetComplemento(doc.DocumentElement);
            return invoice;
        }
    }
}
