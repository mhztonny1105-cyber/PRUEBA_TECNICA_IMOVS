

using PRUEBA_TECNICA_IMOVS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace PRUEBA_TECNICA_IMOVS.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ArgumentException)
            {
                context.Response = context.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    ApiResponse<string>.Fail(context.Exception.Message)
                );
                return;
            }

            if (context.Exception is KeyNotFoundException)
            {
                context.Response = context.Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    ApiResponse<string>.Fail(context.Exception.Message)
                );
                return;
            }

            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                ApiResponse<string>.Fail("Ocurrió un error inesperado")
            );
        }


    }
}
