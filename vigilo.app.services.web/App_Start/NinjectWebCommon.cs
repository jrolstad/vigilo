using vigilo.app.services.web.Mappers;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;

[assembly: WebActivator.PreApplicationStartMethod(typeof(vigilo.app.services.web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(vigilo.app.services.web.App_Start.NinjectWebCommon), "Stop")]

namespace vigilo.app.services.web.App_Start
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMapper<RabbitMqQueueMetadata, MessageQueueStatus>>().To<MessageQueueStatusMapper>();

            kernel.Bind<ICommand<GetRabbitMqServerUrlRequest,GetRabbitMqServerUrlResponse>>().To<GetRabbitMqServerUrlCommand>();
            kernel.Bind<ICommand<GetMonitorableQueuesRequest,GetMonitorableQueuesReponse>>().To<GetMonitorableQueuesCommand>();
            kernel.Bind<ICommand<GetRabbitMqQueueMetadataRequest,GetRabbitMqQueueMetadataResponse>>().To<GetRabbitMqQueueMetadataCommand>();
        }        
    }
}
