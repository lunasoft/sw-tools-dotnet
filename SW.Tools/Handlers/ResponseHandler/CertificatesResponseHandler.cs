using SW.Tools.Entities.Response;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Handlers.ResponseHandler
{
    internal class CertificatesResponseHandler
    {
        internal static CertificatesResponse HandleException(Exception ex, string message)
        {
            return ResponseHelper.GetCertificatesResponse(ex.Message, ResponseHelper.GetErrorDetail(ex) ?? message);
        }
        internal static CertificatesResponse HandleException(CryptographicException ex, string message)
        {
            return ResponseHelper.GetCertificatesResponse(ex.Message, ResponseHelper.GetErrorDetail(ex) ?? message);
        }
    }
}
