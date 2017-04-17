using Autofac;
using FormGenerator.Repository;

namespace FormGenerator.DI
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<FormGeneratorRepository>().As<IFormGeneratorRepository>();
        }
    }
}