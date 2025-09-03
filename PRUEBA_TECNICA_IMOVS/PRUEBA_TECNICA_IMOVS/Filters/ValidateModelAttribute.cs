using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using PRUEBA_TECNICA_IMOVS.Api.Models.Responses;


namespace PRUEBA_TECNICA_IMOVS.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                ApiResponse<object>.Fail("Datos inválidos."));
            }
        }
    }
}