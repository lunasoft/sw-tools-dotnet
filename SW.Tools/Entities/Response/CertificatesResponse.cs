using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Entities.Response
{
    public class CertificatesResponse : Response
    {
        public CertificatesResponseData data { get; set; }
    }
    public class CertificatesResponseData
    {
        public string commonName { get; set; }
        public string certificateNumber { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public string issuer { get; set; }
        public string serialNumber { get; set; }
    }
}
