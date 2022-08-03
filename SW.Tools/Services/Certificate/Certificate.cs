using SW.Tools.Entities.Response;
using System;
using System.Security.Cryptography;

namespace SW.Tools.Services.Certificate
{
    public class Certificate : CertificateService
    {
        /// <summary>
        /// Servicio que verifica si un certificado es de tipo FIEL, CSD o ninguno de los dos.
        /// </summary>
        /// <param name="certificado">Certificado.</param>
        /// <exception cref="CryptographicException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Un objeto <see cref="VerifyCertificateResponse"/></returns>
        public static VerifyCertificateResponse VerificarTipoCertificado(byte[] certificado)
        {
            return VerifyCertificateType(certificado);
        }
        /// <summary>
        /// Servicio que lee y obtiene la información de un certificado.
        /// </summary>
        /// <param name="certificado">Certificado.</param>
        /// <exception cref="CryptographicException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Un objeto <see cref="InfoCertificateResponse"/></returns>
        public static InfoCertificateResponse LeerCertificado(byte[] certificado)
        {
            return ReadCertificate(certificado);
        }
    }
}
