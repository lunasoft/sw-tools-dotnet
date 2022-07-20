using System;
using System.Linq;
using SW.Tools.Helpers;
using System.Xml;
using System.Xml.Serialization;
using SW.Tools.Cfdi.Complementos.Pagos20;
using SW.Tools.Entities;

namespace SW.Tools.Cfdi.Complementos.Pagos20
{
    public partial class Pagos
    {

        public void SetPago(string formaDePagoP, string ctaBeneficiario, DateTime fechaPago, string ctaOrdenante,
            string monedaP, decimal monto, string numBancoOrdenante, string numOperacion, string rfcEmisorCtaBenef,
            string rfcEmisorCtaOrd, decimal? tipoCambioP = null )
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
                    TipoCadPagoSpecified = tipoCambioP.HasValue,
                    TipoCambioP = Convert.ToDecimal(tipoCambioP)



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
                    TipoCadPagoSpecified = tipoCambioP.HasValue,
                    TipoCambioP = Convert.ToDecimal(tipoCambioP)

                };
            }
            if (this.Pago.Last().TipoCambioP > 0)
            {
                this.Pago.Last().TipoCambioPSpecified = this.Pago.Last().TipoCambioP != 0;
                this.Pago.Last().TipoCambioP = Convert.ToDecimal(tipoCambioP);
            }
            
        }

        public void SetTipoCadPago(string tipoCatPago, string selloPago, string cerPago, string cadPago)
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
        public void SetTotales(string montototalpagos , string totalretencionesiva = null , string totalretencionesisr = null, string totalretencionesieps = null,
            string totaltrasladosbaseiva16 = null , string totaltrasladosimpuestoiva16 = null, string totaltrasladosbaseiva8 = null, string totaltrasladosimpuestoiva8 = null,
            string totaltrasladosbaseiva0 = null, string totaltrasladosimpuestoiva0 = null, string totaltrasladosbaseivaexento = null)
        {
            if (Totales == null)
                Totales = new PagosTotales();
            Totales.MontoTotalPagos = Convert.ToDecimal(montototalpagos);
            Totales.TotalRetencionesIVASpecified = !string.IsNullOrEmpty(totalretencionesiva);
            Totales.TotalRetencionesIVA = Convert.ToDecimal(totalretencionesiva);
            Totales.TotalRetencionesISRSpecified = !string.IsNullOrEmpty(totalretencionesisr); 
            Totales.TotalRetencionesISR = Convert.ToDecimal(totalretencionesisr);
            Totales.TotalRetencionesIEPSSpecified = !string.IsNullOrEmpty(totalretencionesieps); 
            Totales.TotalRetencionesIEPS = Convert.ToDecimal(totalretencionesieps);
            Totales.TotalTrasladosBaseIVA16Specified = !string.IsNullOrEmpty(totaltrasladosbaseiva16);
            Totales.TotalTrasladosBaseIVA16 = Convert.ToDecimal(totaltrasladosbaseiva16);
            Totales.TotalTrasladosImpuestoIVA16Specified = !string.IsNullOrEmpty(totaltrasladosimpuestoiva16);
            Totales.TotalTrasladosImpuestoIVA16 = Convert.ToDecimal(totaltrasladosimpuestoiva16);
            Totales.TotalTrasladosBaseIVA8Specified = !string.IsNullOrEmpty(totaltrasladosbaseiva8);
            Totales.TotalTrasladosBaseIVA8 = Convert.ToDecimal(totaltrasladosbaseiva8);
            Totales.TotalTrasladosImpuestoIVA8Specified = !string.IsNullOrEmpty(totaltrasladosimpuestoiva8);
            Totales.TotalTrasladosImpuestoIVA8 = Convert.ToDecimal(totaltrasladosimpuestoiva8);
            Totales.TotalTrasladosBaseIVA0Specified = !string.IsNullOrEmpty(totaltrasladosbaseiva0);
            Totales.TotalTrasladosBaseIVA0 = Convert.ToDecimal(totaltrasladosbaseiva0);
            Totales.TotalTrasladosImpuestoIVA0Specified = !string.IsNullOrEmpty(totaltrasladosimpuestoiva0);
            Totales.TotalTrasladosImpuestoIVA0 = Convert.ToDecimal(totaltrasladosimpuestoiva0);
            Totales.TotalTrasladosBaseIVAExentoSpecified = !string.IsNullOrEmpty(totaltrasladosbaseivaexento);
            Totales.TotalTrasladosBaseIVAExento = Convert.ToDecimal(totaltrasladosbaseivaexento);
        }

        public void SetDoctoRelacionado(string serie, string folio, string idDocumento,
            string monedaDr, string numParcialidad, string objetoimp, decimal equivalenciaDR = -1, decimal impSalgoAnt = 0, decimal impPagado = 0,
            decimal impSaldoInoluto = -1)
        {
            if (this.Pago != null && this.Pago.Length > 0)
            {
                if (this.Pago.Last().DoctoRelacionado != null)
                {
                    var doctoRela = this.Pago.Last().DoctoRelacionado.ToList();
                    doctoRela.Add(new PagosPagoDoctoRelacionado()
                    {
                        Folio = folio,
                        IdDocumento = idDocumento,
                        ObjetoImpDR = objetoimp,
                        MonedaDR = monedaDr,
                        NumParcialidad = numParcialidad,
                        Serie = serie,
                        ImpPagado = impPagado,
                        ImpSaldoAnt = impSalgoAnt,
                        ImpSaldoInsoluto = impSaldoInoluto
                    });
                    if (equivalenciaDR != -1)
                    {
                        doctoRela.Last().EquivalenciaDR = equivalenciaDR;
                        doctoRela.Last().EquivalenciaDRSpecified = true;
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
                        ObjetoImpDR = objetoimp,
                        MonedaDR = monedaDr,
                        NumParcialidad = numParcialidad,
                        Serie = serie,
                        ImpPagado = impPagado,
                        ImpSaldoAnt = impSalgoAnt,
                        ImpSaldoInsoluto = impSaldoInoluto
                    };
                    if (equivalenciaDR != -1)
                    {
                        this.Pago.Last().DoctoRelacionado[0].EquivalenciaDR = equivalenciaDR;
                        this.Pago.Last().DoctoRelacionado[0].EquivalenciaDRSpecified = true;
                    }
                }
            }
            if (impSaldoInoluto == -1)
                this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto = impSalgoAnt - impPagado;

            this.Pago.Last().DoctoRelacionado.Last().ImpPagado = this.Pago.Last().DoctoRelacionado.Last().ImpPagado;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAnt =this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAnt;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto = this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto;
            this.Pago.Last().DoctoRelacionado.Last().EquivalenciaDR = equivalenciaDR;
            this.Pago.Last().DoctoRelacionado.Last().ObjetoImpDR = this.Pago.Last().DoctoRelacionado.Last().ObjetoImpDR;
            this.Pago.Last().DoctoRelacionado.Last().EquivalenciaDRSpecified = this.Pago.Last().DoctoRelacionado.Last().EquivalenciaDR > 0;
            this.Pago.Last().DoctoRelacionado.Last().ImpPagadoSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpPagado > 0;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAntSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpSaldoAnt > 0;
            this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsolutoSpecified = this.Pago.Last().DoctoRelacionado.Last().ImpSaldoInsoluto >= 0;
            
        }
        

        public void SetImpuestoTrasladoDR( string tipoFactorDr, string impuestoDr, decimal _baseDr, decimal? tasaOCuotaDr = null, decimal? importeDr = null )
        {

            
            int positionConcept = this.Pago.Last().DoctoRelacionado.Length - 1;
            if (this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR == null)
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR = new PagosPagoDoctoRelacionadoImpuestosDR();
            PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR impuestoObj;
            if (tipoFactorDr.Trim().ToLower() == "exento")
            {
                impuestoObj = new PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR()
                { BaseDR = _baseDr, ImporteDRSpecified = false,  ImpuestoDR = impuestoDr, TasaOCuotaDRSpecified= false, TipoFactorDR = tipoFactorDr };
            }
            else
                impuestoObj = new PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR()
                { BaseDR = _baseDr, ImporteDR = importeDr.Value, ImporteDRSpecified = true, ImpuestoDR = impuestoDr, TasaOCuotaDR = tasaOCuotaDr.Value, TasaOCuotaDRSpecified = true, TipoFactorDR = tipoFactorDr };
            if (this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.TrasladosDR != null)
            {
                var listCT = this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.TrasladosDR.ToList();
                listCT.Add(impuestoObj);
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.TrasladosDR = listCT.ToArray();
            }
            else
            {
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.TrasladosDR = new PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR[1];
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.TrasladosDR[0] = impuestoObj;
            }
            

        }

        public void SetImpuestoRetencionDR( string tipoFactorDr, string impuestoDr, decimal _baseDr, decimal? tasaOCuotaDr = null, decimal? importeDr = null)
        {


            int positionConcept = this.Pago.Last().DoctoRelacionado.Length - 1;
            if (this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR == null)
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR = new PagosPagoDoctoRelacionadoImpuestosDR();
            PagosPagoDoctoRelacionadoImpuestosDRRetencionDR impuestoObj;
            if (tipoFactorDr.Trim().ToLower() == "exento")
            {
                impuestoObj = new PagosPagoDoctoRelacionadoImpuestosDRRetencionDR()
                { BaseDR = _baseDr, ImporteDR = importeDr.Value, ImpuestoDR = impuestoDr, TasaOCuotaDR = tasaOCuotaDr.Value, TipoFactorDR = tipoFactorDr };
            }
            else
                impuestoObj = new PagosPagoDoctoRelacionadoImpuestosDRRetencionDR()
                { BaseDR = _baseDr, ImporteDR = importeDr.Value, ImporteDRSpecified = true, ImpuestoDR = impuestoDr, TasaOCuotaDR = tasaOCuotaDr.Value, TasaOCuotaDRSpecified = true, TipoFactorDR = tipoFactorDr };
            if (this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.RetencionesDR != null)
            {
                var listCT = this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.RetencionesDR.ToList();
                listCT.Add(impuestoObj);
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.RetencionesDR = listCT.ToArray();
            }
            else
            {
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.RetencionesDR = new PagosPagoDoctoRelacionadoImpuestosDRRetencionDR[1];
                this.Pago.Last().DoctoRelacionado[positionConcept].ImpuestosDR.RetencionesDR[0] = impuestoObj;
            }


        }



        public void SetImpuestoRetenciones(decimal importe, string impuesto )
        {
            if (this.Pago == null)
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago();
            }
            if (this.Pago.Last().ImpuestosP == null)
            {
                this.Pago.Last().ImpuestosP = new PagosPagoImpuestosP[1];
                this.Pago.Last().ImpuestosP[0] = new PagosPagoImpuestosP();

            }

            if (this.Pago.Last().ImpuestosP.Last().RetencionesP == null)
            {
                this.Pago.Last().ImpuestosP.Last().RetencionesP = new PagosPagoImpuestosPRetencionP[1];
                this.Pago.Last().ImpuestosP.Last().RetencionesP[0] = new PagosPagoImpuestosPRetencionP()
                {   ImporteP = importe, ImpuestoP = impuesto};
            }
            else
            {
                var listImpTras = this.Pago.Last().ImpuestosP.Last().RetencionesP.ToList();
                listImpTras.Add(new PagosPagoImpuestosPRetencionP()
                {  ImporteP = importe, ImpuestoP = impuesto});
                this.Pago.Last().ImpuestosP.Last().RetencionesP = listImpTras.ToArray();
            }
        }

        public void SetImpuestoTraslados(string tipoFactor,  string impuesto, decimal _base, decimal? tasaOCuota = null, decimal? importe = null)
        {


            if (this.Pago == null)
            {
                this.Pago = new PagosPago[1];
                this.Pago[0] = new PagosPago();
            }
            if (this.Pago.Last().ImpuestosP == null)
            {
                this.Pago.Last().ImpuestosP = new PagosPagoImpuestosP[1];
                this.Pago.Last().ImpuestosP[0] = new PagosPagoImpuestosP();

            }

            if (this.Pago.Last().ImpuestosP.Last().TrasladosP == null)
            {
                if (tipoFactor.Trim().ToLower() == "exento")
                {
                    this.Pago.Last().ImpuestosP.Last().TrasladosP = new PagosPagoImpuestosPTrasladoP[1];
                    this.Pago.Last().ImpuestosP.Last().TrasladosP[0] = new PagosPagoImpuestosPTrasladoP()
                    { BaseP = _base,  ImpuestoP = impuesto,  TipoFactorP = tipoFactor };
                }
                else
                {
                    this.Pago.Last().ImpuestosP.Last().TrasladosP = new PagosPagoImpuestosPTrasladoP[1];
                    this.Pago.Last().ImpuestosP.Last().TrasladosP[0] = new PagosPagoImpuestosPTrasladoP()
                    { BaseP = _base, ImportePSpecified = true, ImporteP = importe.Value, ImpuestoP = impuesto, TasaOCuotaPSpecified = true, TasaOCuotaP = tasaOCuota.Value, TipoFactorP = tipoFactor };
                }
            }
            else
            {
                var listImpTras = this.Pago.Last().ImpuestosP.Last().TrasladosP.ToList();
                listImpTras.Add(new PagosPagoImpuestosPTrasladoP()
                { BaseP = _base, ImportePSpecified = true, ImporteP = importe.Value, ImpuestoP = impuesto, TasaOCuotaPSpecified = true, TasaOCuotaP = tasaOCuota.Value, TipoFactorP = tipoFactor });
                this.Pago.Last().ImpuestosP.Last().TrasladosP = listImpTras.ToArray();
            }

        }

        private Comprobante invoice;
     
        public Pagos()
        {
            
            this.versionField = "2.0";
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

        public void SetReceptor(string rfc, string nombre, string domicilioFiscalReceptor, string regimenFiscalReceptor, string residenciaFiscal = null, string numRegIdTrib = null)
        {
            if (this.invoice.Receptor == null)
                this.invoice.Receptor = new ComprobanteReceptor();

            this.invoice.Receptor.Rfc = rfc;
            this.invoice.Receptor.Nombre = nombre;
            this.invoice.Receptor.DomicilioFiscalReceptor = domicilioFiscalReceptor;
            this.invoice.Receptor.RegimenFiscalReceptor = regimenFiscalReceptor;
            this.invoice.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.invoice.Receptor.ResidenciaFiscalSpecified = true;
            this.invoice.Receptor.NumRegIdTrib = numRegIdTrib;
            this.invoice.Receptor.UsoCFDI = "CP01";
        }
    

        public Comprobante GetInvoice(string lugarExpedicion, string exportacion, string objetoimp, string serie = null, string folio = null, string tipoRelacion = null, string[] uuid = null)
        {
            
            invoice.TipoDeComprobante = "P";
            invoice.SubTotal = 0;
            invoice.Moneda = "XXX";
            invoice.Total = 0;
            invoice.Serie = serie;
            invoice.Folio = folio;
            invoice.Exportacion =exportacion;
            invoice.LugarExpedicion = lugarExpedicion;
            invoice.Fecha = DateTime.Now.CentralTime();
            if(!string.IsNullOrEmpty(tipoRelacion) && !string.IsNullOrEmpty(uuid[0]))
            {
                invoice.SetCFDIRelacionado(tipoRelacion, uuid);
            }
            invoice.Conceptos = new ComprobanteConcepto[1];
            invoice.Conceptos[0] = new ComprobanteConcepto()
            { ClaveProdServ = "84111506", Cantidad = 1, ClaveUnidad = "ACT", Descripcion = "Pago", ValorUnitario = 0, Importe = 0, ObjetoImp = objetoimp };
            var xmlPagos = SerializerP.SerializeDocument(this);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlPagos);
            invoice.SetComplemento(doc.DocumentElement);
            return invoice;
        }
    }
}
