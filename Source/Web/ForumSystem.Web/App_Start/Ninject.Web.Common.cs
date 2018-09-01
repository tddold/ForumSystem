[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ForumSystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ForumSystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ForumSystem.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using AutoMapper;
    using ForumSystem.Data;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ForumSystem.Web.Infrastructure.Mapping.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

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
            kernel.Bind<DbContext>().To<ApplicationDbContext>();

            kernel.Bind(typeof(IRepository<Post>)).To(typeof(IDeletableEntityRepository<Post>));

            kernel.Bind(typeof(IDeletableEntityRepository<>))
                .To(typeof(DeletableEntityRepository<>));

            kernel.Bind(typeof(IRepository<>))
                .To(typeof(GenericRepository<>));

            kernel.Bind<ISanitizer>().To<HtmlSanitizerAdapter>();


            //kernel.Bind<IMapper>().To<Mapper>();

            //kernel.Bind(typeof(IMapper))
            //  .To(typeof(Mapper));

            //kernel.Bind(typeof(IMappingService))
            //    .To(typeof(AutoMapperMappingService));

            //kernel.Bind(typeof(IConfigurationProvider))
            //    .To(typeof(Mapper));


        }
    }
}