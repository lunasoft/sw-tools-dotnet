using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Text;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using System.Linq;

namespace SW.Tools
{
    public class Sign
    {
        #region Public 
        public static byte[] CrearPFX(byte[] bytesCER, byte[] bytesKEY, string password)
        {

            if (bytesCER == null || bytesKEY == null)
                throw new Exception("Empty cer and or key");

            var certificate = new Mono.Security.X509.X509Certificate(bytesCER);

            char[] arrayOfChars = password.ToCharArray();
            AsymmetricKeyParameter privateKey = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(arrayOfChars, bytesKEY);

            RSA subjectKey = DotNetUtilitiesCustom.ToRSA((RsaPrivateCrtKeyParameters)privateKey);

            Mono.Security.X509.PKCS12 p12 = new Mono.Security.X509.PKCS12();
            p12.Password = password;

            ArrayList list = new ArrayList();
            // we use a fixed array to avoid endianess issues 
            // (in case some tools requires the ID to be 1).
            list.Add(new byte[4] { 1, 0, 0, 0 });
            Hashtable attributes = new Hashtable(1);
            attributes.Add(Mono.Security.X509.PKCS9.localKeyId, list);
            p12.AddCertificate(certificate, attributes);
            p12.AddPkcs8ShroudedKeyBag(subjectKey, attributes);
            return p12.GetBytes();
        }
        public static string SellarCFDIv33(byte[] certificatePfx, string password, string xml)
        {
            X509Certificate2 x509Certificate = new X509Certificate2(certificatePfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            //Set values Certificate
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("NoCertificado", CertificateNumber(x509Certificate));
            doc.DocumentElement.SetAttribute("Certificado", Convert.ToBase64String(x509Certificate.GetRawCertData()));
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            //Get original string
            string originalString = CadenaOriginalCFDIv33(xml);
            //Sign Document
            var signResult = GetSignature(password, certificatePfx, originalString, "SHA256");
            //Set Values Signature
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
        public static string CadenaOriginalCFDIv33(string strXml)
        {
            var xslt_cadenaoriginal_3_3 = new XslCompiledTransform();
            xslt_cadenaoriginal_3_3.Load(typeof(cadenaoriginal_3_3));
            string resultado = null;
            StringWriter writer = new StringWriter();
            XmlReader xml = XmlReader.Create(new StringReader(strXml));
            xslt_cadenaoriginal_3_3.Transform(xml, null, writer);
            resultado = writer.ToString().Trim();
            writer.Close();

            return resultado;
        }
        #endregion
        #region Privates

        private static string GetSignature(string password, byte[] bytesCER, byte[] bytesKEY, string strToSign, string algorithm = "SHA1")
        {
            var pfx = CrearPFX(bytesCER, bytesKEY, password);
            return GetSignature(password, pfx, strToSign, algorithm);
        }
        private static string GetSignature(string password, byte[] pfx, string strToSign, string algorithm = "SHA1")
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
        private static string CertificateNumber(Mono.Security.X509.X509Certificate cert)
        {
            var sn = cert.SerialNumber;
            Array.Reverse(sn);
            string hexadecimalString = ToHexString(sn);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        private static string CertificateName(Mono.Security.X509.X509Certificate certificate)
        {
            string nameCertificate = "";
            string taxIdCertificate = "";
            string[] subjects = certificate.SubjectName.Trim().Split(',');
            foreach (var strTemp in subjects.ToList())
            {
                string[] strConceptoTemp = strTemp.Split('=');
                if (strConceptoTemp[0].Trim() == "OID.2.5.4.41")
                {
                    nameCertificate = strConceptoTemp[1].Trim().Split('/')[0];
                    //Bug Fix replace "
                    nameCertificate = nameCertificate.Replace("\"", "");
                }
                if (strConceptoTemp[0].Trim() == "OID.2.5.4.45")
                {
                    taxIdCertificate = strConceptoTemp[1].Trim().Split('/')[0];
                    //Bug Fix replace "
                    taxIdCertificate = taxIdCertificate.Replace("\"", "");
                }
            }
            return nameCertificate.Trim().ToUpper();
        }
        private static string CertificateTaxId(Mono.Security.X509.X509Certificate certificate)
        {
            string taxIdCertificate = "";
            string[] subjects = certificate.SubjectName.Trim().Split(',');
            foreach (var strTemp in subjects.ToList())
            {
                string[] strConceptoTemp = strTemp.Split('=');
                if (strConceptoTemp[0].Trim() == "OID.2.5.4.45")
                {
                    taxIdCertificate = strConceptoTemp[1].Trim().Split('/')[0];
                    //Bug Fix replace "
                    taxIdCertificate = taxIdCertificate.Replace("\"", "");
                    break;
                }
            }
            return taxIdCertificate.Trim().ToUpper();
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
        private static RSA ToRSA(RsaPrivateCrtKeyParameters privKey, int keySize)
        {
            RSAParameters rp = ToRSAParameters(privKey);
            CspParameters rsaParams = new CspParameters();
            rsaParams.Flags = CspProviderFlags.UseMachineKeyStore;
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(keySize, rsaParams);
            rsaCsp.ImportParameters(rp);
            return rsaCsp;
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
        #endregion
    }
}
