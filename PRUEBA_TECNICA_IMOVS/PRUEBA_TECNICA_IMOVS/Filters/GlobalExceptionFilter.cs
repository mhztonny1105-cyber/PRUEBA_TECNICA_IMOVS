using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using PRUEBA_TECNICA_IMOVS.Api.Models.Responses;


namespace PRUEBA_TECNICA_IMOVS.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var message = context.Exception is InvalidOperationException
            ? context.Exception.Message
            : "Ocurrió un error inesperado.";


            var status = context.Exception is InvalidOperationException
            ? HttpStatusCode.BadRequest
            : HttpStatusCode.InternalServerError;


            context.Response = context.Request.CreateResponse(status, ApiResponse<object>.Fail(message));
        }
    }
}