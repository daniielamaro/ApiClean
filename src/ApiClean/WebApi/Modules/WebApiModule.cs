using Autofac;
using WebApi.UseCases.Topic;

namespace WebApi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<TopicPresenter>().As<Application.Boundaries.Topic.IOutputPortTopic>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
