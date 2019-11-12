using Autofac;
using WebApi.UseCases.Comment;
using WebApi.UseCases.Topic;
using WebApi.UseCases.User;

namespace WebApi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UserPresenter>().As<Application.Boundaries.User.IOutputPortUser>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TopicPresenter>().As<Application.Boundaries.Topic.IOutputPortTopic>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CommentPresenter>().As<Application.Boundaries.Comment.IOutputPortComment>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
