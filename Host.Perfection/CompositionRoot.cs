using Autofac;
using Biz.Core;

namespace Host.Perfection
{
    internal class CompositionRoot
    {
        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Top>();
            containerBuilder.RegisterType<Service1>();
            containerBuilder.RegisterType<Service2>();
            //containerBuilder.RegisterType<Underyling>(); // naive
            containerBuilder.RegisterType<Underyling>().InstancePerLifetimeScope();
            return containerBuilder.Build();
        }
    }
}