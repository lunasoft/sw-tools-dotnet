using SW.Tools.Entities.Cancelacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Helpers
{
    internal class Validation
    {
        internal static void ValidarCancelacion(List<Cancelacion> folios)
        {
            if (folios.Count > 500)
            {
                throw new Exception("Se ha excedido el limite de folios a cancelar.");
            }
            if (folios.Any(l => l.Motivo == 0))
            {
                throw new Exception("No se ha especificado un motivo de cancelacion.");
            }
            if (folios.Any(l => l.Motivo == CancelacionMotivo.Motivo01 && l.FolioSustitucion is null))
            {
                throw new Exception("El motivo de cancelación no es válido.");
            }
            if (folios.Any(l => l.Folio == Guid.Empty))
            {
                throw new Exception("Los folios no tienen un formato válido.");
            }
        }
        internal static void ValidarAceptacionRechazo(List<AceptacionRechazo> folios)
        {
            if(folios != null && folios.Count > 0)
            {
                if (folios.Count > 500)
                {
                    throw new Exception("Se ha excedido el limite de folios.");
                }
                if (folios.Any(l => l.Folio == Guid.Empty))
                {
                    throw new Exception("Los folios no tienen un formato válido.");
                }
            }else
            {
                throw new Exception("Folios inválidos, la lista de folios está vacía o no es correcta.");
            }
        }
    }
}
