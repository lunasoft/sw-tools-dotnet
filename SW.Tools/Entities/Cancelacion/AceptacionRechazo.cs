using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Cancelacion
{
    public class AceptacionRechazo
    {
        public Guid Folio { get; set; }
        public AceptacionRechazoRespuesta Respuesta { get; set; }
    }
}
