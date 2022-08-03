using SW.Tools.Entities.Response;
using SW.Tools.Handlers.CertificateResponseHandler;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace SW.Tools.Services.Certificate
{
    public class CertificateService
    {
        internal static VerifyCertificateResponse VerifyCertificateType(byte[] cer)
        {
            try
            {
                X509Certificate2 x509Certificate = new X509Certificate2(cer);
                List<X509KeyUsageExtension> extension = x509Certificate.Extensions.OfType<X509KeyUsageExtension>().ToList();
                VerifyCertificateResponse response = new VerifyCertificateResponse();
                if (isFIEL(extension))
                {
                    response.data = "El certificado es FIEL.";
                }
                else
                {
                    if (isCSD(extension))
                    {
                        response.data = "El certificado es CSD.";
                    }
                    else
                    {
                        response.status = "error";
                        response.data = "El certificado no es CSD ni FIEL.";
                    }
                }
                return response;
            }
            catch(CryptographicException e)
            {
                return VerifyCertificateResponseHandler.HandleException(e, "El certificado no es válido o se encuentra corrupto.");
            }
            catch (Exception e)
            {
                return VerifyCertificateResponseHandler.HandleException(e);
            }
        }
        internal static InfoCertificateResponse ReadCertificate(byte[] cer)
        {
            try
            {
                InfoCertificateResponse response = new InfoCertificateResponse();
                X509Certificate2 x509Certificate = new X509Certificate2(cer);
                response.data = new InfoCertificateResponseData()
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
                return InfoCertificateResponseHandler.HandleException(e, "El certificado no es válido o se encuentra corrupto.");
            } 
            catch(Exception e)
            {
                return InfoCertificateResponseHandler.HandleException(e);
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
