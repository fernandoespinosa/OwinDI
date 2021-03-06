﻿using Autofac;
using Biz.Core;
using Owin;
using System.Text;

namespace Host.Fiasco
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = CompositionRoot.Build();
            app.Run(async context =>
            {
                var top = container.Resolve<Top>(); // fiasco
                context.Response.ContentType = "text/plain";

                var text = new StringBuilder();
                text.AppendLine("Top: {0}", top.Guid);
                text.AppendLine(" |");
                text.AppendLine(" +-- Top.Service1: {0}", top.Service1.Guid);
                text.AppendLine(" |  |");
                text.AppendLine(" |  +-- Top.Service1.Underyling: {0}", top.Service1.Underyling.Guid);
                text.AppendLine(" |");
                text.AppendLine(" +-- Top.Service2: {0}", top.Service2.Guid);
                text.AppendLine("    |");
                text.AppendLine("    +-- Top.Service2.Underyling: {0}", top.Service2.Underyling.Guid);

                await context.Response.WriteAsync(text.ToString());
            });
        }
    }
}