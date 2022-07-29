using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Response
{
    public class Response
    {
        public string status { get; set; } = "success";
        public string message { get; set; }
        public string messageDetail { get; set; }
    }
}
