using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Tools.Services.Certificate;
using SW.ToolsUT.Helpers;
using System;
using System.IO;

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_Certificate
    {
        BuildSettings _build;
        public UT_Tools_Certificate()
        {
            _build = new BuildSettings();
        }
        #region UT_VerificarTipoCertificado
        /// <summary>
        /// El certificado es un CSD.
        /// </summary>
        [TestMethod]
        public void VerificarTipoCertificado_CSD_Success()
        {
            var result = Certificate.VerificarTipoCertificado(_build.BytesCer);
            Assert.IsTrue(result.status.Equals("success"));
            Assert.IsTrue(result.data.Contains("CSD"));
        }
        /// <summary>
        /// El certificado es una FIEL.
        /// </summary>
        [TestMethod]
        public void VerificarTipoCertificado_FIEL_Success()
        {
            var result = Certificate.VerificarTipoCertificado(GetCertificate(@"Resources/certificadoFIEL.cer"));
            Assert.IsTrue(result.status.Equals("success"));
            Assert.IsTrue(result.data.Contains("FIEL"));
        }
        /// <summary>
        /// El certificado no es CSD ni FIEL.
        /// </summary>
        [TestMethod]
        public void VerificarTipoCertificado_NoCSD_Error()
        {
            var result = Certificate.VerificarTipoCertificado(GetCertificate(@"Resources/certificadoNoCSD.cer"));
            Assert.IsTrue(result.status.Equals("error"));
            Assert.IsTrue(result.data.Contains("El certificado no es CSD ni FIEL"));
        }
        /// <summary>
        /// El certificado es inválido.
        /// </summary>
        [TestMethod]
        public void VerificarTipoCertificado_InvalidCertificate_Error()
        {
            var result = Certificate.VerificarTipoCertificado(_build.BytesKey);
            Assert.IsTrue(result.status.Equals("error"));
            Assert.IsTrue(String.IsNullOrEmpty(result.data));
        }
        #endregion
        #region UT_LeerCertificado
        /// <summary>
        /// Leer certificado correcto.
        /// </summary>
        [TestMethod]
        public void LeerCertificado_Success()
        {
            var result = Certificate.LeerCertificado(_build.BytesCer);
            Assert.IsTrue(result.status.Equals("success"));
            Assert.IsTrue(result.data != null);
            Assert.IsTrue(!String.IsNullOrEmpty(result.data.serialNumber));
            Assert.IsTrue(!String.IsNullOrEmpty(result.data.issuer));
            Assert.IsTrue(!String.IsNullOrEmpty(result.data.certificateNumber));
            Assert.IsTrue(!String.IsNullOrEmpty(result.data.commonName));
            Assert.IsTrue(result.data.validFrom != null);
            Assert.IsTrue(result.data.validTo != null);
        }
        /// <summary>
        /// Leer certificado invalido.
        /// </summary>
        [TestMethod]
        public void LeerCertificado_Error()
        {
            var result = Certificate.LeerCertificado(_build.BytesKey);
            Assert.IsTrue(result.status.Equals("error"));
            Assert.IsTrue(result.data is null);
        }
        #endregion
        #region Private
        private static byte[] GetCertificate(string path)
        {
            return File.ReadAllBytes(path); 
        }
        #endregion
    }
}
