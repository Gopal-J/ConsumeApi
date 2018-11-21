using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsumeApi.Startup))]
namespace ConsumeApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
