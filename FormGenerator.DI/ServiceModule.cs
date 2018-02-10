using Autofac;
using FormGenerator.Service;
using FormGenerator.Service.Interface;
using Module = Autofac.Module;

namespace FormGenerator.DI
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FormGeneratorService>().AsImplementedInterfaces();
            //AutofacHelper.RegisterFormGeneratorComponents<FormGeneratorServiceForAttribute, IFormGeneratorService>(builder);
        }
    }
}