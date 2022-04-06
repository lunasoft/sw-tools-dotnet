using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using SW.Tools.Entities.Cancelacion;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;

namespace SW.Tools.Services.Sign
{
    internal class SignService
    {
        internal static byte[] CreatePFX(byte[] bytesCER, byte[] bytesKEY, string password)
        {
            try
            {
                var certificate = new X509Certificate2(bytesCER, password);

                char[] arrayOfChars = password.ToCharArray();
                AsymmetricKeyParameter privateKey = PrivateKeyFactory.DecryptKey(arrayOfChars, bytesKEY);
                RSACryptoServiceProvider subjectKey = SignUtils.ToRSA((RsaPrivateCrtKeyParameters)privateKey);
                certificate.PrivateKey = subjectKey;
                return certificate.Export(X509ContentType.Pfx, password);
            }
            catch (Exception e)
            {
                throw new Exception("Los datos del Certificado CER KEY o Password son incorrectos. No es posible leer la llave privada.", e);
            }
        }
        internal static string SignCfdi(byte[] pfx, string password, string xml, string version = "4.0")
        {
            try
            {
                X509Certificate2 x509Certificate = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                var nCertificate = SignUtils.CertificateNumber(x509Certificate);
                var certificate = Convert.ToBase64String(x509Certificate.GetRawCertData());
                xml = SignUtils.SignXml(xml, nCertificate, certificate);
                var originalString = version != "4.0" ? GetCadenaOriginal(xml, "3.3") : GetCadenaOriginal(xml);
                var signResult = SignUtils.GetSignature(password, pfx, originalString, "SHA256");

                return SignUtils.SignXml(xml, signResult);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo realizar el sellado.", e);
            }
        }
        internal static string SignRetencion(byte[] pfx, string password, string xml)
        {
            try
            {
                X509Certificate2 x509Certificate = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                var nCertificate = SignUtils.CertificateNumber(x509Certificate);
                var certificate = Convert.ToBase64String(x509Certificate.GetRawCertData());
                xml = SignUtils.SignXml(xml, nCertificate, certificate);
                var originalString = GetCadenaOriginalRetencion(xml);
                var signResult = SignUtils.GetSignature(password, pfx, originalString, "SHA256");

                return SignUtils.SignXml(xml, signResult);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo realizar el sellado.", e);
            }
        }
        internal static string GetCadenaOriginal(string xml, string version = "4.0")
        {
            try
            {
                var xslt_cadenaoriginal = new XslCompiledTransform();
                if (version != "4.0")
                {
                    xslt_cadenaoriginal.Load(typeof(cadenaoriginal_3_3));
                }
                else
                {
                    xslt_cadenaoriginal.Load(typeof(cadenaoriginal_4_0));
                }
                return SignUtils.TransformXml(xslt_cadenaoriginal, xml);
            }
            catch (Exception e)
            {
                throw new Exception("El XML proporcionado no es válido.", e);
            }
        }
        internal static string GetCadenaOriginalRetencion(string xml)
        {
            try
            {
                var xslt_cadenaoriginal = new XslCompiledTransform();
                xslt_cadenaoriginal.Load(typeof(cadenaoriginal_retenciones_2_0));
                return SignUtils.TransformXml(xslt_cadenaoriginal, xml);
            }
            catch (Exception e)
            {
                throw new Exception("El XML proporcionado no es válido.", e);
            }
        }
        internal static string SignCancelacion(List<Cancelacion> folios, string rfcEmisor, byte[] pfx, string password, bool isRetencion)
        {
            try
            {
                string xml;
                xml = Xml.CreateCancelationXML(folios, rfcEmisor, isRetencion);
                return SignUtils.SignXml(xml, pfx, password);
            }
            catch(CryptographicException e)
            {
                throw new CryptographicException("Error al sellar el XML.", e);
            }
            catch(Exception e)
            {
                throw new Exception("Los folios no tienen un formato valido.", e);
            }
        }
        internal static void ValidarCancelacion(List<Cancelacion> folios)
        {
            if (folios.Count > 500)
            {
                throw new Exception("Se ha excedido el limite de folios a cancelar.");
            }
            if (folios.Any(l => l.Motivo == 0))
            {
                throw new Exception("No se ha especificado un motivo de cancelacion.");
            }
            if (folios.Any(l => l.Motivo == CancelacionMotivo.Motivo01 && l.FolioSustitucion is null))
            {
                throw new Exception("El motivo de cancelación no es válido.");
            }
            if (folios.Any(l => l.Folio == Guid.Empty)){
                throw new Exception("Los folios no tienen un formato válido.");
            }
        }
    }
}
