namespace RegistroEstudianteWeb.Api.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Se ha realizado una solicitud no valida",
                401 => "No estas autorizado para este recurso",
                404 => "Recurso No encontrado",
                500 => "Error interno del Servidor",
                _ => null
            };
        }
    }
}
