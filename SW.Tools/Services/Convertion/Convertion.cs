using System;

namespace SW.Tools.Services.Convertion
{
    public class Convertion
    {
        public static string ConvertResponseToV4(string response)
        {
            try
            {
                if (String.IsNullOrEmpty(response))
                {
                    throw new Exception("No se ha recibido la respuesta.");
                }
                return ConvertionService.ConvertResponse(response);
            }
            catch(Exception e)
            {
                throw new Exception("Error en la conversion.", e);
            }
        }
    }
}
