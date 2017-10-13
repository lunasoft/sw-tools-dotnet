using SW.Tools.Catalogs;
using SW.Tools.Entities;
using SW.Tools.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Helpers
{
    public partial class Validation
    {
        public static void CurrencyRateNotExist(Comprobante invoice)
        {
            var c_MonedaMXN = EnumUtils.GetXmlEnumAttributeValueFromEnum<c_Moneda>(c_Moneda.MXN);
            var c_MonedaXXX = EnumUtils.GetXmlEnumAttributeValueFromEnum<c_Moneda>(c_Moneda.XXX);
            if (invoice.Moneda == c_MonedaMXN && invoice.TipoCambioSpecified && invoice.TipoCambio != 1)
                if (invoice.HasPagos10)
                    throw new ToolsException("CRP108", Errors.CRP108);
                else
                    throw new ToolsException("CFDI33113", Errors.CFDI33113,
                    "", "1", invoice.TipoCambio.ToString());
            if (invoice.Moneda == c_MonedaXXX && invoice.TipoCambioSpecified)
                if (invoice.HasPagos10)
                    throw new ToolsException("CRP108", Errors.CRP108);
                else
                    throw new ToolsException("CFDI33115", Errors.CFDI33115);
        }
    }
}
