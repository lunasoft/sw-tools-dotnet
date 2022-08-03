using SW.Tools.Entities.Response;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Handlers
{
    internal class ResponseHandler<T> where T : Response, new ()
    {
        internal static T GetResponse(Exception e)
        {
            return TryGetResponse(e);
        }
        internal static T GetResponse(CryptographicException e)
        {
            return TryGetResponse(e);
        }
        private static T TryGetResponse(Exception e)
        {
            return new T()
            {
                status = "error",
                message = e.Message,
                messageDetail = ResponseHelper<Exception>.GetErrorDetail(e)
            };
        }
        private static T TryGetResponse(CryptographicException e)
        {
            return new T()
            {
                status = "error",
                message = e.Message,
                messageDetail = ResponseHelper<CryptographicException>.GetErrorDetail(e)
            };
        }
    }
}
