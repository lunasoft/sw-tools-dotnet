﻿using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using SW.Tools.Entities.Cancelacion;
using SW.Tools.Entities.Response;
using SW.Tools.Handlers.SignResponseHandler;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Xsl;

namespace SW.Tools.Services.Sign
{
    public class SignService
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
            catch (CryptographicException ex)
            {
                throw new CryptographicException("El certificado es inválido, se encuentra corrupto o la contraseña es incorrecta.", ex);
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
            catch (CryptographicException ex)
            {
                throw new CryptographicException("El certificado es inválido, se encuentra corrupto o la contraseña es incorrecta.", ex);
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
        internal static SignResponse SignAceptacionRechazo(List<AceptacionRechazo> aceptacionRechazo, string rfcReceptor, byte[] pfx, string password)
        {
            try
            {
                Validation.ValidarAceptacionRechazo(aceptacionRechazo, rfcReceptor, pfx, password);
                string xml = Xml.CreateAcceptRejectXML(aceptacionRechazo, rfcReceptor);
                xml = SignUtils.SignXml(xml, pfx, password);
                return new SignResponse()
                {
                    data = new SignDataResponse()
                    {
                        xml = xml
                    }
                };
            }
            catch (XmlException e)
            {
                return SignResponseHandler.HandleException(e, "Ocurrió un error al construir el XML.");
            }
            catch (CryptographicException e)
            {
                return SignResponseHandler.HandleException(e, "El certificado es inválido, se encuentra corrupto o la contraseña es incorrecta.");
            }
            catch (Exception e)
            {
                return SignResponseHandler.HandleException(e);
            }
        }
        internal static SignResponse SignXml(string xml, byte[] pfx, string password)
        {
            try
            {
                return new SignResponse()
                {
                    data = new SignDataResponse()
                    {
                        xml = SignUtils.SignXml(xml, pfx, password)
                    }
                };
            }
            catch (XmlException e)
            {
                return SignResponseHandler.HandleException(e, "El XML no es válido o no tiene un formato correcto.");
            }
            catch (CryptographicException e)
            {
                return SignResponseHandler.HandleException(e, "El certificado es inválido, se encuentra corrupto o la contraseña es incorrecta.");
            }
            catch (Exception e)
            {
                return SignResponseHandler.HandleException(e);
            }
        }
    }
}
