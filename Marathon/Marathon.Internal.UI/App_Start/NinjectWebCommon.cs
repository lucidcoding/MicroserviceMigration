using Ninject.Web.Mvc.FilterBindingSyntax;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Marathon.Internal.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Marathon.Internal.UI.App_Start.NinjectWebCommon), "Stop")]

namespace Marathon.Internal.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Marathon.Data.Common;
    using Marathon.Internal.UI.ViewModelMappers.Booking;
    using Marathon.Internal.UI.Security;
    using Marathon.Data.Core;
    using Marathon.Internal.UI.ViewModelMappers.Invoice;
    using Marathon.Internal.UI.ActionFilters;
    using System.Web.Mvc;
    using Marathon.Domain.InfrastructureContracts;

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
            kernel.Bind<ICollectViewModelMapper>().To<CollectViewModelMapper>();
            kernel.Bind<IReturnViewModelMapper>().To<ReturnViewModelMapper>();
            kernel.Bind<IGetSummaryViewModelMapper>().To<GetSummaryViewModelMapper>();
            kernel.Bind<IGenerateViewModelMapper>().To<GenerateViewModelMapper>();
            kernel.Bind<IUserProvider>().To<UserProvider>();
            kernel.BindFilter<EntityFrameworkWriteContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkWriteContextAttribute>();
            kernel.BindFilter<EntityFrameworkReadContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkReadContextAttribute>();
            kernel.Bind<IEmailer>().To<StubEmailer>();
            new DataRegistry().RegisterServices(kernel);
        }        
    }
}
