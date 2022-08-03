using SW.Tools.Entities.Response;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Handlers.CertificateResponseHandler
{
    internal class InfoCertificateResponseHandler : ResponseHandler<InfoCertificateResponse>
    {
        internal static InfoCertificateResponse HandleException(Exception e)
        {
            return GetResponse(e);
        }
        internal static InfoCertificateResponse HandleException(CryptographicException e)
        {
            return GetResponse(e);
        }
    }
    internal class VerifyCertificateResponseHandler : ResponseHandler<VerifyCertificateResponse>
    {
        internal static VerifyCertificateResponse HandleException(Exception e)
        {
            return GetResponse(e);
        }
        internal static VerifyCertificateResponse HandleException(CryptographicException e)
        {
            return GetResponse(e);
        }
    }
}
