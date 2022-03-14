using System;

namespace SW.Tools.Services.Sign
{
    public class Sign
    {
        #region Public 
        /// <summary>
        /// Crear PFX
        /// </summary>
        /// <param name="bytesCER">Certificado CSD</param>
        /// <param name="bytesKEY">Key</param>
        /// <param name="password">Contrasena certificado</param>
        /// <returns></returns>
        public static byte[] CrearPFX(byte[] bytesCER, byte[] bytesKEY, string password)
        {
            if (bytesCER == null || bytesKEY == null)
            {
                throw new Exception("Empty cer and or key");
            }
            try
            {
                return SignService.CreatePFX(bytesCER, bytesKEY, password);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Sellar XML CFDI 3.3
        /// </summary>
        /// <param name="certificatePfx">Certificado PFX</param>
        /// <param name="password">Contrasena PFX</param>
        /// <param name="xml">XML a sellar</param>
        /// <returns></returns>
        public static string SellarCFDIv33(byte[] certificatePfx, string password, string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.SignCfdi(certificatePfx, password, xml, "3.3");
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Sellar XML CFDI 4.0
        /// </summary>
        /// <param name="certificatePfx">Certificado PFX</param>
        /// <param name="password">Contrasena PFX</param>
        /// <param name="xml">XML a sellar</param>
        /// <returns></returns>
        public static string SellarCFDIv40(byte[] certificatePfx, string password, string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.SignCfdi(certificatePfx, password, xml);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Sellar XML Retenciones 2.0
        /// </summary>
        /// <param name="certificatePfx">Certificado PFX</param>
        /// <param name="password">Contrasena PFX</param>
        /// <param name="xml">XML a sellar</param>
        /// <returns></returns>
        public static string SellarRetencionv20(byte[] certificatePfx, string password, string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.SignRetencion(certificatePfx, password, xml);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Obtener cadena original CFDI 3.3
        /// </summary>
        /// <param name="strXml">XML</param>
        /// <returns></returns>
        public static string CadenaOriginalCFDIv33(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.GetCadenaOriginal(xml, "3.3");
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Obtener cadena original CFDI 4.0
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static string CadenaOriginalCFDIv40(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.GetCadenaOriginal(xml);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
