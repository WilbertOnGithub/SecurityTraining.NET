using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityTraining.Startup))]
namespace SecurityTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
