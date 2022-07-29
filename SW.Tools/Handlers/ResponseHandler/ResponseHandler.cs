using SW.Tools.Entities.Response;
using SW.Tools.Helpers;
using System;
using System.Security.Cryptography;

namespace SW.Tools.Handlers.ResponseHandler
{
    internal class ResponseHandler
    {
        internal static Response HandleException(Exception ex, string message)
        {
            return ResponseHelper.GetResponse(ex.Message, ResponseHelper.GetErrorDetail(ex) ?? message);
        }
        internal static Response HandleException(CryptographicException ex, string message)
        {
            return ResponseHelper.GetResponse(ex.Message, ResponseHelper.GetErrorDetail(ex) ?? message);
        }
    }
}
