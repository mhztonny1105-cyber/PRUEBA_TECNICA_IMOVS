using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CompanyManagement.Api.Data;
using CompanyManagement.Api.Data.Repositories;
using CompanyManagement.Api.Mapping;
using CompanyManagement.Api.Services.Contracts;
using CompanyManagement.Api.Services.Implementations;


namespace CompanyManagement.Api.Configuration
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