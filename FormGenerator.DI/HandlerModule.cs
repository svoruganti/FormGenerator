using Autofac;
using FormGenerator.Handler;

namespace FormGenerator.DI
{
    public class HandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FormGeneratorHandler>().As<IFormGeneratorHandler>();
        }
    }
}