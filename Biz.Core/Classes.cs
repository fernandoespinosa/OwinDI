using System;

namespace Biz.Core
{
    public class Top
    {
        public Top(Service1 service1, Service2 service2)
        {
            Service1 = service1;
            Service2 = service2;
        }

        public Service1 Service1 { get; private set; }

        public Service2 Service2 { get; private set; }
    }

    public class Service2
    {
        public Service2(Underyling underyling)
        {
            Underyling = underyling;
        }

        public Underyling Underyling { get; private set; }
    }

    public class Service1
    {
        public Service1(Underyling underyling)
        {
            Underyling = underyling;
        }

        public Underyling Underyling { get; private set; }
    }

    public class Underyling
    {
        public Underyling()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; private set; }
    }
}
