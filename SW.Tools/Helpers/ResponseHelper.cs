using SW.Tools.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Helpers
{
    internal class ResponseHelper
    {
        internal static Response GetResponse(string message, string messageDetail)
        {
            return new Response()
            {
                status = "error",
                message = message,
                messageDetail = messageDetail
            };
        }
        internal static CertificatesResponse GetCertificatesResponse(string message, string messageDetail)
        {
            return new CertificatesResponse()
            {
                status = "error",
                message = message,
                messageDetail = messageDetail
            };
        }
        internal static string GetErrorDetail(Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return null;
        }
    }
}
