using System;
using System.IO;

namespace SW.ToolsUT.Helpers
{
    class BuildSettings
    {
        public string Url = "http://services.test.sw.com.mx";
        public string UrlApi = "http://api.test.sw.com.mx";
        public string Token = Environment.GetEnvironmentVariable("SDKTEST_TOKEN");
        public byte[] BytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
        public byte[] BytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
        public string CerPassword = "12345678a";
        public string RfcEmisor = "EKU9003173C9";
        public string User = Environment.GetEnvironmentVariable("SDKTEST_USER");
        public string Password = Environment.GetEnvironmentVariable("SDKTEST_PASSWORD");
    }
}
