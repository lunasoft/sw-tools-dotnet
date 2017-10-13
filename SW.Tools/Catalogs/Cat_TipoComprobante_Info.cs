using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Catalogs
{
    public class Cat_TipoComprobante_Info
    {
        private c_TipoDeComprobante tipoDeComprobante;
        private string descripcion;
        private Dictionary<string, decimal> valorMaximo;
        public Cat_TipoComprobante_Info(
            c_TipoDeComprobante tc, string d, Dictionary<string, decimal> vm)
        {
            this.tipoDeComprobante = tc;
            this.descripcion = d;
            this.valorMaximo = vm;
        }


        public c_TipoDeComprobante TipoDeComprobante
        {
            get
            {
                return tipoDeComprobante;
            }

            set
            {
                tipoDeComprobante = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public Dictionary<string, decimal> ValorMaximo
        {
            get
            {
                return valorMaximo;
            }

            set
            {
                valorMaximo = value;
            }
        }
    }

    public class Cat_TipoComprobante
    {
        static Lazy<Dictionary<c_TipoDeComprobante, Cat_TipoComprobante_Info>> _lazyCatalog
            = new Lazy<Dictionary<c_TipoDeComprobante, Cat_TipoComprobante_Info>>(() =>
            {

                Dictionary<c_TipoDeComprobante, Cat_TipoComprobante_Info> result = new Dictionary<c_TipoDeComprobante, Cat_TipoComprobante_Info>();
                result.Add(c_TipoDeComprobante.I, new Cat_TipoComprobante_Info(c_TipoDeComprobante.I, "Ingreso", new Dictionary<string, decimal>() { { "ValorMaximo", Convert.ToDecimal("999999999999999999.999999") } }));
                result.Add(c_TipoDeComprobante.E, new Cat_TipoComprobante_Info(c_TipoDeComprobante.E, "Egreso", new Dictionary<string, decimal>() { { "ValorMaximo", Convert.ToDecimal("999999999999999999.999999") } }));
                result.Add(c_TipoDeComprobante.T, new Cat_TipoComprobante_Info(c_TipoDeComprobante.T, "Traslado", new Dictionary<string, decimal>() { { "ValorMaximo", 0 } }));
                result.Add(c_TipoDeComprobante.N, new Cat_TipoComprobante_Info(c_TipoDeComprobante.N, "Nómina", new Dictionary<string, decimal>() { { "NS", Convert.ToDecimal("999999999999999999.999999") }, { "NdS", (decimal)999999999999999999.999999 } }));
                result.Add(c_TipoDeComprobante.P, new Cat_TipoComprobante_Info(c_TipoDeComprobante.P, "Pago", new Dictionary<string, decimal>() { { "ValorMaximo", Convert.ToDecimal("999999999999999999.999999") } }));
                return result;
            });
        public static Dictionary<c_TipoDeComprobante, Cat_TipoComprobante_Info> Catalog
        {
            get
            {
                return _lazyCatalog.Value;
            }
        }
    }
}
