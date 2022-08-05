using SW.Tools.Entities.Cancelacion;
using SW.Tools.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// Obtener cadena original Retencion 2.0
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string CadenaOriginalRetencionv20(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return SignService.GetCadenaOriginalRetencion(xml);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Crear y sellar XML de cancelacion
        /// </summary>
        /// <param name="folios">Lista de folios a cancelar con el formato uuid,motivo,uuidSustitucion</param>
        /// <param name="rfcEmisor">RFC Emisor</param>
        /// <param name="pfx">Certificado PFX</param>
        /// <param name="password">Contrasena certificado PFX</param>
        /// <param name="isRetencion">Especifica si es un XML de retencion</param>
        /// <returns></returns>
        public static string SellarCancelacion(List<Cancelacion> folios, string rfcEmisor, byte[] pfx, string password, bool isRetencion = false)
        {
            try
            {
                if (folios.Count > 0)
                {
                    SignService.ValidarCancelacion(folios);
                    return SignService.SignCancelacion(folios, rfcEmisor, pfx, password, isRetencion);
                }
                throw new Exception("El listado de folios esta vacio.");
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Firmar un XML previamente creado, se puede firmar los documentos: 
        /// <para>Cancelacion, Aceptacion Rechazo</para>
        /// </summary>
        /// <param name="xml">XML al que se le aplicará la firma o signature.</param>
        /// <param name="pfx">Certificado PFX.</param>
        /// <param name="password">Contraseña del certificado PFX.</param>
        /// <returns>Un objeto <see cref="SignResponse"/></returns>
        public static SignResponse FirmarXML(string xml, byte[] pfx, string password)
        {
            return SignService.SignXml(xml, pfx, password);
        }
        #endregion
    }
}
