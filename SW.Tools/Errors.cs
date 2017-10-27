using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools
{
    public partial class Errors
    {
        public const string CRP108 = "CRP108 - El campo TipoCambio no se debe registrar en el CFDI.";
        public const string CFDI33113 = "CFDI33113 - El campo TipoCambio no tiene el valor 1 y la moneda indicada es MXN.";
        public const string CFDI33115 = "CFDI33115 - El campo TipoCambio no se debe registrar cuando el campo Moneda tiene el valor XXX.";
        public const string CFDI33154 = "CFDI33154 - El valor del campo Base que corresponde a Traslado debe ser mayor que cero.";
        public const string CFDI33163 = "CFDI33163 - El valor del campo Base que corresponde a Retención debe ser mayor que cero.";
    }
}
