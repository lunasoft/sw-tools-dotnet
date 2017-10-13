using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Tools.Catalogs;
using SW.Tools.Issue;
using SW.Tools.Helpers;

namespace SW.Tools.Entities
{
    public partial class Comprobante
    {

        private int total_length;
        [System.Xml.Serialization.XmlIgnore]
        public int Total_Length
        {
            get
            {
                if ((this.Total % 1) != 0)
                {
                    string vU = this.Total.ToString();
                    if (vU.IndexOf(".") > 0)
                    {
                        total_length = vU.Split('.')[1].Length;
                    }
                }
                return total_length;
            }
        }
        private int totalImpuestosRetenidos_length;
        [System.Xml.Serialization.XmlIgnore]
        public int TotalImpuestosRetenidos_length
        {
            get
            {
                string vU = this.Impuestos.TotalImpuestosRetenidos.ToString();
                if (vU.IndexOf(".") > 0)
                {
                    totalImpuestosRetenidos_length = vU.Split('.')[1].Length;
                }
                return totalImpuestosRetenidos_length;
            }
        }
        private int totalImpuestosTrasladados_length;
        [System.Xml.Serialization.XmlIgnore]
        public int TotalImpuestosTrasladados_length
        {
            get
            {
                string vU = this.Impuestos.TotalImpuestosTrasladados.ToString();
                if (vU.IndexOf(".") > 0)
                {
                    totalImpuestosTrasladados_length = vU.Split('.')[1].Length;
                }
                return totalImpuestosTrasladados_length;
            }
        }
        private int subtotal_length;
        [System.Xml.Serialization.XmlIgnore]
        public int Subtotal_Length
        {
            get
            {
                string vU = this.SubTotal.ToString();
                if (vU.IndexOf(".") > 0)
                {
                    subtotal_length = vU.Split('.')[1].Length;
                }
                return subtotal_length;
            }
        }

        private Cat_Moneda_Info moneda_Info;
        [System.Xml.Serialization.XmlIgnore]
        public Cat_Moneda_Info Moneda_Info
        {
            get
            {
                if (moneda_Info == null)
                {
                    moneda_Info = CatCFDI_Moneda.Catalog.ContainsKey(this.Moneda.ToString()) ?
                        CatCFDI_Moneda.Catalog[this.Moneda.ToString()] : default(Cat_Moneda_Info);
                }
                return moneda_Info;
            }
        }

        //Tipode cambio
        private decimal max_limit_rateexchange;
        //El límite superior se obtiene multiplicando el valor publicado del tipo de cambio por la suma
        //de uno más el porcentaje aplicable a la moneda tomado del catálogo c_Moneda.     
        [System.Xml.Serialization.XmlIgnore]
        public decimal Max_limit_ExchangeRate
        {
            get
            {
                if (max_limit_rateexchange == 0)
                {
                    max_limit_rateexchange = this.Actual_Currency_Rate * (1 + ((this.Moneda_Info.PorcentajeVariacion) / 100));
                }
                return max_limit_rateexchange;
            }
        }

        private decimal min_limit_rateexchange;
        //        El límite inferior se obtiene multiplicando el valor publicado del tipo de cambio por la suma
        //de uno menos el porcentaje aplicable a la moneda tomado del catálogo c_Moneda.Si este
        //límite fuera negativo se toma cero.
        [System.Xml.Serialization.XmlIgnore]
        public decimal Min_limit_RateExchange
        {
            get
            {
                if (min_limit_rateexchange == 0)
                {
                    //TODO: calcular en base a moneda
                    var res = this.Actual_Currency_Rate * (1 - ((Actual_Currency_Rate * this.Moneda_Info.PorcentajeVariacion) / 100));
                    min_limit_rateexchange = res < 0 ? 0 : res;
                }
                return min_limit_rateexchange;
            }
        }
        private decimal _actual_Currency_Rate;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Actual_Currency_Rate
        {
            get
            {
                if (_actual_Currency_Rate <= 0)
                    _actual_Currency_Rate = this.TipoCambio;
                return _actual_Currency_Rate;
            }

            set
            {
                _actual_Currency_Rate = value;
            }
        }
        private List<Complements.RFCINC> _rfcinc;
        [System.Xml.Serialization.XmlIgnore]
        public List<Complements.RFCINC> RFCINC
        {
            get
            {
                return _rfcinc;
            }
            set
            {
                _rfcinc = value;
            }
        }

