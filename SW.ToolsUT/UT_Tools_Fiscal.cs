using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace SW.ToolsUT
{
    [TestClass]
    public class UT_Tools_Fiscal
    {
        /// <summary>
        /// Fiscal
        /// </summary>
        [TestMethod]
        public void UT_Tools_GetSignature_OK()
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml"));
            var result = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml(xml);
            Assert.IsFalse(result.Contains("\r"));
        }
        [TestMethod]
        public void UT_Tools_GetSignature_ERROR()
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml"));
            var result = SW.Tools.Fiscal.RemoverCaracteresInvalidosXml(xml);
            Assert.IsFalse(result == xml);
        }
        [TestMethod]
        public void UT_Tools_ValidarRfc_OK()
        {
            
            var result = SW.Tools.Fiscal.ValidarRfc("COSE860610K59");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UT_Tools_ValidarRfc_ERROR()
        {
            var result = SW.Tools.Fiscal.ValidarRfc("COS1860610K59");
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void UT_Tools_AntiguedadSemanas_Ok()
        {
            string dateFrom = "01/08/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "01/08/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = SW.Tools.Fiscal.AntiguedadSemanas(dtFrom, dtTo);
            Assert.IsTrue(result.Contains("P"));
        }
        [TestMethod]
        public void UT_Tools_AntiguedadSemanas_Error()
        {
            string dateFrom = "08/01/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "07/01/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = SW.Tools.Fiscal.AntiguedadSemanas(dtFrom, dtTo);
            Assert.IsTrue(result.Contains("-"));
        }

        [TestMethod]
        public void UT_Tools_AntiguedadAnosMesesDias_Ok()
        {
            string dateFrom = "06/01/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "08/01/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);

            var result = SW.Tools.Fiscal.AntiguedadAnosMesesDias(dtFrom, dtTo);
            Assert.IsTrue(result.Contains("P2M1D"));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Date ranges are not valid.")]
        public void UT_Tools_AntiguedadAnosMesesDias_ERROR()
        {
            string dateFrom = "09/09/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "08/08/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = SW.Tools.Fiscal.AntiguedadAnosMesesDias(dtFrom, dtTo);
            Assert.IsTrue(result.ToString() != null);
        }
    }
}
