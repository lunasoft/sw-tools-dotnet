using System;

namespace SW.Tools.Entities.Response
{
    public class InfoCertificateResponse : Response
    {
        public InfoCertificateResponseData data { get; set; }
    }
    public partial class InfoCertificateResponseData
    {
        public string commonName { get; set; }
        public string certificateNumber { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public string issuer { get; set; }
        public string serialNumber { get; set; }
    }
    public class VerifyCertificateResponse : Response
    {
        public string data { get; set; }
    }
}
