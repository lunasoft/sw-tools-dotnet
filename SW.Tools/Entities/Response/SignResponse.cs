using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Response
{
    public class SignResponse : Response
    {
        public SignDataResponse data { get; set; }
    }
    public partial class SignDataResponse
    {
        public string xml { get; set; }
    }
}
