using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Entities
{
    public class ToolsException : Exception
    {
        public string code { get; set; }
        public string attrName { get; set; }
        public string messageDetail { get; set; }
        public ToolsException(string code, string message, Exception innerException=null, string attrName = null) : base(message, innerException)
        {
            this.code = code;
            this.attrName = attrName;
        }
        public ToolsException(string code, string message, string messageDetail, Exception innerException = null) : base(message, innerException)
        {
            this.code = code;
            this.messageDetail = messageDetail;
        }
        public ToolsException(string code, string message, string messageDetails, string messageDetailExpected, string messageDetailReported, Exception innerException = null): base(message,innerException)
        {
            this.code = code;
            this.messageDetail = messageDetail + " ValorEsperado: " + messageDetailExpected + " ValorReportado: " + messageDetailReported;
        }
    }
}
