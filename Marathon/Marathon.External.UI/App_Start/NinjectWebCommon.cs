[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Marathon.External.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Marathon.External.UI.App_Start.NinjectWebCommon), "Stop")]

namespace Marathon.External.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Marathon.Data.Common;
    using Marathon.Data.Core;
    using Marathon.External.UI.ViewModelMappers.Customer;
    using Marathon.External.UI.ViewModelMappers.Booking;
    using Marathon.External.UI.Security;

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
            kernel.Bind<IContextProvider>().To<GenericContextProvider>().InRequestScope();
            kernel.Bind<IRegisterViewModelMapper>().To<RegisterViewModelMapper>();
            kernel.Bind<IMakeViewModelMapper>().To<MakeViewModelMapper>();
            kernel.Bind<IGetPendingForVehicleViewModelMapper>().To<GetPendingForVehicleViewModelMapper>();
            kernel.Bind<IUserProvider>().To<UserProvider>();
            new DataRegistry().RegisterServices(kernel);
        }        
    }
}
