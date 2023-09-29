using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.SharedComponents.Repositorio
{
    public class HttpResponseWrapper<T>
    {
        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string?> GetErrorMessage()
        {
            if(!Error) return null;

            var statusCode = HttpResponseMessage.StatusCode;

            if(statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";

            }else if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();

            }else if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Se requiere estar logueado para realizar esta operación.";

            }else if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para realizar  esta operación";
            }

            return "Ocurrió un error inesperado";
        }
    }
}
