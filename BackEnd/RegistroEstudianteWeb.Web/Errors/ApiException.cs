﻿namespace RegistroEstudianteWeb.Api.Errors
{
    public class ApiException: ApiErrorResponse
    {
        public ApiException(int statusCode, string message=null, string details=null):base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; } 
    }
}
