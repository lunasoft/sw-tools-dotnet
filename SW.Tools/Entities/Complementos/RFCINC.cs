using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Entities.Complementos
{
    public class RFCINC
    {
        public RFCINC(string contribuyenteRFC, bool sncf, bool subcontratacion)
        {
            this.contribuyenteRFC = contribuyenteRFC;
            this.sncf = sncf;
            this.subcontratacion = subcontratacion;
        }
        readonly string contribuyenteRFC;
        readonly bool sncf;
        readonly bool subcontratacion;

        public string ContribuyenteRFC
        {
            get
            {
                return contribuyenteRFC;
            }
        }

        public bool Sncf
        {
            get
            {
                return sncf;
            }
        }

        public bool Subcontratacion
        {
            get
            {
                return subcontratacion;
            }
        }
    }
}
