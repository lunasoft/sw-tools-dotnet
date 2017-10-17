using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SW.Tools.Catalogs;
namespace SW.Tools.Entities
{
    public partial class Comprobante
    {
        public void SetConcepto(decimal cantidad, c_ClaveProdServ claveProdServ, c_ClaveUnidad claveUnidad, string descripcion,
             string noIdentificacion, string unidad, decimal valorUnitario, decimal descuento = 0 )
        {
            decimal importe = valorUnitario * cantidad;
            this.conceptsList.Add(new ComprobanteConcepto()
            {
                Cantidad = cantidad,
                ClaveProdServ = claveProdServ.GetString(),
                ClaveUnidad = claveUnidad.GetString(),
                Descripcion = descripcion,
                Descuento = descuento,
                DescuentoSpecified = descuento != 0,
                Importe = importe,
                NoIdentificacion = noIdentificacion,
                Unidad = unidad,
                ValorUnitario = valorUnitario
            });
        }

        public void SetConceptoImpuestoTraslado(decimal tasaOCuota, c_TipoFactor tipoFactor, string impuesto, decimal _base)
        {
            if (_base <= 0)
                throw new ToolsException("CFDI33154", Errors.CFDI33154);
            decimal importe = _base * tasaOCuota;
            if(!string.IsNullOrEmpty(this.Moneda))
                importe = importe.TruncateDecimals(this.Moneda_Info.Decimales);
            int positionConcept = this.conceptsList.Count-1;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            if (this.Conceptos[positionConcept].Impuestos.trasladosList == null)
                this.Conceptos[positionConcept].Impuestos.trasladosList = new List<ComprobanteConceptoImpuestosTraslado>();
            this.Conceptos[positionConcept].Impuestos.trasladosList.Add(new ComprobanteConceptoImpuestosTraslado()
            { Base=_base, Importe= importe, ImporteSpecified= true, Impuesto= impuesto, TasaOCuota= tasaOCuota, TasaOCuotaSpecified= true, TipoFactor= tipoFactor.GetString() });
            this.SetImpuestoTraslado(importe, impuesto, tasaOCuota, tipoFactor);
        }

        public void SetConceptoImpuestoRetencion(decimal tasaOCuota, string impuesto, decimal _base)
        {
            if (_base <= 0)
                throw new ToolsException("CFDI33163", Errors.CFDI33163);
            decimal importe = _base * tasaOCuota;
            if (!string.IsNullOrEmpty(this.Moneda))
                importe = importe.TruncateDecimals(this.Moneda_Info.Decimales);
            int positionConcept = this.conceptsList.Count-1;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            if (this.Conceptos[positionConcept].Impuestos.retencionesList == null)
                this.Conceptos[positionConcept].Impuestos.retencionesList = new List<ComprobanteConceptoImpuestosRetencion>();
            this.Conceptos[positionConcept].Impuestos.retencionesList.Add(new ComprobanteConceptoImpuestosRetencion()
            { Base= _base, Importe= importe, Impuesto= impuesto});
            this.SetImpuestoRetencion(importe, impuesto);
        }

        public void SetCFDIRelacionado(c_TipoRelacion tipoRelacion, string uuid)
        {
            if (this.CfdiRelacionados == null)
            {
                this.CfdiRelacionados = new ComprobanteCfdiRelacionados();
                this.CfdiRelacionados.TipoRelacion = tipoRelacion.GetString();
                this.CfdiRelacionados.cfdiRelacionadoList = new List<ComprobanteCfdiRelacionadosCfdiRelacionado>();
            }
            this.CfdiRelacionados.cfdiRelacionadoList.Add(new ComprobanteCfdiRelacionadosCfdiRelacionado() { UUID = uuid });
        }

        public void SetComplemento(XmlElement xmlComplemento)
        {
            if (this.complementoList == null)
            {
                this.complementoList = new ComprobanteComplemento[1];
                this.complementoList[0] = new ComprobanteComplemento();
            }
                
            if (this.complementoList[0].antFieldList == null)
                this.complementoList[0].antFieldList = new List<XmlElement>();
            this.complementoList[0].antFieldList.Add(xmlComplemento);
        }

        public void SetAddenda(XmlElement xmlAddenda)
        {
            if(this.addendaField==null)
                this.Addenda = new ComprobanteAddenda();
            this.addendaField.anyFieldList.Add(xmlAddenda);
        }

