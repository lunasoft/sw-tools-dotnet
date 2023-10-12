using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Response
{
    public class SignResponse : Response
    {
        [DataMember]
        public SignDataResponse data { get; set; }

    }
    public partial class SignDataResponse
    {
        [DataMember]
        public string xml { get; set; }
    }
    public class SignResponseV2 : Response
    {
        [DataMember]
        public SignDataResponseV2 data { get; set; }
    }
    public partial class SignDataResponseV2
    {
        [DataMember]
        public string cadenaOriginal { get; set; }
    }
}
