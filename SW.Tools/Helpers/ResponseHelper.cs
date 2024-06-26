﻿using SW.Tools.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.Tools.Helpers
{
    internal class ResponseHelper<T> where T : Exception, new()
    {
        internal static string GetErrorDetail(T e)
        {
            return TryGetErrorDetail(e);
        }
        private static string TryGetErrorDetail(T e)
        {
            if (e.InnerException != null)
                return e.InnerException.Message;
            else
                return null;
        }
    }
}
