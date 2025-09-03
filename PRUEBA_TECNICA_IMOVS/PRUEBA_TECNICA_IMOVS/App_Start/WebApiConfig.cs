using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Api.Configuration;
using PRUEBA_TECNICA_IMOVS.Api.Filters;


namespace PRUEBA_TECNICA_IMOVS.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rutas por atributo
            config.MapHttpAttributeRoutes();


            // Filtros
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new GlobalExceptionFilter());


            // JSON
            JsonConfig.Configure(config);


            // DI
            AutofacConfig.Register(config);
        }
    }
}