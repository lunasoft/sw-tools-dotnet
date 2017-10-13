using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Tools.Entities;
using System.Xml;
using SW.Tools.Helpers;

namespace SW.Tools.Issue
{
    public class CFDI33 : InvoiceData
    {
        private Comprobante invoice = new Comprobante();
        public CFDI33()
        {
            invoice.Version = "3.3";
        }

        public override void SetConcept(decimal cantidad, string claveProdServ, string claveUnidad, string descripcion,
            decimal descuento, decimal importe, string noIdentificacion, string unidad, decimal valorUnitario)
        {
            if (invoice.Conceptos == null)
            {
                invoice.Conceptos = new ComprobanteConcepto[1];
            }

            invoice.Conceptos.ToList().Add(new ComprobanteConcepto()
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

        public override void SetCFDIRelacionado(string tipoRelacion, string uuid)
        {
            if (invoice.CfdiRelacionados == null)
            {
                invoice.CfdiRelacionados = new ComprobanteCfdiRelacionados();
                invoice.CfdiRelacionados.TipoRelacion = tipoRelacion;
                invoice.CfdiRelacionados.CfdiRelacionado = new ComprobanteCfdiRelacionadosCfdiRelacionado[1];
            }
            invoice.CfdiRelacionados.CfdiRelacionado.ToList().Add(new ComprobanteCfdiRelacionadosCfdiRelacionado() { UUID = uuid });
        }

        public override void SetAddenda(string xmlAddenda)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlAddenda);
            if (invoice.Addenda == null)
            {
                invoice.Addenda = new ComprobanteAddenda();
                invoice.Addenda.Any = new XmlElement[1];
            }
            invoice.Addenda.Any.ToList().Add(doc.DocumentElement);
        }

        public override void SetComplemento(string xmlComplemento)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlComplemento);
            invoice.Complemento.ToList();
            if (invoice.Complemento == null)
            {
                invoice.Complemento = new ComprobanteComplemento[1];
                invoice.Complemento[0].Any = new XmlElement[1];
                invoice.Complemento[0].Any[0] = doc.DocumentElement;
            }
            else
                invoice.Complemento[0].Any.ToList().Add(doc.DocumentElement);
        }

        public override void SetImpuestoTraslado(decimal importe, string impuesto, decimal tasaOCuota, string tipoFactor)
        {
            if (invoice.Impuestos == null)
                invoice.Impuestos = new ComprobanteImpuestos();
            if (invoice.Impuestos.Traslados == null)
                invoice.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
            invoice.Impuestos.Traslados.ToList().Add(new ComprobanteImpuestosTraslado()
            { Importe = importe, Impuesto = impuesto, TasaOCuota = tasaOCuota, TipoFactor = tipoFactor });
        }

        public override void SetImpuestoRetencion(decimal importe, string impuesto)
        {
            if (invoice.Impuestos == null)
                invoice.Impuestos = new ComprobanteImpuestos();
            if (invoice.Impuestos.Retenciones == null)
                invoice.Impuestos.Retenciones = new ComprobanteImpuestosRetencion[1];
            invoice.Impuestos.Retenciones.ToList().Add(new ComprobanteImpuestosRetencion()
            { Importe = importe, Impuesto = impuesto });
        }

        public override Comprobante GetInvoice()
        {
            if (invoice.TipoDeComprobante == "I" || invoice.TipoDeComprobante == "E" || invoice.TipoDeComprobante == "N")
            {
                invoice.SubTotal = invoice.Conceptos.Sum(a => a.Importe).TruncateDecimals(invoice.Moneda_Info.Decimales);
                if (invoice.Conceptos != null && invoice.Conceptos.Any(a => a.DescuentoSpecified))
                    invoice.Descuento = invoice.Conceptos.Sum(a => a.Descuento).TruncateDecimals(invoice.Moneda_Info.Decimales);
            }
            else if (invoice.TipoDeComprobante == "T" || invoice.TipoDeComprobante == "P")
                invoice.SubTotal = 0;
            Validation.CurrencyRateNotExist(invoice);

            //Calcular total
            decimal totalCalculado = 0;
            totalCalculado = invoice.SubTotal - invoice.Descuento;
            if (invoice.Impuestos != null)
                totalCalculado = (totalCalculado + invoice.Impuestos.TotalImpuestosTrasladados) - invoice.Impuestos.TotalImpuestosRetenidos;
            if (invoice.HasImpLocales)
            {
                var implocalComplement = invoice.Complemento.FirstOrDefault(c => c.Any.Any(w => w.Name == "implocal:ImpuestosLocales"));
                var implocal = implocalComplement.Any.FirstOrDefault(w => w.Name == "implocal:ImpuestosLocales");

                if (implocal.HasAttribute("TotaldeTraslados"))
                    totalCalculado = totalCalculado + decimal.Parse(implocal.GetAttribute("Totaldetraslados"));
                if (implocal.HasAttribute("TotaldeRetenciones"))
                    totalCalculado = totalCalculado - decimal.Parse(implocal.GetAttribute("TotaldeRetenciones"));
            }
            invoice.Total = totalCalculado;
            invoice.Fecha = DateTime.Now;

            return invoice;
        }

        private string GetXml()
        {
            return "";
        }
        public override void SetCFDIHeaders(string moneda, decimal tipoCambio, string tipoComprobante, string metodoPago, string lugarExpedicion)
        {
            invoice.Moneda = moneda;
            if (invoice.Moneda_Info == null)
                throw new Exception("La moneda seleccionada no se encuentra en el catálogo de monedas");
            if (invoice.Moneda != "XXX")
            {
                invoice.TipoCambio = tipoCambio;
                invoice.TipoCambioSpecified = true;
            }
        }

        public override void SetTipoDeComprobante(string tipoComprobante)
        {
            invoice.TipoDeComprobante = tipoComprobante;
            //throw new NotImplementedException();
        }

        public override void SetEmisor(string nombre, string regimenFiscal, string Rfc)
        {
            invoice.Emisor = new ComprobanteEmisor();
            invoice.Emisor.Nombre = nombre;
            invoice.Emisor.RegimenFiscal = regimenFiscal;
            invoice.Emisor.Rfc = Rfc;
        }

        public override void SetReceptor(string nombre, string Rfc, string UsoCFDI)
        {
            throw new NotImplementedException();
        }

        //public override Invoice GetInvoice()
        //{
        //    var comprobante = (SW.Tools.Entities.Comprobante)invoice;

        //    throw new NotImplementedException();
        //}
    }
}
