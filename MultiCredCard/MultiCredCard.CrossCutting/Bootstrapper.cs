using MultiCredCard.Application;
using MultiCredCard.Application.Interfaces;
using MultiCredCard.Domain.Events;
using MultiCredCard.Domain.Interfaces.Events;
using MultiCredCard.Domain.Interfaces.Repositories;
using MultiCredCard.Domain.Interfaces.Services;
using MultiCredCard.Repositories;
using MultiCredCard.Services;
using SimpleInjector;

namespace MultiCredCard.CrossCutting
{
    public static class BootStrapper
    {
        private static Container _container { get; set; }
        public static void Register(Container container)
        {
            _container = container;

            container.Register<ICompraApplication, CompraApplication>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);


            DomainEvents.Dispatcher = new InjectionEventContainer(container);

            container.RegisterCollection(typeof(IEventHandler<>), typeof(IEventHandler<>).Assembly);
        }
        public static Container GetContainer()
        {
            return _container;
        }
    }
}
