using MultiCredCard.Domain.Interfaces.Events;
using SimpleInjector;

namespace MultiCredCard.CrossCutting
{
    public class InjectionEventContainer : IEventDispatcher
    {
        private readonly Container _kernel;

        public InjectionEventContainer(Container kernel)
        {
            _kernel = kernel;
        }

        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (var handler in _kernel.GetAllInstances<IEventHandler<TEvent>>())
            {
                handler.Handle(eventToDispatch);
            }
        }
    }
}
