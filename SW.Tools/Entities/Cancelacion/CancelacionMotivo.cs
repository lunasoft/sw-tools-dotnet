using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Cancelacion
{
    /// <summary>
    /// Motivo de cancelación.
    /// </summary>
    public enum CancelacionMotivo
    {
        /// <summary>
        /// Comprobante emitido con errores con relación.
        /// </summary>
        Motivo01 = 01,
        /// <summary>
        /// Comprobante emitido con errores sin relación.
        /// </summary>
        Motivo02 = 02,
        /// <summary>
        /// No se llevó a cabo la operación.
        /// </summary>
        Motivo03 = 03,
        /// <summary>
        /// Operación nominativa relacionada en la factura global.
        /// </summary>
        Motivo04 = 04
    }
}
