using SW.Tools.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Entities.Complements
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/nomina12", IsNullable = false)]
    public partial class Nomina
    {

        private NominaEmisor emisorField;

        private NominaReceptor receptorField;

        private NominaPercepciones percepcionesField;

        private NominaDeducciones deduccionesField;

        private NominaOtroPago[] otrosPagosField;

        private NominaIncapacidad[] incapacidadesField;

        private string versionField;

        private c_TipoNomina tipoNominaField;

        private System.DateTime fechaPagoField;

        private System.DateTime fechaInicialPagoField;

        private System.DateTime fechaFinalPagoField;

        private decimal numDiasPagadosField;

        private decimal totalPercepcionesField;

        private bool totalPercepcionesFieldSpecified;

        private decimal totalDeduccionesField;

        private bool totalDeduccionesFieldSpecified;

        private decimal totalOtrosPagosField;

        private bool totalOtrosPagosFieldSpecified;

        public Nomina()
        {
            this.versionField = "1.2";
        }

        /// <remarks/>
        public NominaEmisor Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }

        /// <remarks/>
        public NominaReceptor Receptor
        {
            get
            {
                return this.receptorField;
            }
            set
            {
                this.receptorField = value;
            }
        }

        /// <remarks/>
        public NominaPercepciones Percepciones
        {
            get
            {
                return this.percepcionesField;
            }
            set
            {
                this.percepcionesField = value;
            }
        }

        /// <remarks/>
        public NominaDeducciones Deducciones
        {
            get
            {
                return this.deduccionesField;
            }
            set
            {
                this.deduccionesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("OtroPago", IsNullable = false)]
        public NominaOtroPago[] OtrosPagos
        {
            get
            {
                return this.otrosPagosField;
            }
            set
            {
                this.otrosPagosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Incapacidad", IsNullable = false)]
        public NominaIncapacidad[] Incapacidades
        {
            get
            {
                return this.incapacidadesField;
            }
            set
            {
                this.incapacidadesField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoNomina TipoNomina
        {
            get
            {
                return this.tipoNominaField;
            }
            set
            {
                this.tipoNominaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaInicialPago
        {
            get
            {
                return this.fechaInicialPagoField;
            }
            set
            {
                this.fechaInicialPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaFinalPago
        {
            get
            {
                return this.fechaFinalPagoField;
            }
            set
            {
                this.fechaFinalPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal NumDiasPagados
        {
            get
            {
                return this.numDiasPagadosField;
            }
            set
            {
                this.numDiasPagadosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalPercepciones
        {
            get
            {
                return this.totalPercepcionesField;
            }
            set
            {
                this.totalPercepcionesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalPercepcionesSpecified
        {
            get
            {
                return this.totalPercepcionesFieldSpecified;
            }
            set
            {
                this.totalPercepcionesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalDeducciones
        {
            get
            {
                return this.totalDeduccionesField;
            }
            set
            {
                this.totalDeduccionesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalDeduccionesSpecified
        {
            get
            {
                return this.totalDeduccionesFieldSpecified;
            }
            set
            {
                this.totalDeduccionesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalOtrosPagos
        {
            get
            {
                return this.totalOtrosPagosField;
            }
            set
            {
                this.totalOtrosPagosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalOtrosPagosSpecified
        {
            get
            {
                return this.totalOtrosPagosFieldSpecified;
            }
            set
            {
                this.totalOtrosPagosFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaEmisor
    {

        private NominaEmisorEntidadSNCF entidadSNCFField;

        private string curpField;

        private string registroPatronalField;

        private string rfcPatronOrigenField;

        /// <remarks/>
        public NominaEmisorEntidadSNCF EntidadSNCF
        {
            get
            {
                return this.entidadSNCFField;
            }
            set
            {
                this.entidadSNCFField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Curp
        {
            get
            {
                return this.curpField;
            }
            set
            {
                this.curpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RegistroPatronal
        {
            get
            {
                return this.registroPatronalField;
            }
            set
            {
                this.registroPatronalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RfcPatronOrigen
        {
            get
            {
                return this.rfcPatronOrigenField;
            }
            set
            {
                this.rfcPatronOrigenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaEmisorEntidadSNCF
    {

        private c_OrigenRecurso origenRecursoField;

        private decimal montoRecursoPropioField;

        private bool montoRecursoPropioFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_OrigenRecurso OrigenRecurso
        {
            get
            {
                return this.origenRecursoField;
            }
            set
            {
                this.origenRecursoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal MontoRecursoPropio
        {
            get
            {
                return this.montoRecursoPropioField;
            }
            set
            {
                this.montoRecursoPropioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MontoRecursoPropioSpecified
        {
            get
            {
                return this.montoRecursoPropioFieldSpecified;
            }
            set
            {
                this.montoRecursoPropioFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_OrigenRecurso
    {

        /// <remarks/>
        IP,

        /// <remarks/>
        IF,

        /// <remarks/>
        IM,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaReceptor
    {

        private NominaReceptorSubContratacion[] subContratacionField;

        private string curpField;

        private string numSeguridadSocialField;

        private System.DateTime fechaInicioRelLaboralField;

        private bool fechaInicioRelLaboralFieldSpecified;

        private string antigüedadField;

        private c_TipoContrato tipoContratoField;

        private NominaReceptorSindicalizado sindicalizadoField;

        private bool sindicalizadoFieldSpecified;

        private c_TipoJornada tipoJornadaField;

        private bool tipoJornadaFieldSpecified;

        private c_TipoRegimen tipoRegimenField;

        private string numEmpleadoField;

        private string departamentoField;

        private string puestoField;

        private c_RiesgoPuesto riesgoPuestoField;

        private bool riesgoPuestoFieldSpecified;

        private c_PeriodicidadPago periodicidadPagoField;

        private c_Banco bancoField;

        private bool bancoFieldSpecified;

        private string cuentaBancariaField;

        private decimal salarioBaseCotAporField;

        private bool salarioBaseCotAporFieldSpecified;

        private decimal salarioDiarioIntegradoField;

        private bool salarioDiarioIntegradoFieldSpecified;

        private c_Estados claveEntFedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubContratacion")]
        public NominaReceptorSubContratacion[] SubContratacion
        {
            get
            {
                return this.subContratacionField;
            }
            set
            {
                this.subContratacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Curp
        {
            get
            {
                return this.curpField;
            }
            set
            {
                this.curpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumSeguridadSocial
        {
            get
            {
                return this.numSeguridadSocialField;
            }
            set
            {
                this.numSeguridadSocialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaInicioRelLaboral
        {
            get
            {
                return this.fechaInicioRelLaboralField;
            }
            set
            {
                this.fechaInicioRelLaboralField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FechaInicioRelLaboralSpecified
        {
            get
            {
                return this.fechaInicioRelLaboralFieldSpecified;
            }
            set
            {
                this.fechaInicioRelLaboralFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Antigüedad
        {
            get
            {
                return this.antigüedadField;
            }
            set
            {
                this.antigüedadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoContrato TipoContrato
        {
            get
            {
                return this.tipoContratoField;
            }
            set
            {
                this.tipoContratoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NominaReceptorSindicalizado Sindicalizado
        {
            get
            {
                return this.sindicalizadoField;
            }
            set
            {
                this.sindicalizadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SindicalizadoSpecified
        {
            get
            {
                return this.sindicalizadoFieldSpecified;
            }
            set
            {
                this.sindicalizadoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoJornada TipoJornada
        {
            get
            {
                return this.tipoJornadaField;
            }
            set
            {
                this.tipoJornadaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TipoJornadaSpecified
        {
            get
            {
                return this.tipoJornadaFieldSpecified;
            }
            set
            {
                this.tipoJornadaFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoRegimen TipoRegimen
        {
            get
            {
                return this.tipoRegimenField;
            }
            set
            {
                this.tipoRegimenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumEmpleado
        {
            get
            {
                return this.numEmpleadoField;
            }
            set
            {
                this.numEmpleadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Departamento
        {
            get
            {
                return this.departamentoField;
            }
            set
            {
                this.departamentoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Puesto
        {
            get
            {
                return this.puestoField;
            }
            set
            {
                this.puestoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_RiesgoPuesto RiesgoPuesto
        {
            get
            {
                return this.riesgoPuestoField;
            }
            set
            {
                this.riesgoPuestoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RiesgoPuestoSpecified
        {
            get
            {
                return this.riesgoPuestoFieldSpecified;
            }
            set
            {
                this.riesgoPuestoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_PeriodicidadPago PeriodicidadPago
        {
            get
            {
                return this.periodicidadPagoField;
            }
            set
            {
                this.periodicidadPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_Banco Banco
        {
            get
            {
                return this.bancoField;
            }
            set
            {
                this.bancoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BancoSpecified
        {
            get
            {
                return this.bancoFieldSpecified;
            }
            set
            {
                this.bancoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CuentaBancaria
        {
            get
            {
                return this.cuentaBancariaField;
            }
            set
            {
                this.cuentaBancariaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SalarioBaseCotApor
        {
            get
            {
                return this.salarioBaseCotAporField;
            }
            set
            {
                this.salarioBaseCotAporField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SalarioBaseCotAporSpecified
        {
            get
            {
                return this.salarioBaseCotAporFieldSpecified;
            }
            set
            {
                this.salarioBaseCotAporFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SalarioDiarioIntegrado
        {
            get
            {
                return this.salarioDiarioIntegradoField;
            }
            set
            {
                this.salarioDiarioIntegradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SalarioDiarioIntegradoSpecified
        {
            get
            {
                return this.salarioDiarioIntegradoFieldSpecified;
            }
            set
            {
                this.salarioDiarioIntegradoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_Estados ClaveEntFed
        {
            get
            {
                return this.claveEntFedField;
            }
            set
            {
                this.claveEntFedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaReceptorSubContratacion
    {

        private string rfcLaboraField;

        private decimal porcentajeTiempoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RfcLabora
        {
            get
            {
                return this.rfcLaboraField;
            }
            set
            {
                this.rfcLaboraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal PorcentajeTiempo
        {
            get
            {
                return this.porcentajeTiempoField;
            }
            set
            {
                this.porcentajeTiempoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoContrato
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("99")]
        Item99,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public enum NominaReceptorSindicalizado
    {

        /// <remarks/>
        Sí,

        /// <remarks/>
        No,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoJornada
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("99")]
        Item99,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoRegimen
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <remarks/> Jubilados o Pensionados added
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("99")]
        Item99,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_RiesgoPuesto
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("99")]
        Item99,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_PeriodicidadPago
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("99")]
        Item99,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_Banco
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("002")]
        Item002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("006")]
        Item006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("009")]
        Item009,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("012")]
        Item012,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("014")]
        Item014,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("019")]
        Item019,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("021")]
        Item021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("030")]
        Item030,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("032")]
        Item032,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("036")]
        Item036,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("037")]
        Item037,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("042")]
        Item042,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("044")]
        Item044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("058")]
        Item058,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("059")]
        Item059,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("060")]
        Item060,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("062")]
        Item062,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("072")]
        Item072,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("102")]
        Item102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("103")]
        Item103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("106")]
        Item106,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("108")]
        Item108,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("110")]
        Item110,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("112")]
        Item112,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("113")]
        Item113,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("116")]
        Item116,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("124")]
        Item124,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("126")]
        Item126,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("127")]
        Item127,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("128")]
        Item128,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("129")]
        Item129,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("130")]
        Item130,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("131")]
        Item131,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("132")]
        Item132,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("133")]
        Item133,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("134")]
        Item134,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("135")]
        Item135,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("136")]
        Item136,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("137")]
        Item137,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("138")]
        Item138,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("139")]
        Item139,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("140")]
        Item140,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("141")]
        Item141,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("143")]
        Item143,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("145")]
        Item145,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("147")]
        Item147,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("148")]
        Item148,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("149")]
        Item149,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("150")]
        Item150,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("151")]
        Item151,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("152")]
        Item152,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("153")]
        Item153,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("154")]
        Item154,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("155")]
        Item155,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("156")]
        Item156,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("157")]
        Item157,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("158")]
        Item158,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("159")]
        Item159,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("160")]
        Item160,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("166")]
        Item166,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("168")]
        Item168,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("600")]
        Item600,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("601")]
        Item601,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("602")]
        Item602,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("605")]
        Item605,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("606")]
        Item606,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("607")]
        Item607,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("608")]
        Item608,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("610")]
        Item610,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("614")]
        Item614,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("615")]
        Item615,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("616")]
        Item616,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("617")]
        Item617,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("618")]
        Item618,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("619")]
        Item619,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("620")]
        Item620,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("621")]
        Item621,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("622")]
        Item622,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("623")]
        Item623,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("626")]
        Item626,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("627")]
        Item627,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("628")]
        Item628,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("629")]
        Item629,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("630")]
        Item630,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("631")]
        Item631,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("632")]
        Item632,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("633")]
        Item633,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("634")]
        Item634,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("636")]
        Item636,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("637")]
        Item637,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("638")]
        Item638,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("640")]
        Item640,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("642")]
        Item642,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("646")]
        Item646,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("647")]
        Item647,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("648")]
        Item648,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("649")]
        Item649,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("651")]
        Item651,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("652")]
        Item652,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("653")]
        Item653,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("655")]
        Item655,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("656")]
        Item656,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("659")]
        Item659,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("670")]
        Item670,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("901")]
        Item901,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("902")]
        Item902,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepciones
    {

        private NominaPercepcionesPercepcion[] percepcionField;

        private NominaPercepcionesJubilacionPensionRetiro jubilacionPensionRetiroField;

        private NominaPercepcionesSeparacionIndemnizacion separacionIndemnizacionField;

        private decimal totalSueldosField;

        private bool totalSueldosFieldSpecified;

        private decimal totalSeparacionIndemnizacionField;

        private bool totalSeparacionIndemnizacionFieldSpecified;

        private decimal totalJubilacionPensionRetiroField;

        private bool totalJubilacionPensionRetiroFieldSpecified;

        private decimal totalGravadoField;

        private decimal totalExentoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Percepcion")]
        public NominaPercepcionesPercepcion[] Percepcion
        {
            get
            {
                return this.percepcionField;
            }
            set
            {
                this.percepcionField = value;
            }
        }

        /// <remarks/>
        public NominaPercepcionesJubilacionPensionRetiro JubilacionPensionRetiro
        {
            get
            {
                return this.jubilacionPensionRetiroField;
            }
            set
            {
                this.jubilacionPensionRetiroField = value;
            }
        }

        /// <remarks/>
        public NominaPercepcionesSeparacionIndemnizacion SeparacionIndemnizacion
        {
            get
            {
                return this.separacionIndemnizacionField;
            }
            set
            {
                this.separacionIndemnizacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalSueldos
        {
            get
            {
                return this.totalSueldosField;
            }
            set
            {
                this.totalSueldosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalSueldosSpecified
        {
            get
            {
                return this.totalSueldosFieldSpecified;
            }
            set
            {
                this.totalSueldosFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalSeparacionIndemnizacion
        {
            get
            {
                return this.totalSeparacionIndemnizacionField;
            }
            set
            {
                this.totalSeparacionIndemnizacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalSeparacionIndemnizacionSpecified
        {
            get
            {
                return this.totalSeparacionIndemnizacionFieldSpecified;
            }
            set
            {
                this.totalSeparacionIndemnizacionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalJubilacionPensionRetiro
        {
            get
            {
                return this.totalJubilacionPensionRetiroField;
            }
            set
            {
                this.totalJubilacionPensionRetiroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalJubilacionPensionRetiroSpecified
        {
            get
            {
                return this.totalJubilacionPensionRetiroFieldSpecified;
            }
            set
            {
                this.totalJubilacionPensionRetiroFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalGravado
        {
            get
            {
                return this.totalGravadoField;
            }
            set
            {
                this.totalGravadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalExento
        {
            get
            {
                return this.totalExentoField;
            }
            set
            {
                this.totalExentoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepcionesPercepcion
    {

        private NominaPercepcionesPercepcionAccionesOTitulos accionesOTitulosField;

        private NominaPercepcionesPercepcionHorasExtra[] horasExtraField;

        private c_TipoPercepcion tipoPercepcionField;

        private string claveField;

        private string conceptoField;

        private decimal importeGravadoField;

        private decimal importeExentoField;

        /// <remarks/>
        public NominaPercepcionesPercepcionAccionesOTitulos AccionesOTitulos
        {
            get
            {
                return this.accionesOTitulosField;
            }
            set
            {
                this.accionesOTitulosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HorasExtra")]
        public NominaPercepcionesPercepcionHorasExtra[] HorasExtra
        {
            get
            {
                return this.horasExtraField;
            }
            set
            {
                this.horasExtraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoPercepcion TipoPercepcion
        {
            get
            {
                return this.tipoPercepcionField;
            }
            set
            {
                this.tipoPercepcionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteGravado
        {
            get
            {
                return this.importeGravadoField;
            }
            set
            {
                this.importeGravadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteExento
        {
            get
            {
                return this.importeExentoField;
            }
            set
            {
                this.importeExentoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepcionesPercepcionAccionesOTitulos
    {

        private decimal valorMercadoField;

        private decimal precioAlOtorgarseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ValorMercado
        {
            get
            {
                return this.valorMercadoField;
            }
            set
            {
                this.valorMercadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal PrecioAlOtorgarse
        {
            get
            {
                return this.precioAlOtorgarseField;
            }
            set
            {
                this.precioAlOtorgarseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepcionesPercepcionHorasExtra
    {

        private int diasField;

        private c_TipoHoras tipoHorasField;

        private int horasExtraField;

        private decimal importePagadoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Dias
        {
            get
            {
                return this.diasField;
            }
            set
            {
                this.diasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoHoras TipoHoras
        {
            get
            {
                return this.tipoHorasField;
            }
            set
            {
                this.tipoHorasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int HorasExtra
        {
            get
            {
                return this.horasExtraField;
            }
            set
            {
                this.horasExtraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImportePagado
        {
            get
            {
                return this.importePagadoField;
            }
            set
            {
                this.importePagadoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoHoras
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoPercepcion
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("001")]
        Item001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("002")]
        Item002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("003")]
        Item003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("004")]
        Item004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("005")]
        Item005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("006")]
        Item006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("009")]
        Item009,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("010")]
        Item010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("011")]
        Item011,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("012")]
        Item012,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("013")]
        Item013,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("014")]
        Item014,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("015")]
        Item015,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("019")]
        Item019,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("020")]
        Item020,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("021")]
        Item021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("022")]
        Item022,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("023")]
        Item023,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("024")]
        Item024,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("025")]
        Item025,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("026")]
        Item026,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("027")]
        Item027,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("028")]
        Item028,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("029")]
        Item029,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("030")]
        Item030,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("031")]
        Item031,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("032")]
        Item032,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("033")]
        Item033,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("034")]
        Item034,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("035")]
        Item035,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("036")]
        Item036,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("037")]
        Item037,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("038")]
        Item038,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("039")]
        Item039,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("044")]
        Item044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("045")]
        Item045,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("046")]
        Item046,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("047")]
        Item047,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("048")]
        Item048,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("049")]
        Item049,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("050")]
        Item050,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepcionesJubilacionPensionRetiro
    {

        private decimal totalUnaExhibicionField;

        private bool totalUnaExhibicionFieldSpecified;

        private decimal totalParcialidadField;

        private bool totalParcialidadFieldSpecified;

        private decimal montoDiarioField;

        private bool montoDiarioFieldSpecified;

        private decimal ingresoAcumulableField;

        private decimal ingresoNoAcumulableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalUnaExhibicion
        {
            get
            {
                return this.totalUnaExhibicionField;
            }
            set
            {
                this.totalUnaExhibicionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalUnaExhibicionSpecified
        {
            get
            {
                return this.totalUnaExhibicionFieldSpecified;
            }
            set
            {
                this.totalUnaExhibicionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalParcialidad
        {
            get
            {
                return this.totalParcialidadField;
            }
            set
            {
                this.totalParcialidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalParcialidadSpecified
        {
            get
            {
                return this.totalParcialidadFieldSpecified;
            }
            set
            {
                this.totalParcialidadFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal MontoDiario
        {
            get
            {
                return this.montoDiarioField;
            }
            set
            {
                this.montoDiarioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MontoDiarioSpecified
        {
            get
            {
                return this.montoDiarioFieldSpecified;
            }
            set
            {
                this.montoDiarioFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal IngresoAcumulable
        {
            get
            {
                return this.ingresoAcumulableField;
            }
            set
            {
                this.ingresoAcumulableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal IngresoNoAcumulable
        {
            get
            {
                return this.ingresoNoAcumulableField;
            }
            set
            {
                this.ingresoNoAcumulableField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaPercepcionesSeparacionIndemnizacion
    {

        private decimal totalPagadoField;

        private int numAñosServicioField;

        private decimal ultimoSueldoMensOrdField;

        private decimal ingresoAcumulableField;

        private decimal ingresoNoAcumulableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalPagado
        {
            get
            {
                return this.totalPagadoField;
            }
            set
            {
                this.totalPagadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NumAñosServicio
        {
            get
            {
                return this.numAñosServicioField;
            }
            set
            {
                this.numAñosServicioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal UltimoSueldoMensOrd
        {
            get
            {
                return this.ultimoSueldoMensOrdField;
            }
            set
            {
                this.ultimoSueldoMensOrdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal IngresoAcumulable
        {
            get
            {
                return this.ingresoAcumulableField;
            }
            set
            {
                this.ingresoAcumulableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal IngresoNoAcumulable
        {
            get
            {
                return this.ingresoNoAcumulableField;
            }
            set
            {
                this.ingresoNoAcumulableField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaDeducciones
    {

        private NominaDeduccionesDeduccion[] deduccionField;

        private decimal totalOtrasDeduccionesField;

        private bool totalOtrasDeduccionesFieldSpecified;

        private decimal totalImpuestosRetenidosField;

        private bool totalImpuestosRetenidosFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Deduccion")]
        public NominaDeduccionesDeduccion[] Deduccion
        {
            get
            {
                return this.deduccionField;
            }
            set
            {
                this.deduccionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalOtrasDeducciones
        {
            get
            {
                return this.totalOtrasDeduccionesField;
            }
            set
            {
                this.totalOtrasDeduccionesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalOtrasDeduccionesSpecified
        {
            get
            {
                return this.totalOtrasDeduccionesFieldSpecified;
            }
            set
            {
                this.totalOtrasDeduccionesFieldSpecified = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaDeduccionesDeduccion
    {

        private c_TipoDeduccion tipoDeduccionField;

        private string claveField;

        private string conceptoField;

        private decimal importeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoDeduccion TipoDeduccion
        {
            get
            {
                return this.tipoDeduccionField;
            }
            set
            {
                this.tipoDeduccionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <remarks/>
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoDeduccion
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("001")]
        Item001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("002")]
        Item002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("003")]
        Item003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("004")]
        Item004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("005")]
        Item005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("006")]
        Item006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("007")]
        Item007,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("008")]
        Item008,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("009")]
        Item009,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("010")]
        Item010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("011")]
        Item011,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("012")]
        Item012,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("013")]
        Item013,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("014")]
        Item014,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("015")]
        Item015,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("016")]
        Item016,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("017")]
        Item017,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("018")]
        Item018,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("019")]
        Item019,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("020")]
        Item020,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("021")]
        Item021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("022")]
        Item022,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("023")]
        Item023,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("024")]
        Item024,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("025")]
        Item025,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("026")]
        Item026,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("027")]
        Item027,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("028")]
        Item028,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("029")]
        Item029,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("030")]
        Item030,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("031")]
        Item031,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("032")]
        Item032,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("033")]
        Item033,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("034")]
        Item034,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("035")]
        Item035,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("036")]
        Item036,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("037")]
        Item037,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("038")]
        Item038,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("039")]
        Item039,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("040")]
        Item040,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("041")]
        Item041,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("042")]
        Item042,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("043")]
        Item043,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("044")]
        Item044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("045")]
        Item045,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("046")]
        Item046,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("047")]
        Item047,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("048")]
        Item048,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("049")]
        Item049,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("050")]
        Item050,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("051")]
        Item051,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("052")]
        Item052,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("053")]
        Item053,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("054")]
        Item054,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("055")]
        Item055,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("056")]
        Item056,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("057")]
        Item057,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("058")]
        Item058,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("059")]
        Item059,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("060")]
        Item060,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("061")]
        Item061,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("062")]
        Item062,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("063")]
        Item063,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("064")]
        Item064,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("065")]
        Item065,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("066")]
        Item066,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("067")]
        Item067,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("068")]
        Item068,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("069")]
        Item069,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("070")]
        Item070,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("071")]
        Item071,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("072")]
        Item072,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("073")]
        Item073,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("074")]
        Item074,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("075")]
        Item075,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("076")]
        Item076,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("077")]
        Item077,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("078")]
        Item078,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("079")]
        Item079,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("080")]
        Item080,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("081")]
        Item081,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("082")]
        Item082,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("083")]
        Item083,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("084")]
        Item084,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("085")]
        Item085,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("086")]
        Item086,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("087")]
        Item087,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("088")]
        Item088,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("089")]
        Item089,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("090")]
        Item090,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("091")]
        Item091,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("092")]
        Item092,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("093")]
        Item093,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("094")]
        Item094,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("095")]
        Item095,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("096")]
        Item096,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("097")]
        Item097,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("098")]
        Item098,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("099")]
        Item099,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("100")]
        Item100,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaOtroPago
    {

        private NominaOtroPagoSubsidioAlEmpleo subsidioAlEmpleoField;

        private NominaOtroPagoCompensacionSaldosAFavor compensacionSaldosAFavorField;

        private c_TipoOtroPago tipoOtroPagoField;

        private string claveField;

        private string conceptoField;

        private decimal importeField;

        /// <remarks/>
        public NominaOtroPagoSubsidioAlEmpleo SubsidioAlEmpleo
        {
            get
            {
                return this.subsidioAlEmpleoField;
            }
            set
            {
                this.subsidioAlEmpleoField = value;
            }
        }

        /// <remarks/>
        public NominaOtroPagoCompensacionSaldosAFavor CompensacionSaldosAFavor
        {
            get
            {
                return this.compensacionSaldosAFavorField;
            }
            set
            {
                this.compensacionSaldosAFavorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoOtroPago TipoOtroPago
        {
            get
            {
                return this.tipoOtroPagoField;
            }
            set
            {
                this.tipoOtroPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <remarks/>
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaOtroPagoSubsidioAlEmpleo
    {

        private decimal subsidioCausadoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SubsidioCausado
        {
            get
            {
                return this.subsidioCausadoField;
            }
            set
            {
                this.subsidioCausadoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaOtroPagoCompensacionSaldosAFavor
    {

        private decimal saldoAFavorField;

        private short añoField;

        private decimal remanenteSalFavField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SaldoAFavor
        {
            get
            {
                return this.saldoAFavorField;
            }
            set
            {
                this.saldoAFavorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Año
        {
            get
            {
                return this.añoField;
            }
            set
            {
                this.añoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal RemanenteSalFav
        {
            get
            {
                return this.remanenteSalFavField;
            }
            set
            {
                this.remanenteSalFavField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoOtroPago
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("001")]
        Item001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("002")]
        Item002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("003")]
        Item003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("004")]
        Item004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("999")]
        Item999,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina12")]
    public partial class NominaIncapacidad
    {

        private int diasIncapacidadField;

        private c_TipoIncapacidad tipoIncapacidadField;

        private decimal importeMonetarioField;

        private bool importeMonetarioFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DiasIncapacidad
        {
            get
            {
                return this.diasIncapacidadField;
            }
            set
            {
                this.diasIncapacidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public c_TipoIncapacidad TipoIncapacidad
        {
            get
            {
                return this.tipoIncapacidadField;
            }
            set
            {
                this.tipoIncapacidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteMonetario
        {
            get
            {
                return this.importeMonetarioField;
            }
            set
            {
                this.importeMonetarioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImporteMonetarioSpecified
        {
            get
            {
                return this.importeMonetarioFieldSpecified;
            }
            set
            {
                this.importeMonetarioFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoIncapacidad
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    public enum c_TipoNomina
    {

        /// <remarks/>
        O,

        /// <remarks/>
        E,
    }
}
