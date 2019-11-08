using Autofac;
using DemoCleanArchitecture.WebApi.UseCases.Customer;

namespace WebApi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CustomerPresenter>().As<Application.Boundaries.Customer.IOutPutPort>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
