using MultiCredCard.Domain.Interfaces.Events;

namespace MultiCredCard.Domain.Events
{
    public static class DomainEvents
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }
    }
}
