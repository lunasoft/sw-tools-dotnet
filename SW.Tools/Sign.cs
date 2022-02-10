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
using SW.Tools.Helpers;

namespace SW.Tools
{
    public class Sign
    {
        #region Public 
        public static byte[] CrearPFX(byte[] bytesCER, byte[] bytesKEY, string password)
        {
            if (bytesCER == null || bytesKEY == null)
            {
                throw new Exception("Empty cer and or key");
            }
                
            return SignUtils.CreatePFX(bytesCER, bytesKEY, password);
        }
        public static string SellarCFDIv33(byte[] certificatePfx, string password, string xml)
        {
            xml = Fiscal.RemoverCaracteresInvalidosXml(xml);
            
            return SignUtils.SignCfdi(certificatePfx, password, xml, "3.3");
        }
        public static string SellarCFDIv40(byte[] certificatePfx, string password, string xml)
        {
            xml = Fiscal.RemoverCaracteresInvalidosXml(xml);

            return SignUtils.SignCfdi(certificatePfx, password, xml);
        }
        public static string CadenaOriginalCFDIv33(string strXml)
        {
            try
            {
                return SignUtils.GetCadenaOriginal(strXml, "3.3");
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
        public static string CadenaOriginalCFDIv40(string strXml)
        {
            try
            {
                return SignUtils.GetCadenaOriginal(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception("El XML proporcionado no es válido.", ex);
            }
        }
        #endregion
    }
}
