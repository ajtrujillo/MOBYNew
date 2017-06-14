using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(MOBYNew.Startup))]
namespace MOBYNew
{
    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvcCore();
        }
    }
}