        private Dictionary<string, decimal> _rates;
        [System.Xml.Serialization.XmlIgnore]
        public Dictionary<string, decimal> Rates
        {
            get
            {
                return _rates;
            }
            set
            {
                _rates = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public bool ExistsCCE
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.ToLower().Contains("comercioexterior")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasNomina12
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("nomina12:Nomina")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasPagos10
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("pago10:Pagos")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasComercioExterior11
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("cce11:ComercioExterior")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasINE11
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("ine:INE")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasECC11
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("ecc11:EstadoDeCuentaCombustible")) > 0) == true;
            }
        }
        private decimal? maxLimitComprobante;

        [System.Xml.Serialization.XmlIgnore]
        public decimal? MaxLimitComprobante
        {
            get
            {
                if (maxLimitComprobante == null)
                {
                    try
                    {
                        var limit = Cat_TipoComprobante.Catalog[EnumUtils.GetEnumValue<c_TipoDeComprobante>(this.TipoDeComprobante)];
                        if (this.TipoDeComprobante == c_TipoDeComprobante.N.ToString())
                        {
                            if (this.HasNomina12)
                            {
                                var payrollComplement = this.Complemento.FirstOrDefault(c => c.Any.Any(w => w.Name == "nomina12:Nomina"));
                                var payroll = payrollComplement.Any.FirstOrDefault(w => w.Name == "nomina12:Nomina");
                                var payrollXml = payroll.OuterXml.ToXmlDocument();
                                if (payrollXml == null)
                                    throw new ToolsException("CFDI33XXX", "El complemento nomina12:Nomina no es valido.");

                                var objPayroll = Serializer.DeserealizeDocument<Entities.Complements.Nomina>(payrollXml.OuterXml);
                                if (objPayroll.Percepciones != null)
                                {
                                    if (objPayroll.Percepciones.TotalSueldosSpecified && !objPayroll.Percepciones.TotalSeparacionIndemnizacionSpecified)
                                        maxLimitComprobante = limit.ValorMaximo["NS"];
                                    else if (!objPayroll.Percepciones.TotalSueldosSpecified && (objPayroll.Percepciones.TotalSeparacionIndemnizacionSpecified
                                        || objPayroll.Percepciones.TotalJubilacionPensionRetiroSpecified))
                                        maxLimitComprobante = limit.ValorMaximo["NdS"];
                                    else if ((objPayroll.Percepciones.TotalSueldosSpecified && objPayroll.Percepciones.TotalSeparacionIndemnizacionSpecified)
                                            || objPayroll.Percepciones.TotalJubilacionPensionRetiroSpecified)
                                        maxLimitComprobante = limit.ValorMaximo["NdS"] + limit.ValorMaximo["NS"];
                                    else
                                        maxLimitComprobante = limit.ValorMaximo["NS"];
                                }
                                else
                                {
                                    maxLimitComprobante = limit.ValorMaximo["NS"];
                                }
                            }
                        }
                        else
                            maxLimitComprobante = limit.ValorMaximo["ValorMaximo"];
                    }
                    catch (Exception ex)
                    {
                        throw new ToolsException("CFDI33XXX", "No fue posible obtener el valor maximo del comprobante por tipo de comprobante",
                            ex.Message);
                    }
                }
                return maxLimitComprobante;
            }

        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasImpLocales
        {
            get
            {
                return this.Complemento?.Any(w => w.Any?.Count(a => a.Name.Contains("implocal:ImpuestosLocales")) > 0) == true;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool HasComplemento
        {
            get
            {
                return this.Complemento != null && this.Complemento.Count() > 0;
            }
        }
    }
    public partial class ComprobanteComplemento
    {
        [System.Xml.Serialization.XmlIgnore]
        public bool HasElements
        {
            get
            {
                return this.Any != null && this.Any.Count() > 0;
            }
        }
    }
    public static class RfcGeneric
    {
        public static readonly string National = "XAXX010101000";
        public static readonly string Foreign = "XEXX010101000";

    }
}
