using MultiCredCard.CrossCutting;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

//[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(MultiCredCard.Api.App_Start.SimpleInjectorContainer), "Initialize")]
namespace MultiCredCard.Api.App_Start
{
    public static class SimpleInjectorContainer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}