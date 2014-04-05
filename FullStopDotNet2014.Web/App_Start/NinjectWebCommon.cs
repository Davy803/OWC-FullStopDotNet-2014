using FullStopDotNet2014.Data;
using FullStopDotNet2014.Services.Implementation;
using FullStopDotNet2014.Services.Interfaces;
using FullStopDotNet2014.Web.App_Start;
using Ninject.Extensions.Conventions;
using Resources.Abstract;
using Resources.Concrete;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace FullStopDotNet2014.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IResourceProvider>().To<DbResourceProvider>().InRequestScope();
            //kernel.Bind(
            //    x =>
            //        x.FromAssemblyContaining<ServiceBase>()
            //            .SelectAllInterfaces()
            //            .BindSingleInterface()
            //            .Configure(c => c.InRequestScope()));
            kernel.Bind(
                x =>
                    x.FromAssemblyContaining<ServiceBase>()
                        .SelectAllClasses()
                        .BindDefaultInterface()
                        .Configure(c => c.InRequestScope()));

        }        
    }
}
