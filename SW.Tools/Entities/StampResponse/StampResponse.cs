using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SW.Tools.Entities.StampResponse
{
    [DataContract]
    public class StampResponse
    {
        [DataMember]
        public string status { get; set; }
    }
    public class StampResponseV2 : StampResponse
    {
        [DataMember]
        public StampResponse_Data_v2 data { get; set; }
    }
    public class StampResponseV4 : StampResponse
    {
        [DataMember]
        public StampResponse_Data_v4 data { get; set; }
    }
    public class StampResponse_Data_v2
    {
        [DataMember]
        public string tfd { get; set; }
        [DataMember]
        public string cfdi { get; set; }
    }
    public class StampResponse_Data_v4
    {
        [DataMember]
        public string cadenaOriginalSAT { get; set; }
        [DataMember]
        public string noCertificadoSAT { get; set; }
        [DataMember]
        public string noCertificadoCFDI { get; set; }
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string selloSAT { get; set; }
        [DataMember]
        public string selloCFDI { get; set; }
        [DataMember]
        public string fechaTimbrado { get; set; }
        [DataMember]
        public string qrCode { get; set; }
        [DataMember]
        public string cfdi { get; set; }
    }
}
