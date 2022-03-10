using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace SW.Tools.Helpers
{
    internal static class SignUtils
    {
        internal static byte[] CreatePFX(byte[] bytesCER, byte[] bytesKEY, string password)
        {
            try
            {
                var certificate = new X509Certificate2(bytesCER, password);

                char[] arrayOfChars = password.ToCharArray();
                AsymmetricKeyParameter privateKey = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(arrayOfChars, bytesKEY);
                RSACryptoServiceProvider subjectKey = ToRSA((RsaPrivateCrtKeyParameters)privateKey);
                certificate.PrivateKey = subjectKey;
                return certificate.Export(X509ContentType.Pfx, password);
            }
            catch(Exception e)
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
                var nCertificate = CertificateNumber(x509Certificate);
                var certificate = Convert.ToBase64String(x509Certificate.GetRawCertData());
                xml = SignXml(xml, nCertificate, certificate);
                var originalString = version != "4.0" ? GetCadenaOriginal(xml, "3.3") : GetCadenaOriginal(xml);
                var signResult = GetSignature(password, pfx, originalString, "SHA256");

                return SignXml(xml, signResult);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo realizar el sellado.", e);
            }
        }
        public static RSACryptoServiceProvider ToRSA(RsaPrivateCrtKeyParameters privKey)
        {
            return CreateRSAProvider(ToRSAParameters(privKey));
        }
        private static RSACryptoServiceProvider CreateRSAProvider(RSAParameters rp)
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = string.Format("BouncyCastle-{0}", Guid.NewGuid());
            csp.Flags = CspProviderFlags.UseMachineKeyStore;
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
            rsaCsp.ImportParameters(rp);
            return rsaCsp;
        }
        
        internal static string SignRetencion(byte[] pfx, string password, string xml)
        {
            try
            {
                X509Certificate2 x509Certificate = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                var nCertificate = CertificateNumber(x509Certificate);
                var certificate = Convert.ToBase64String(x509Certificate.GetRawCertData());
                xml = SignXml(xml, nCertificate, certificate);
                var originalString = GetCadenaOriginalRetencion(xml);
                var signResult = GetSignature(password, pfx, originalString, "SHA256");
                
                return SignXml(xml, signResult);
            }
            catch(Exception e)
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
                return TransformXml(xslt_cadenaoriginal, xml);
            }
            catch(Exception e)
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
                return TransformXml(xslt_cadenaoriginal, xml);
            }
            catch (Exception e)
            {
                throw new Exception("El XML proporcionado no es válido.", e);
            }
        }
        internal static string GetCadenaOriginalTfd(string xml)
        {
            try
            {
                var xslt_cadenaoriginal = new XslCompiledTransform();
                xslt_cadenaoriginal.Load(typeof(cadenaoriginal_TFD_1_1));
                return TransformXml(xslt_cadenaoriginal, xml);
            }
            catch(Exception e)
            {
                throw new Exception("El XML proporcionado no es valido.", e);
            }
        }
        internal static string TransformXml(XslCompiledTransform xslt, string xml)
        {
            StringWriter writer = new StringWriter();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            xslt.Transform(xmlReader, null, writer);
            string resultado = writer.ToString().Trim();
            writer.Close();

            return resultado;
        }
        private static string SignXml(string xml, string nCertificate, string certificate)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("NoCertificado", nCertificate);
            doc.DocumentElement.SetAttribute("Certificado", certificate);
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            return xml;
        }
        private static string SignXml(string xml, string signResult)
        {
            XmlDocument doc = new XmlDocument();
            doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Sello", signResult);
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            return xml;
        }
        private static string GetSignature(string password, byte[] pfx, string strToSign, string algorithm)
        {
            var signData = string.Empty;
            RSACryptoServiceProvider rsa = default(RSACryptoServiceProvider);
            byte[] signatureBytes = default(byte[]);
            X509Certificate2 certX509 = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(certX509.PrivateKey.ToXmlString(true));

            byte[] data = Encoding.UTF8.GetBytes(strToSign);

            signatureBytes = rsa.SignData(data, CryptoConfig.MapNameToOID(algorithm));
            return Convert.ToBase64String(signatureBytes);
        }

        private static string CertificateNumber(X509Certificate2 cert)
        {
            string hexadecimalString = cert.SerialNumber;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        private static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
        {
            RSAParameters rp = new RSAParameters();
            rp.Modulus = privKey.Modulus.ToByteArrayUnsigned();
            rp.Exponent = privKey.PublicExponent.ToByteArrayUnsigned();
            rp.D = privKey.Exponent.ToByteArrayUnsigned();
            rp.P = privKey.P.ToByteArrayUnsigned();
            rp.Q = privKey.Q.ToByteArrayUnsigned();
            rp.DP = privKey.DP.ToByteArrayUnsigned();
            rp.DQ = privKey.DQ.ToByteArrayUnsigned();
            rp.InverseQ = privKey.QInv.ToByteArrayUnsigned();
            return rp;
        }
        private static string ToHexString(byte[] data)
        {
            if (data != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2"));
                return sb.ToString();
            }
            else
                return null;
        }
    }
}
