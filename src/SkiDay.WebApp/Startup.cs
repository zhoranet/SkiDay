using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SkiDay.WebApp.Startup))]

namespace SkiDay.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        ConfigureAuth(app);
        }
    }
}
