using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using PRUEBA_TECNICA_IMOVS.Api.Data;
using PRUEBA_TECNICA_IMOVS.Api.Data.Repositories;
using PRUEBA_TECNICA_IMOVS.Api.Mapping;
using PRUEBA_TECNICA_IMOVS.Api.Services.Contracts;
using PRUEBA_TECNICA_IMOVS.Api.Services.Implementations;


namespace PRUEBA_TECNICA_IMOVS.Api.Configuration
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();


            // Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            // DbContext (per-request)
            builder.RegisterType<AppDbContext>().InstancePerRequest();


            // Genérico repos
            builder.RegisterGeneric(typeof(GenericRepository<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerRequest();


            // Services
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<TicketService>().As<ITicketService>().InstancePerRequest();
            builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerRequest();


            // AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            builder.RegisterInstance(mapperConfig.CreateMapper()).As<IMapper>().SingleInstance();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}