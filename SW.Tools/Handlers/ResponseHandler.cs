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
        internal static T GetResponse(Exception e, string message)
        {
            return TryGetResponse(e, message);
        }
        private static T TryGetResponse(Exception e, string message = null)
        {
            return new T()
            {
                status = "error",
                message = message ?? e.Message,
                messageDetail = ResponseHelper<Exception>.GetErrorDetail(e)
            };
        }
    }
}
