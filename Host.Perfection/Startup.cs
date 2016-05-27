using Autofac;
using Autofac.Integration.Owin;
using Biz.Core;
using Owin;
using System.Text;

namespace Host.Perfection
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = CompositionRoot.Build();
            app.UseAutofacMiddleware(container); // perfection
            app.Run(async context =>
            {
                var top = context.GetAutofacLifetimeScope().Resolve<Top>(); // perfection
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