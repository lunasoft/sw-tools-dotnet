using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SW.Tools.Entities
{
    public partial class Comprobante
    {
        public void SetConcepto(decimal cantidad, string claveProdServ, string claveUnidad, string descripcion,
            decimal descuento, string noIdentificacion, string unidad, decimal valorUnitario)
        {
            decimal importe = valorUnitario * cantidad;
            this.conceptsList.Add(new ComprobanteConcepto()
            {
                Cantidad = cantidad,
                ClaveProdServ = claveProdServ,
                ClaveUnidad = claveUnidad,
                Descripcion = descripcion,
                Descuento = descuento,
                DescuentoSpecified = descuento != 0,
                Importe = importe,
                NoIdentificacion = noIdentificacion,
                Unidad = unidad,
                ValorUnitario = valorUnitario
            });
        }

        public void SetConceptoImpuestoTraslado(decimal tasaOCuota, string tipoFactor, string impuesto, decimal _base)
        {
            if (_base <= 0)
                throw new ToolsException("CFDI33154", Errors.CFDI33154);
            decimal importe = _base * tasaOCuota;
            int positionConcept = this.conceptsList.Count;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            if (this.Conceptos[positionConcept].Impuestos.trasladosList == null)
                this.Conceptos[positionConcept].Impuestos.trasladosList = new List<ComprobanteConceptoImpuestosTraslado>();
            this.Conceptos[positionConcept].Impuestos.trasladosList.Add(new ComprobanteConceptoImpuestosTraslado()
            { Base=_base, Importe= importe, ImporteSpecified= true, Impuesto= impuesto, TasaOCuota= tasaOCuota, TasaOCuotaSpecified= true, TipoFactor= tipoFactor });
            this.SetImpuestoTraslado(importe, impuesto, tasaOCuota, tipoFactor);
        }

        public void SetConceptoImpuestoRetencion(decimal tasaOCuota, string tipoFactor, string impuesto, decimal _base)
        {
            if (_base <= 0)
                throw new ToolsException("CFDI33163", Errors.CFDI33163);
            decimal importe = _base * tasaOCuota;
            int positionConcept = this.conceptsList.Count;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            if (this.Conceptos[positionConcept].Impuestos.retencionesList == null)
                this.Conceptos[positionConcept].Impuestos.retencionesList = new List<ComprobanteConceptoImpuestosRetencion>();
            this.Conceptos[positionConcept].Impuestos.retencionesList.Add(new ComprobanteConceptoImpuestosRetencion()
            { Base= _base, Importe= importe, Impuesto= impuesto});
            this.SetImpuestoRetencion(importe, impuesto);
        }

        public void SetCFDIRelacionado(string tipoRelacion, string uuid)
        {
            if (this.CfdiRelacionados == null)
            {
                this.CfdiRelacionados = new ComprobanteCfdiRelacionados();
                this.CfdiRelacionados.TipoRelacion = tipoRelacion;
                this.CfdiRelacionados.cfdiRelacionadoList = new List<ComprobanteCfdiRelacionadosCfdiRelacionado>();
            }
            this.CfdiRelacionados.cfdiRelacionadoList.Add(new ComprobanteCfdiRelacionadosCfdiRelacionado() { UUID = uuid });
        }

        public void SetComplemento(XmlElement xmlComplemento)
        {
            this.complementoList[0].antFieldList.Add(xmlComplemento);
        }

        public void SetAddenda(XmlElement xmlAddenda)
        {
            if(this.addendaField==null)
                this.Addenda = new ComprobanteAddenda();
            this.addendaField.anyFieldList.Add(xmlAddenda);
        }

        private void SetImpuestoTraslado(decimal importe, string impuesto, decimal tasaOCuota, string tipoFactor)
        {
            if (this.Impuestos == null)
                this.Impuestos = new ComprobanteImpuestos();
            if (this.Impuestos.trasladoList == null)
                this.Impuestos.trasladoList = new List<ComprobanteImpuestosTraslado>();
            this.Impuestos.trasladoList.Add(new ComprobanteImpuestosTraslado()
            { Importe = importe, Impuesto = impuesto, TasaOCuota = tasaOCuota, TipoFactor = tipoFactor });
        }
        private void SetImpuestoRetencion(decimal importe, string impuesto)
        {
            if (this.Impuestos == null)
                this.Impuestos = new ComprobanteImpuestos();
            if (this.Impuestos.retencionesList == null)
                this.Impuestos.retencionesList = new List<ComprobanteImpuestosRetencion>();
            this.Impuestos.retencionesList.Add(new ComprobanteImpuestosRetencion()
                { Importe = importe, Impuesto = impuesto });
        }

        public void SetEmisor(string rfc, string nombre, string regimenFiscal)
        {
            this.Emisor.Nombre = nombre;
            this.Emisor.RegimenFiscal = regimenFiscal;
            this.Emisor.Rfc = rfc;
        }

        public void SetReceptor(string rfc, string nombre, string residenciaFiscal, string numRegIdTrib, string usoCFDI)
        {
            this.Receptor.Rfc = rfc;
            this.Receptor.Nombre = nombre;
            this.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.Receptor.ResidenciaFiscalSpecified = true;
            this.Receptor.NumRegIdTrib = numRegIdTrib;
            this.Receptor.UsoCFDI = usoCFDI;
        }
        public void SetComprobante(string serie, string folio, string formaPago, string condicionesDePago, 
            string moneda, decimal tipoCambio, string tipoDeComprobante, string metodoPago, 
            string lugarExpedicion, string confirmacion = null)
        {
            this.Serie = serie;
            this.Folio = folio;
            this.FormaPago = formaPago;
            this.CondicionesDePago = condicionesDePago;
            this.Moneda = moneda;
            this.TipoCambio = tipoCambio;
            this.TipoDeComprobante = tipoDeComprobante;
            this.MetodoPago = metodoPago;
            this.lugarExpedicionField = lugarExpedicion;
            this.Confirmacion = confirmacion;
        }
        public Comprobante GetComprobante()
        {
            if (this.TipoDeComprobante == "I" || this.TipoDeComprobante == "E" || this.TipoDeComprobante == "N")
            {
                this.SubTotal = this.Conceptos.Sum(a => a.Importe).TruncateDecimals(this.Moneda_Info.Decimales);
                if (this.Conceptos != null && this.Conceptos.Any(a => a.DescuentoSpecified))
                    this.Descuento = this.Conceptos.Sum(a => a.Descuento).TruncateDecimals(this.Moneda_Info.Decimales);
            }
            else if (this.TipoDeComprobante == "T" || this.TipoDeComprobante == "P")
                this.SubTotal = 0;
            Validation.CurrencyRateNotExist(this);

            //Calcular total
            decimal totalCalculado = 0;
            totalCalculado = this.SubTotal - this.Descuento;
            if (this.Impuestos != null)
                totalCalculado = (totalCalculado + this.Impuestos.TotalImpuestosTrasladados) - this.Impuestos.TotalImpuestosRetenidos;
            if (this.HasImpLocales)
            {
                var implocalComplement = this.Complemento.FirstOrDefault(c => c.Any.Any(w => w.Name == "implocal:ImpuestosLocales"));
                var implocal = implocalComplement.Any.FirstOrDefault(w => w.Name == "implocal:ImpuestosLocales");

                if (implocal.HasAttribute("TotaldeTraslados"))
                    totalCalculado = totalCalculado + decimal.Parse(implocal.GetAttribute("Totaldetraslados"));
                if (implocal.HasAttribute("TotaldeRetenciones"))
                    totalCalculado = totalCalculado - decimal.Parse(implocal.GetAttribute("TotaldeRetenciones"));
            }
            this.Total = totalCalculado;
            this.Fecha = DateTime.Now;
            if (this.Impuestos != null)
            {
                if (this.Impuestos.Retenciones != null && this.Impuestos.Retenciones.Count() > 0)
                {
                    this.Impuestos.TotalImpuestosRetenidos = this.Impuestos.Retenciones.Sum(a => a.Importe);
                    this.Impuestos.TotalImpuestosRetenidosSpecified = true;
                }
                if (this.Impuestos.Traslados != null && this.Impuestos.Retenciones.Count() > 0)
                {
                    this.Impuestos.TotalImpuestosTrasladados = this.Impuestos.Traslados.Sum(a => a.Importe);
                    this.Impuestos.TotalImpuestosTrasladadosSpecified = true;
                }
            }
                
            


                

            return this;
        }


    }
}
