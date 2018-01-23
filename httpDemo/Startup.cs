using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(httpDemo.Startup))]
namespace httpDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
