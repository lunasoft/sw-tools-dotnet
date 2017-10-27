using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Entities.Complements
{
    public class c_Moneda_Elemen
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

        public c_Moneda_Elemen(string c, string d, int dec)
        {
            this.clave = c;
            this.descripcion = d;
            this.decimales = dec;
        }
    }
}
