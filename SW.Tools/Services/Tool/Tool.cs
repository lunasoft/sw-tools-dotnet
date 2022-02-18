using SW.Tools.Services.Tool;
using System;

namespace SW.Tool
{
    public static class Tool
    {
        public static string ConvertResponseToV4(string response)
        {
            try
            {
                if (String.IsNullOrEmpty(response))
                {
                    return "El response no es valido.";
                }
                return ToolService.ConvertResponse(response);
            }
            catch(Exception e)
            {
                throw new Exception("Error en la conversion.", e);
            }
        }
    }
}
