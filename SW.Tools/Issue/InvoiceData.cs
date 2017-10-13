using SW.Tools.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Issue
{
    public abstract class InvoiceData
    {
        public abstract void SetConcept(decimal cantidad, string claveProdServ, string claveUnidad, string descripcion,
            decimal descuento, decimal importe, string noIdentificacion, string unidad, decimal valorUnitario);
        public abstract void SetCFDIRelacionado(string tipoRelacion, string uuid);
        public abstract void SetAddenda(string xmlAddenda);
        public abstract void SetComplemento(string xmlComplemento);
        public abstract void SetImpuestoTraslado(decimal importe, string impuesto, decimal tasaOCuota, string tipoFactor);
        public abstract void SetImpuestoRetencion(decimal importe, string impuesto);
        public abstract void SetCFDIHeaders(string moneda, decimal tipoCambio, string tipoComprobante, string metodoPago, string lugarExpedicion);
        public abstract void SetTipoDeComprobante(string tipoComprobante);
        public abstract void SetEmisor(string nombre, string regimenFiscal, string Rfc);
        public abstract void SetReceptor(string nombre, string Rfc, string UsoCFDI);
        public abstract Comprobante GetInvoice();
    }
}
