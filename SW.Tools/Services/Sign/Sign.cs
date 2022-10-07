using SW.Tools.Entities.Cancelacion;
using SW.Tools.Entities.Response;
using SW.Tools.Handlers.SignResponseHandler;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.Tools.Services.Sign
{
    public class Sign : SignService
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
        public static SignResponse SellarCFDIv33(byte[] certificatePfx, string password, string xml)
        {
          
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return new SignResponse
                {
                    data = new SignDataResponse() { xml = SignService.SignCfdi(certificatePfx, password, xml, "3.3") }

                };
            }
            catch (Exception ex)
            {
                return SignResponseHandler.HandleException(ex);
            }

        }
        /// <summary>
        /// Sellar XML CFDI 4.0
        /// </summary>
        /// <param name="certificatePfx">Certificado PFX</param>
        /// <param name="password">Contrasena PFX</param>
        /// <param name="xml">XML a sellar</param>
        /// <returns></returns>
        public static SignResponse SellarCFDIv40(byte[] certificatePfx, string password, string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return new SignResponse
                {
                    data = new SignDataResponse() { xml = SignService.SignRetencion(certificatePfx, password, xml) }

                };
            }
            catch (Exception ex)
            {
                return SignResponseHandler.HandleException(ex);
            }
        }
        /// <summary>
        /// Sellar XML Retenciones 2.0
        /// </summary>
        /// <param name="certificatePfx">Certificado PFX</param>
        /// <param name="password">Contrasena PFX</param>
        /// <param name="xml">XML a sellar</param>
        /// <returns></returns>
        public static SignResponse SellarRetencionv20(byte[] certificatePfx, string password, string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return new SignResponse
                {
                    data = new SignDataResponse() { xml = SignService.SignRetencion(certificatePfx, password, xml) }
                    
                };
            }
            catch (Exception ex)
            {
                return SignResponseHandler.HandleException(ex);
            }
            
        }
        /// <summary>
        /// Obtener cadena original CFDI 3.3
        /// </summary>
        /// <param name="strXml">XML</param>
        /// <returns></returns>
        public static SignResponseV2 CadenaOriginalCFDIv33(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return new SignResponseV2()
                {
                    data = new SignDataResponseV2() { cadenaOriginal = SignService.GetCadenaOriginal(xml, "3.3") }
            };
            }
            catch (Exception ex)
            {
                return SignResponseHandlerV2.HandleException(ex);
            }
        }
        /// <summary>
        /// Obtener cadena original CFDI 4.0
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static SignResponseV2 CadenaOriginalCFDIv40(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
               
                return new SignResponseV2()
                {
                    data = new SignDataResponseV2() { cadenaOriginal = SignService.GetCadenaOriginal(xml) }

                };
            }
            catch (Exception ex)
            {
                return  SignResponseHandlerV2.HandleException(ex);
            }
        }
        /// <summary>
        /// Obtener cadena original Retencion 2.0
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static SignResponseV2 CadenaOriginalRetencionv20(string xml)
        {
            try
            {
                xml = Fiscal.Fiscal.RemoverCaracteresInvalidosXml(xml);
                return new SignResponseV2()
                {
                    data = new SignDataResponseV2() { cadenaOriginal = SignService.GetCadenaOriginalRetencion(xml) }

                };
            }
            catch (Exception ex)
            {
                return SignResponseHandlerV2.HandleException(ex);
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
        public static SignResponse SellarCancelacion(List<Cancelacion> folios, string rfcEmisor, byte[] pfx, string password, bool isRetencion = false)
        {
            try
            {
                if (folios.Count > 0)
                {
                    Validation.ValidarCancelacion(folios);
                    return new SignResponse() { data = new SignDataResponse() { xml = SignService.SignCancelacion(folios, rfcEmisor, pfx, password, isRetencion) } };
                }
                throw new Exception("El listado de folios esta vacio.");
            }
            catch(Exception ex)
            {
                return SignResponseHandler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio para crear y firmar un XML de aceptacion rechazo de folios pendientes de cancelación.
        /// </summary>
        /// <param name="folios">Listado de folios pendientes de aceptación o rechazo.</param>
        /// <param name="rfcReceptor">RFC del receptor.</param>
        /// <param name="pfx">Certificado PFX.</param>
        /// <param name="password">Contraseña del certificado PFX.</param>
        /// <returns>Un objeto <see cref="SignResponse"/></returns>
        public static SignResponse SellarAceptacionRechazo(List<AceptacionRechazo> folios, string rfcReceptor, byte[] pfx, string password)
        {
            return SignAceptacionRechazo(folios, rfcReceptor, pfx, password);
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
