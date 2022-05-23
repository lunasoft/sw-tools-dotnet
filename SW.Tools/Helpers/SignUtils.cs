using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using SW.Tools.Services.Fiscal;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace SW.Tools.Helpers
{
    internal static class SignUtils
    {
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
        internal static string SignXml(string xml, string nCertificate, string certificate, bool isRetencion10 = false)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (isRetencion10)
            {
                doc.DocumentElement.SetAttribute("NumCert", nCertificate);
                doc.DocumentElement.SetAttribute("Cert", certificate);
            } else
            {
                doc.DocumentElement.SetAttribute("NoCertificado", nCertificate);
                doc.DocumentElement.SetAttribute("Certificado", certificate);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            return xml;
        }
        internal static string SignXml(string xml, string signResult)
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
        internal static string SignXml(string xml, byte[] pfx, string password)
        {
            XmlDocument originalXmlDocument = new XmlDocument() { PreserveWhitespace = false };
            originalXmlDocument.LoadXml(xml);
            XmlElement signatureElement = GetSignature(originalXmlDocument, pfx, password);
            originalXmlDocument.DocumentElement.AppendChild(originalXmlDocument.ImportNode(signatureElement, true));
            return originalXmlDocument.OuterXml;
        }
        internal static XmlElement GetSignature(XmlDocument originalXmlDocument, byte[] pfx, String pfxPassword)
        {
            X509Certificate2 cert = new X509Certificate2(pfx, pfxPassword);
            RSACryptoServiceProvider Key = cert.PrivateKey as RSACryptoServiceProvider;
            SignedXml signedXml = new SignedXml(originalXmlDocument) { SigningKey = Key };
            Reference reference = new Reference() { Uri = String.Empty };
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);
            KeyInfoX509Data kdata = new KeyInfoX509Data(cert);
            kdata.AddIssuerSerial(cert.Issuer, cert.SerialNumber);
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(kdata);
            signedXml.KeyInfo = keyInfo;
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();
            return signedXml.GetXml();
        }
        internal static string GetSignature(string password, byte[] pfx, string strToSign, string algorithm)
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
        internal static string CertificateNumber(X509Certificate2 cert)
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
