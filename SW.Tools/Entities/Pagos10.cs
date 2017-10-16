using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Entities
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/Pagos", IsNullable = false)]
    public partial class Pagos
    {

        private PagosPago[] pagoField;

        private string versionField;

        public Pagos()
        {
            this.versionField = "1.0";
        }


        [System.Xml.Serialization.XmlElementAttribute("Pago")]
        public PagosPago[] Pago
        {
            get
            {
                return this.pagoField;
            }
            set
            {
                this.pagoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    public partial class PagosPago
    {

        private PagosPagoDoctoRelacionado[] doctoRelacionadoField;

        private PagosPagoImpuestos[] impuestosField;

        private System.DateTime fechaPagoField;

        private string formaDePagoPField;

        private string monedaPField;
        private decimal _actual_Currency_Rate;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Actual_Currency_Rate
        {
            get
            {
                if (_actual_Currency_Rate <= 0)
                    _actual_Currency_Rate = this.tipoCambioPField;
                return _actual_Currency_Rate;
            }

            set
            {
                _actual_Currency_Rate = value;
            }
        }
        private decimal tipoCambioPField;

        private bool tipoCambioPFieldSpecified;

        private decimal montoField;

        private string numOperacionField;

        private string rfcEmisorCtaOrdField;

        private string nomBancoOrdExtField;

        private string ctaOrdenanteField;

        private string rfcEmisorCtaBenField;

        private string ctaBeneficiarioField;

        private string tipoCadPagoField;

        private bool tipoCadPagoFieldSpecified;

        private byte[] certPagoField;

        private string cadPagoField;

        private byte[] selloPagoField;


        [System.Xml.Serialization.XmlElementAttribute("DoctoRelacionado")]
        public PagosPagoDoctoRelacionado[] DoctoRelacionado
        {
            get
            {
                return this.doctoRelacionadoField;
            }
            set
            {
                this.doctoRelacionadoField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Impuestos")]
        public PagosPagoImpuestos[] Impuestos
        {
            get
            {
                return this.impuestosField;
            }
            set
            {
                this.impuestosField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime FechaPago
        {
            get
            {
                return this.fechaPagoField;
            }
            set
            {
                this.fechaPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormaDePagoP
        {
            get
            {
                return this.formaDePagoPField;
            }
            set
            {
                this.formaDePagoPField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MonedaP
        {
            get
            {
                return this.monedaPField;
            }
            set
            {
                this.monedaPField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TipoCambioP
        {
            get
            {
                return this.tipoCambioPField;
            }
            set
            {
                this.tipoCambioPField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TipoCambioPSpecified
        {
            get
            {
                return this.tipoCambioPFieldSpecified;
            }
            set
            {
                this.tipoCambioPFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Monto
        {
            get
            {
                return this.montoField;
            }
            set
            {
                this.montoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumOperacion
        {
            get
            {
                return this.numOperacionField;
            }
            set
            {
                this.numOperacionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RfcEmisorCtaOrd
        {
            get
            {
                return this.rfcEmisorCtaOrdField;
            }
            set
            {
                this.rfcEmisorCtaOrdField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NomBancoOrdExt
        {
            get
            {
                return this.nomBancoOrdExtField;
            }
            set
            {
                this.nomBancoOrdExtField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CtaOrdenante
        {
            get
            {
                return this.ctaOrdenanteField;
            }
            set
            {
                this.ctaOrdenanteField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RfcEmisorCtaBen
        {
            get
            {
                return this.rfcEmisorCtaBenField;
            }
            set
            {
                this.rfcEmisorCtaBenField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CtaBeneficiario
        {
            get
            {
                return this.ctaBeneficiarioField;
            }
            set
            {
                this.ctaBeneficiarioField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoCadPago
        {
            get
            {
                return this.tipoCadPagoField;
            }
            set
            {
                this.tipoCadPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TipoCadPagoSpecified
        {
            get
            {
                return this.tipoCadPagoFieldSpecified;
            }
            set
            {
                this.tipoCadPagoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "base64Binary")]
        public byte[] CertPago
        {
            get
            {
                return this.certPagoField;
            }
            set
            {
                this.certPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CadPago
        {
            get
            {
                return this.cadPagoField;
            }
            set
            {
                this.cadPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "base64Binary")]
        public byte[] SelloPago
        {
            get
            {
                return this.selloPagoField;
            }
            set
            {
                this.selloPagoField = value;
            }
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    public partial class PagosPagoDoctoRelacionado
    {

        private string idDocumentoField;

        private string serieField;

        private string folioField;

        private string monedaDRField;

        private decimal tipoCambioDRField;

        private bool tipoCambioDRFieldSpecified;

        private string metodoDePagoDRField;

        private string numParcialidadField;

        private decimal impSaldoAntField;

        private bool impSaldoAntFieldSpecified;

        private decimal impPagadoField;

        private bool impPagadoFieldSpecified;

        private decimal impSaldoInsolutoField;

        private bool impSaldoInsolutoFieldSpecified;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IdDocumento
        {
            get
            {
                return this.idDocumentoField;
            }
            set
            {
                this.idDocumentoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MonedaDR
        {
            get
            {
                return this.monedaDRField;
            }
            set
            {
                this.monedaDRField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TipoCambioDR
        {
            get
            {
                return this.tipoCambioDRField;
            }
            set
            {
                this.tipoCambioDRField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TipoCambioDRSpecified
        {
            get
            {
                return this.tipoCambioDRFieldSpecified;
            }
            set
            {
                this.tipoCambioDRFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MetodoDePagoDR
        {
            get
            {
                return this.metodoDePagoDRField;
            }
            set
            {
                this.metodoDePagoDRField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string NumParcialidad
        {
            get
            {
                return this.numParcialidadField;
            }
            set
            {
                this.numParcialidadField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImpSaldoAnt
        {
            get
            {
                return this.impSaldoAntField;
            }
            set
            {
                this.impSaldoAntField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpSaldoAntSpecified
        {
            get
            {
                return this.impSaldoAntFieldSpecified;
            }
            set
            {
                this.impSaldoAntFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImpPagado
        {
            get
            {
                return this.impPagadoField;
            }
            set
            {
                this.impPagadoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpPagadoSpecified
        {
            get
            {
                return this.impPagadoFieldSpecified;
            }
            set
            {
                this.impPagadoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImpSaldoInsoluto
        {
            get
            {
                return this.impSaldoInsolutoField;
            }
            set
            {
                this.impSaldoInsolutoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpSaldoInsolutoSpecified
        {
            get
            {
                return this.impSaldoInsolutoFieldSpecified;
            }
            set
            {
                this.impSaldoInsolutoFieldSpecified = value;
            }
        }
    }









    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    public partial class PagosPagoImpuestos
    {

        private PagosPagoImpuestosRetencion[] retencionesField;

        private PagosPagoImpuestosTraslado[] trasladosField;

        private decimal totalImpuestosRetenidosField;

        private bool totalImpuestosRetenidosFieldSpecified;

        private decimal totalImpuestosTrasladadosField;

        private bool totalImpuestosTrasladadosFieldSpecified;


        [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
        public PagosPagoImpuestosRetencion[] Retenciones
        {
            get
            {
                return this.retencionesField;
            }
            set
            {
                this.retencionesField = value;
            }
        }


        [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
        public PagosPagoImpuestosTraslado[] Traslados
        {
            get
            {
                return this.trasladosField;
            }
            set
            {
                this.trasladosField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalImpuestosRetenidos
        {
            get
            {
                return this.totalImpuestosRetenidosField;
            }
            set
            {
                this.totalImpuestosRetenidosField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalImpuestosRetenidosSpecified
        {
            get
            {
                return this.totalImpuestosRetenidosFieldSpecified;
            }
            set
            {
                this.totalImpuestosRetenidosFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalImpuestosTrasladados
        {
            get
            {
                return this.totalImpuestosTrasladadosField;
            }
            set
            {
                this.totalImpuestosTrasladadosField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalImpuestosTrasladadosSpecified
        {
            get
            {
                return this.totalImpuestosTrasladadosFieldSpecified;
            }
            set
            {
                this.totalImpuestosTrasladadosFieldSpecified = value;
            }
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    public partial class PagosPagoImpuestosRetencion
    {

        private string impuestoField;

        private decimal importeField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }





    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
    public partial class PagosPagoImpuestosTraslado
    {

        private string impuestoField;

        private string tipoFactorField;

        private string tasaOCuotaField;

        private decimal importeField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoFactor
        {
            get
            {
                return this.tipoFactorField;
            }
            set
            {
                this.tipoFactorField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TasaOCuota
        {
            get
            {
                return this.tasaOCuotaField;
            }
            set
            {
                this.tasaOCuotaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }





    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Pagos")]
    public enum c_TipoCadenaPago
    {


        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,
    }
}
