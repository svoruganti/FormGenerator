using Autofac;
using FormGenerator.Mapper;

namespace FormGenerator.DI
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FormMapper>().As<IFormMapper>();
        }
    }
}