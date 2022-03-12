﻿using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using SW.Tools.Helpers;
using System;
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
    }
}