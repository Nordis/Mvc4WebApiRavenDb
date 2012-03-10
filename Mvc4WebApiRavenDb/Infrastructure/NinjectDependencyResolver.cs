using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Services;
using Mvc4WebApiRavenDb.Data;
using Ninject;
using Ninject.Syntax;

namespace Mvc4WebApiRavenDb.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot resolutionRoot;

        public NinjectDependencyResolver()
        {
            IKernel kernel = new StandardKernel();
            resolutionRoot = kernel;

            DoBindings(kernel);
        }

        private static void DoBindings(IKernel kernel)
        {
            // Hook up all bindings

            kernel.Bind<IRavenDataStore>().To<RavenTest>();
        }

        #region Implementation of IDependencyResolver

        public object GetService(Type serviceType)
        {
            var service = resolutionRoot.TryGet(serviceType);
            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var services = resolutionRoot.GetAll(serviceType);
            return services;
        }

        #endregion
    }
}