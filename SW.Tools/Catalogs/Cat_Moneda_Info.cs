using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SW.Tools.Catalogs
{
    public class Cat_Moneda_Info
    {
        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int decimales;

        public int Decimales
        {
            get { return decimales; }
            set { decimales = value; }
        }

        public decimal PorcentajeVariacion
        {
            get
            {
                return porcentajeVariacion;
            }

            set
            {
                porcentajeVariacion = value;
            }
        }

        private decimal porcentajeVariacion;

        public Cat_Moneda_Info(string c, string d, int dec, decimal pv)
        {
            this.clave = c;
            this.descripcion = d;
            this.decimales = dec;
            this.porcentajeVariacion = pv;
        }

        public Cat_Moneda_Info(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                var data = line.Split('|');
                if (data != null && data.Length == 4)
                {
                    decimal porcentajeVariacion;
                    int decimales;
                    int.TryParse(data[2], out decimales);
                    decimal.TryParse(data[3], out porcentajeVariacion);
                    this.clave = data[0];
                    this.descripcion = data[1];
                    this.decimales = decimales;
                    this.porcentajeVariacion = porcentajeVariacion;
                }
            }
        }
    }

    public class CatCFDI_Moneda
    {
        static readonly object mutex = new object();
        static Lazy<Dictionary<string, Cat_Moneda_Info>> _lazyCatalog
            = new Lazy<Dictionary<string, Cat_Moneda_Info>>(() =>
            {
                var assembly = System.Reflection.Assembly.GetAssembly(typeof(Cat_Moneda_Info));
                var rs_Catalogs_catCFDI_Moneda = assembly.GetManifestResourceStream("SW.CFDISDK.Catalogs.catCFDI_Moneda.txt");
                var catalog = new Dictionary<string, Cat_Moneda_Info>();
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    rs_Catalogs_catCFDI_Moneda.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(line))
                                {
                                    var value = new Cat_Moneda_Info(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(line)));
                                    if (!string.IsNullOrEmpty(value.Clave))
                                        catalog.Add(value.Clave, value);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                throw ex;
                            }

                        }
                    }
                }
                return catalog;
            });

        public static Dictionary<string, Cat_Moneda_Info> Catalog
        {

            get
            {
                return _lazyCatalog.Value;
            }
        }
    }

}
