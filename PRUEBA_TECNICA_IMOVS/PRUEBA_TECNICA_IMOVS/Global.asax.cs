using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Data.Entity;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Migrations;

namespace PRUEBA_TECNICA_IMOVS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
            
            using (var context = new Context())
            {
                context.Database.Initialize(force: true);
            }

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteTable.Routes.MapPageRoute("Default", "", "~/Index.aspx");
        }
    }
}
