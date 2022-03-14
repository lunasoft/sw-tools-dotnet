using System;

namespace SW.Tools.Services.Convertion
{
    public class Convertion
    {
        /// <summary>
        /// Convertir respuesta de timbrado V2 a V4
        /// </summary>
        /// <param name="response">Respuesta V2</param>
        /// <returns></returns>
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
            catch
            {
                throw;
            }
        }
    }
}
