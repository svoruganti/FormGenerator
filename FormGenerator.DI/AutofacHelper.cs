using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using FormGenerator.Service;
using Microsoft.Extensions.DependencyModel;

namespace FormGenerator.DI
{
    public class AutofacHelper
    {
        public static void RegisterFormGeneratorComponents<TA, TI>(ContainerBuilder builder) where TA : Attribute where TI : class
        {
            var types = new List<Type>();
            var assemblyNames =
                DependencyContext.Default.CompileLibraries.SelectMany(x => x.Assemblies);
            foreach (var assemblyName in assemblyNames)
            {
                var assembly = Assembly.Load(new AssemblyName(assemblyName));
                types.AddRange(assembly.GetTypes()
                    .Where(x => x.GetTypeInfo().GetCustomAttribute<TA>() != null));
            }

            foreach (var type in types)
            {
                builder.RegisterType(type)
                    .Named<TI>(type.GetTypeInfo()
                        .GetCustomAttribute<FormGeneratorServiceForAttribute>()
                        .FormCode);
            }
        }

    }
}