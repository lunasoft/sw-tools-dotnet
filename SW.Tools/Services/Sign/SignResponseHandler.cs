using SW.Tools.Entities.Response;
using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Handlers.SignResponseHandler
{
    internal class SignResponseHandler : ResponseHandler<SignResponse> 
    {
        internal static SignResponse HandleException(Exception e)
        {
            return GetResponse(e);
        }
        internal static SignResponse HandleException(Exception e, string message)
        {
            return GetResponse(e, message);
        }      
    }
    internal class SignResponseHandlerV2 : ResponseHandler<SignResponseV2>
    {
        internal static SignResponseV2 HandleException(Exception e)
        {
            return GetResponse(e);
        }
        internal static SignResponseV2 HandleException(Exception e, string message)
        {
            return GetResponse(e, message);
        }
    }

}
