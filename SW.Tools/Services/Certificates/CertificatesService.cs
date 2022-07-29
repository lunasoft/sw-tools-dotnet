using SW.Tools.Entities.Response;
using SW.Tools.Handlers.ResponseHandler;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Services.Certificates
{
    public class CertificatesService
    {
        internal static Response VerifyCertificateType(byte[] cer)
        {
            try
            {
                X509Certificate2 x509Certificate = new X509Certificate2(cer);
                List<X509KeyUsageExtension> extension = x509Certificate.Extensions.OfType<X509KeyUsageExtension>().ToList();
                Response response = new Response();
                if (isFIEL(extension))
                {
                    response.message = "El certificado es FIEL";
                }
                else
                {
                    if (isCSD(extension))
                    {
                        response.message = "El certificado es CSD";
                    }
                    else
                    {
                        response.status = "error";
                        response.message = "El certificado no es CSD ni FIEL";
                    }
                }
                return response;
            }
            catch(CryptographicException e)
            {
                return ResponseHandler.HandleException(e, "El certificado no es válido o está corrupto");
            }
            catch (Exception e)
            {
                return ResponseHandler.HandleException(e, "Ocurrió un error inesperado");
            }
        }
        internal static CertificatesResponse ReadCertificate(byte[] cer)
        {
            try
            {
                CertificatesResponse response = new CertificatesResponse();
                X509Certificate2 x509Certificate = new X509Certificate2(cer);
                response.data = new CertificatesResponseData()
                {
                    commonName = x509Certificate.GetNameInfo(X509NameType.SimpleName, false),
                    certificateNumber = SignUtils.CertificateNumber(x509Certificate),
                    validFrom = x509Certificate.NotBefore,
                    validTo = x509Certificate.NotAfter,
                    issuer = x509Certificate.GetNameInfo(X509NameType.SimpleName, true),
                    serialNumber = x509Certificate.SerialNumber,
                };
                return response;
            } 
            catch(CryptographicException e)
            {
                return CertificatesResponseHandler.HandleException(e, "El certificado no es válido o está corrupto");
            } 
            catch(Exception e)
            {
                return CertificatesResponseHandler.HandleException(e, "Ocurrió un error inesperado");
            }
        }
        #region Private
        private static bool isCSD(List<X509KeyUsageExtension> extension)
        {
            X509KeyUsageFlags flag = X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation;
            return extension[0].KeyUsages.HasFlag(flag);
        }

        private static bool isFIEL(List<X509KeyUsageExtension> extension)
        {
            X509KeyUsageFlags flag = X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.KeyAgreement | X509KeyUsageFlags.DataEncipherment;
            return extension[0].KeyUsages.HasFlag(flag);
        }
        #endregion
    }
}
