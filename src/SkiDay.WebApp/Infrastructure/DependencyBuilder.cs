using System;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SkiDay.WebApp.Controllers;
using SkiDay.WebApp.Services;

namespace SkiDay.WebApp.Infrastructure
{
    public static class DependencyBuilder
    {
        private static void DefaultServiceBuilder(ServiceCollection services)
        {
            ServicePointManager.DefaultConnectionLimit = 10;

            services.AddScoped<SkiDayContext>();
            services.AddTransient<ISkiResortsService, SkiService>();
            services.AddTransient<AccountController>();
            services.AddTransient<HomeController>();
            services.AddTransient<ManageController>();
        }

        public static IDependencyResolver Build(Action<ServiceCollection> customServiceBuilder = null)
        {
            var serviceCollection = new ServiceCollection();
            var serviceBuilder = customServiceBuilder ?? DefaultServiceBuilder;
            serviceBuilder(serviceCollection);
            return new DefaultDependencyResolver(serviceCollection.BuildServiceProvider());
        }
        
    }
}