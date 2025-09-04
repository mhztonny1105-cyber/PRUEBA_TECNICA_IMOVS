using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Configuración de atributos de ruta de Web API
            config.MapHttpAttributeRoutes();

            // Rutas de Web API
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configurar JSON como formato predeterminado
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}