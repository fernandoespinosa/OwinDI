using Autofac;
using Biz.Core;

namespace Host.Fiasco
{
    internal class CompositionRoot
    {
        public IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Top>();
            containerBuilder.RegisterType<Service1>();
            containerBuilder.RegisterType<Service2>();
            containerBuilder.RegisterType<Underyling>();
            return containerBuilder.Build();
        }
    }
}