        private void SetImpuestoTraslado(decimal importe, string impuesto, decimal tasaOCuota, c_TipoFactor tipoFactor)
        {
            if (this.Impuestos == null)
                this.Impuestos = new ComprobanteImpuestos();
            if (this.Impuestos.trasladoList == null)
                this.Impuestos.trasladoList = new List<ComprobanteImpuestosTraslado>();

            if (this.Impuestos.trasladoList.Any(a => a.Impuesto == impuesto && a.TasaOCuota == tasaOCuota))
            {
                this.Impuestos.trasladoList.Where(a => a.Impuesto == impuesto && a.TasaOCuota == tasaOCuota)
                    .ToList().ForEach(i => i.Importe = i.Importe + importe);
            }
            else
                this.Impuestos.trasladoList.Add(new ComprobanteImpuestosTraslado()
                { Importe = importe, Impuesto = impuesto, TasaOCuota = tasaOCuota, TipoFactor = tipoFactor.GetString() });
        }

        private void SetImpuestoRetencion(decimal importe, string impuesto)
        {
            if (this.Impuestos == null)
                this.Impuestos = new ComprobanteImpuestos();
            if (this.Impuestos.retencionesList == null)
                this.Impuestos.retencionesList = new List<ComprobanteImpuestosRetencion>();
            if(this.Impuestos.trasladoList.Any(a=>a.Impuesto==impuesto))
                this.Impuestos.retencionesList.Where(a => a.Impuesto == impuesto).ToList().ForEach(i=>i.Importe = i.Importe+ importe);
            else
                this.Impuestos.retencionesList.Add(new ComprobanteImpuestosRetencion()
                { Importe = importe, Impuesto = impuesto });
        }

        public void SetEmisor(string rfc, string nombre, c_RegimenFiscal regimenFiscal)
        {
            this.Emisor.Nombre = nombre;
            this.Emisor.RegimenFiscal = regimenFiscal.GetString();
            this.Emisor.Rfc = rfc;
        }

        public void SetReceptor(string rfc, string nombre, c_UsoCFDI usoCFDI, string residenciaFiscal=null, string numRegIdTrib=null)
        {
            this.Receptor.Rfc = rfc;
            this.Receptor.Nombre = nombre;
            this.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.Receptor.ResidenciaFiscalSpecified = true;
            this.Receptor.NumRegIdTrib = numRegIdTrib;
            this.Receptor.UsoCFDI = usoCFDI.GetString();
        }

        public void SetComprobante(c_Moneda moneda,  c_TipoDeComprobante tipoDeComprobante, c_FormaPago formaPago, c_MetodoPago metodoPago,
            string lugarExpedicion, string serie=null, string folio=null, string condicionesDePago=null, decimal tipoCambio = 1, string confirmacion = null)
        {
            this.Serie = serie;
            this.Folio = folio;
            this.FormaPago = formaPago.GetString();
            this.CondicionesDePago = condicionesDePago;
            this.Moneda = moneda.ToString();
            this.TipoCambio = tipoCambio;
            this.TipoDeComprobante = tipoDeComprobante.GetString();
            this.MetodoPago = metodoPago.GetString();
            this.lugarExpedicionField = lugarExpedicion;
            this.Confirmacion = confirmacion;
        }

        public Comprobante GetComprobante()
        {
            if (this.TipoDeComprobante == "I" || this.TipoDeComprobante == "E" || this.TipoDeComprobante == "N")
            {
                this.SubTotal = this.Conceptos.Sum(a => a.Importe).TruncateDecimals(this.Moneda_Info.Decimales);
                if (this.Conceptos != null && this.Conceptos.Any(a => a.DescuentoSpecified))
                {
                    this.Descuento = this.Conceptos.Sum(a => a.Descuento).TruncateDecimals(this.Moneda_Info.Decimales);
                    this.DescuentoSpecified = true;
                }
            }
            else if (this.TipoDeComprobante == "T" || this.TipoDeComprobante == "P")
                this.SubTotal = 0;
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
            this.Fecha = DateTime.Now.CentralTime();
            if (this.Impuestos != null)
            {
                if (this.Impuestos.Traslados != null && this.Impuestos.Traslados.Count() > 0)
                {
                    this.Impuestos.TotalImpuestosTrasladados = this.Impuestos.Traslados.Sum(a => a.Importe).TruncateDecimals(this.moneda_Info.Decimales);
                    this.Impuestos.TotalImpuestosTrasladadosSpecified = true;
                    this.Total += this.Impuestos.TotalImpuestosTrasladados;
                }

                if (this.Impuestos.retencionesList != null && this.Impuestos.retencionesList.Count() > 0)
                {
                    this.Impuestos.TotalImpuestosRetenidos = this.Impuestos.Retenciones.Sum(a => a.Importe).TruncateDecimals(this.moneda_Info.Decimales);
                    this.Impuestos.TotalImpuestosRetenidosSpecified = true;
                    this.Total -= this.Impuestos.TotalImpuestosTrasladados;
                }
                
            }
            return this;
        }
    }
}
