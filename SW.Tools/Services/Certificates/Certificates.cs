using SW.Tools.Entities.Response;
using System;
using System.Security.Cryptography;

namespace SW.Tools.Services.Certificates
{
    public class Certificates : CertificatesService
    {
        /// <summary>
        /// Servicio que verifica si un certificado es de tipo FIEL, CSD o ninguno de los dos.
        /// </summary>
        /// <param name="certificado">Certificado.</param>
        /// <exception cref="CryptographicException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Un objeto <see cref="Response"/></returns>
        public static Response VerificarTipoCertificado(byte[] certificado)
        {
            return VerifyCertificateType(certificado);
        }
        /// <summary>
        /// Servicio que lee y obtiene la información de un certificado.
        /// </summary>
        /// <param name="certificado">Certificado.</param>
        /// <exception cref="CryptographicException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Un objeto <see cref="CertificatesResponse"/></returns>
        public static CertificatesResponse LeerCertificado(byte[] certificado)
        {
            return ReadCertificate(certificado);
        }
    }
}
