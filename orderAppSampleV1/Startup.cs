using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(orderAppSampleV1.Startup))]
namespace orderAppSampleV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
