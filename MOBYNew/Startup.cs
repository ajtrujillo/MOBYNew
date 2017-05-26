using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MOBYNew.Startup))]
namespace MOBYNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
