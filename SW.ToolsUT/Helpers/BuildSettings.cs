using System.IO;

namespace SW.ToolsUT.Helpers
{
    class BuildSettings
    {
        public string Url = "http://services.test.sw.com.mx";
        public string UrlApi = "http://api.test.sw.com.mx";
        public string Token = @"T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbXB3YVZxTHdOdHAwVXY2NTdJb1hkREtXTzE3dk9pMmdMdkFDR2xFWFVPUXpTUm9mTG1ySXdZbFNja3FRa0RlYURqbzdzdlI2UUx1WGJiKzViUWY2dnZGbFloUDJ6RjhFTGF4M1BySnJ4cHF0YjUvbmRyWWpjTkVLN3ppd3RxL0dJPQ.T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbFlVcU92YUJTZWlHU3pER1kySnlXRTF4alNUS0ZWcUlVS0NhelhqaXdnWTRncklVSWVvZlFZMWNyUjVxYUFxMWFxcStUL1IzdGpHRTJqdS9Zakw2UGRDN2VkNEVBUGM1UUt3NVhZVC9QUTViWmZ6dGNJUG5JZVJ1d1hPdmFlN2s3cEp3UW5UY2hORXVWeS9mNnZ6YVZQTlg1OTdBbWJUNzJ4NHFJNVJnOFBxTEo3TGQwank2dlVwektHUmJwY2RqNGdYRG5yaTVZUTBaZ05vR1Y0Z0xsNzg5MlM0cWJUK2hRamV2bXUwcFVGM3E4SzZMNFkvVE5LTCtJZFFEVHNob05QVmRzY2dSUGxBUXBoc29JcVp1TW9MV1FkUUtTRVdROVNPTVRMYkg5dmIrM25LM3pRbDBKN2RHaEI5TDZLK2hqVUhJU3RsZ3dEeGc0NnlWUXUvZEpmc3F6c1pNZHF4YitvYzhLQ1BSWW1vejE2ZGNNVHdETitIckl3OGhVRXFSZFFGY2lQSktqQW5LRWdCNm1jT2VzQmR4TWxFRXg1NTFXZ1UzSGNobTNXbGtUaUo5cmNucnYrWXM5cVQ0Q0NlODFPaldKZjVTRHR6alNodjc0VFgwZGE.loaXVczHpJjV8E_3NYByEmxRJKHFCS0qHPOr7LJKtPM";
        public byte[] BytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
        public byte[] BytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
        public string CerPassword = "12345678a";
        public string RfcEmisor = "EKU9003173C9";
    }
}
