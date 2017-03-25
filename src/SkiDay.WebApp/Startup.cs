using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using SkiDay.WebApp;
using SkiDay.WebApp.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]

namespace SkiDay.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyResolver.SetResolver(DependencyBuilder.Build());

            ConfigureAuth(app);
        }
    }
}