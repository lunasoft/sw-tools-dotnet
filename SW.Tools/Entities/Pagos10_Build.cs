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

        public void SetPago(string formaDePagoP, string ctaBeneficiario, DateTime fechaPago, string ctaOrdenante, 
            string monedaP, decimal monto, string numBancoOrdenante, string numOperacion, string rfcEmisorCtaBenef, 
            string rfcEmisorCtaOrd, decimal tipoCambioP)
        {
            if (this.Pago != null)
            {
                var pagolist = this.Pago.ToList();
                pagolist.Add(new PagosPago()
                {
                    FechaPago = fechaPago.CentralTime().ShortDate(),
                    FormaDePagoP = formaDePagoP,
                    CtaBeneficiario = ctaBeneficiario,
                    CtaOrdenante = ctaOrdenante,
                    MonedaP = monedaP,
                    Monto = monto,
                    NomBancoOrdExt = numBancoOrdenante,
                    NumOperacion = numOperacion,
                    RfcEmisorCtaBen = rfcEmisorCtaBenef,
                    RfcEmisorCtaOrd = rfcEmisorCtaOrd,
                    TipoCambioP = tipoCambioP
                });
                this.Pago = pagolist.ToArray();
            }
            else
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago()
                {
                    FechaPago = fechaPago.CentralTime().ShortDate(),
                    FormaDePagoP = formaDePagoP,
                    CtaBeneficiario = ctaBeneficiario,
                    CtaOrdenante = ctaOrdenante,
                    MonedaP = monedaP,
                    Monto = monto,
                    NomBancoOrdExt = numBancoOrdenante,
                    NumOperacion = numOperacion,
                    RfcEmisorCtaBen = rfcEmisorCtaBenef,
                    RfcEmisorCtaOrd = rfcEmisorCtaOrd,
                    TipoCambioP = tipoCambioP
                };
            }
            this.Pago.Last().Monto = Math.Round(monto, this.Pago.Last().Moneda_Info.Decimales);
            this.Pago.Last().TipoCambioP = this.Pago.Last().MonedaP != "MXN" ? tipoCambioP : 0;
            this.Pago.Last().TipoCambioPSpecified = this.Pago.Last().TipoCambioP != 0 ? true : false;
        }

        public void SetTipoCadPago(string tipoCatPago, byte[] selloPago, byte[] cerPago, string cadPago)
        {
            if (this.Pago != null && this.Pago.Length > 0)
            {
                this.Pago.Last().TipoCadPago = tipoCatPago;
                this.Pago.Last().TipoCadPagoSpecified = true;
                this.Pago.Last().CertPago = cerPago;
                this.Pago.Last().SelloPago = selloPago;
                this.Pago.Last().CadPago = cadPago;
            }
            else
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago()
                { TipoCadPago = tipoCatPago, TipoCadPagoSpecified = true, CadPago = cadPago, CertPago = cerPago, SelloPago = selloPago };
            }
        }

        public void SetDoctoRelacionado(string serie, string folio, string idDocumento, string metodoDePagoDr, 
            string monedaDr, string numParcialidad, decimal tipoCambioDR=-1, decimal impSalgoAnt=0, decimal impPagado=0, 
            decimal impSaldoInoluto=-1 )
        {
            if (this.Pago != null && this.Pago.Length>0)
            {
                if (this.Pago.Last().DoctoRelacionado != null)
                {
                    var doctoRela = this.Pago.Last().DoctoRelacionado.ToList();
                    doctoRela.Add(new PagosPagoDoctoRelacionado()
                    {
                        Folio = folio,
                        IdDocumento = idDocumento,
                        MetodoDePagoDR = metodoDePagoDr,
                        MonedaDR = monedaDr,
                        NumParcialidad = numParcialidad,
                        Serie = serie,
                        ImpPagado = impPagado,
                        ImpSaldoAnt = impSalgoAnt,
                        ImpSaldoInsoluto = impSaldoInoluto
                    });
                    if (tipoCambioDR != -1)
                    {
                        doctoRela.Last().TipoCambioDR = tipoCambioDR;
                        doctoRela.Last().TipoCambioDRSpecified = true;
                    }
                    this.Pago.Last().DoctoRelacionado = doctoRela.ToArray();
                }
                else
                {
                    this.Pago.Last().DoctoRelacionado = new PagosPagoDoctoRelacionado[1];
                    this.Pago.Last().DoctoRelacionado[0] = new PagosPagoDoctoRelacionado()
                    {
                        Folio = folio,
                        IdDocumento = idDocumento,
                        MetodoDePagoDR = metodoDePagoDr,
                        MonedaDR = monedaDr,
                        NumParcialidad = numParcialidad,
                        Serie = serie,
                        ImpPagado = impPagado,
                        ImpSaldoAnt = impSalgoAnt,
                        ImpSaldoInsoluto = impSaldoInoluto
                    };
                    if (tipoCambioDR != -1)
                    {
                        this.Pago.Last().DoctoRelacionado[0].TipoCambioDR = tipoCambioDR;
                        this.Pago.Last().DoctoRelacionado[0].TipoCambioDRSpecified = true;
                    }
                }
            }
            if (impSaldoInoluto == -1)
                this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto = impSalgoAnt - impPagado;

            Math.Round(this.Pago.Last().DoctoRelacionado.Last().ImpPagado, this.Pago.Last().DoctoRelacionado.Last().Moneda_Info.Decimales);
            Math.Round(this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAnt, this.Pago.Last().DoctoRelacionado.Last().Moneda_Info.Decimales);
            Math.Round(this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto, this.Pago.Last().DoctoRelacionado.Last().Moneda_Info.Decimales);

            this.Pago.Last().DoctoRelacionado.Last().TipoCambioDRSpecified = this.Pago.Last().DoctoRelacionado.Last().TipoCambioDR <= 0 ? false : true;
            this.Pago.Last().DoctoRelacionado.Last().ImpPagadoSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpPagado <= 0 ? false : true;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAntSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAnt <= 0 ? false : true;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsolutoSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto < 0 ? false : true;
        }

        public void SetImpuestoRetenciones(decimal importe, string impuesto, bool isNewImpuestoNode=false)
        {
            if (this.Pago == null)
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago();
            }

            if (this.Pago.Last().Impuestos == null)
            {
                this.Pago.Last().Impuestos = new PagosPagoImpuestos[1];
                this.Pago.Last().Impuestos[0] = new PagosPagoImpuestos();
            }
            else
            {
                if (isNewImpuestoNode)
                {
                    var listImpuestosPago = this.Pago.Last().Impuestos.ToList();
                    listImpuestosPago.Add(new PagosPagoImpuestos());
                    this.Pago.Last().Impuestos = listImpuestosPago.ToArray();
                }
            }
            if (this.Pago.Last().Impuestos.Last().Retenciones == null)
            {
                this.Pago.Last().Impuestos.Last().Retenciones = new PagosPagoImpuestosRetencion[1];
                this.Pago.Last().Impuestos.Last().Retenciones[0] = new PagosPagoImpuestosRetencion()
                { Importe = importe, Impuesto = impuesto };
            }

            this.Pago.Last().Impuestos.Last().TotalImpuestosRetenidos += importe;
            this.Pago.Last().Impuestos.Last().TotalImpuestosRetenidosSpecified = true;
        }

        public void SetImpuestoTraslados(decimal importe, string impuesto, string tasaOCuota, 
            string tipoFactor, bool isNewImpuestoNode = false)
        {
            if (this.Pago == null)
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago();
            }
            if (this.Pago.Last().Impuestos == null)
            {
                this.Pago.Last().Impuestos = new PagosPagoImpuestos[1];
                this.Pago.Last().Impuestos[0] = new PagosPagoImpuestos();
            }
            else
            {
                if (isNewImpuestoNode)
                {
                    var listImpuestosPago = this.Pago.Last().Impuestos.ToList();
                    listImpuestosPago.Add(new PagosPagoImpuestos());
                    this.Pago.Last().Impuestos = listImpuestosPago.ToArray();
                }
            }
            if (this.Pago.Last().Impuestos.Last().Traslados == null)
            {
                this.Pago.Last().Impuestos.Last().Traslados = new PagosPagoImpuestosTraslado[1];
                this.Pago.Last().Impuestos.Last().Traslados[0] = new PagosPagoImpuestosTraslado()
                {Importe = importe, Impuesto = impuesto, TasaOCuota = tasaOCuota, TipoFactor = tipoFactor};
            }
            this.Pago.Last().Impuestos.Last().TotalImpuestosTrasladados += importe;
            this.Pago.Last().Impuestos.Last().TotalImpuestosTrasladadosSpecified = true;
        }

        private Comprobante invoice;
        public Pagos()
        {
            this.versionField = "1.0";
            this.invoice = new Comprobante();
        }

        public void SetEmisor(string rfc, string nombre, string regimenFiscal)
        {
            if (this.invoice.Emisor == null)
                this.invoice.Emisor = new ComprobanteEmisor();
            this.invoice.Emisor.Nombre = nombre;
            this.invoice.Emisor.RegimenFiscal = regimenFiscal;
            this.invoice.Emisor.Rfc = rfc;
        }

        public void SetReceptor(string rfc, string nombre, string residenciaFiscal = null, string numRegIdTrib = null)
        {
            if (this.invoice.Receptor == null)
                this.invoice.Receptor = new ComprobanteReceptor();

            this.invoice.Receptor.Rfc = rfc;
            this.invoice.Receptor.Nombre = nombre;
            this.invoice.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.invoice.Receptor.ResidenciaFiscalSpecified = true;
            this.invoice.Receptor.NumRegIdTrib = numRegIdTrib;
            this.invoice.Receptor.UsoCFDI = "P01";
        }

        public Comprobante GetInvoice(string lugarExpedicion, string serie=null, string folio=null)
        {
            invoice.TipoDeComprobante = "P";
            invoice.SubTotal = 0;
            invoice.Moneda = "XXX";
            invoice.Total = 0;
            invoice.Serie = serie;
            invoice.Folio = folio;
            invoice.LugarExpedicion = lugarExpedicion;
            invoice.Fecha = DateTime.Now.CentralTime();
            invoice.Conceptos = new ComprobanteConcepto[1];
            invoice.Conceptos[0]= new ComprobanteConcepto()
            { ClaveProdServ = "84111506", Cantidad = 1, ClaveUnidad = "ACT", Descripcion = "Pago", ValorUnitario = 0, Importe = 0 };
            var xmlPagos = Serializer.SerializeDocument(this);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlPagos);
            invoice.SetComplemento(doc.DocumentElement);
            return invoice;
        }
    }
}
