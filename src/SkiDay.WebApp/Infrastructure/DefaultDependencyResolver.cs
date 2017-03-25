using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace SkiDay.WebApp.Infrastructure
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider ServiceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.ServiceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ServiceProvider.GetServices(serviceType);
        }

        
        public void Dispose()
        {
        }
    }
}
