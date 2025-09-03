using System.Web.Http;
using CompanyManagement.Api.Configuration;
using CompanyManagement.Api.Filters;


namespace CompanyManagement.Api
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