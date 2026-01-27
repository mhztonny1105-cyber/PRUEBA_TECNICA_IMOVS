using PRUEBA_TECNICA_IMOVS.Services.Implementations;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PRUEBA_TECNICA_IMOVS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ITicketService, TicketService>();
            container.RegisterType<IPaymentService, PaymentService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}