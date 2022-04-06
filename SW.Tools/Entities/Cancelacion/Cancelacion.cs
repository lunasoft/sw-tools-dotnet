using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Cancelacion
{
    public class Cancelacion
    {
        public Guid Folio { get; set; }
        public CancelacionMotivo Motivo { get; set; }
        public Guid? FolioSustitucion { get; set; }
    }
}
