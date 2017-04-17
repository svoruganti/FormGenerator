using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FormGenerator.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace FormGenerator.DI
{
    public class DependencyInjection
    {
        public IServiceProvider Register(IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.AddDbContext<FormGeneratorDbContext>(options =>
            {
                options.UseMySQL(configurationRoot.GetConnectionString("DefaultConnection"));
            });
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<HandlerModule>();
            builder.RegisterModule<MapperModule>();
            builder.Populate(services);
            return new AutofacServiceProvider(builder.Build());
        }
    }
}