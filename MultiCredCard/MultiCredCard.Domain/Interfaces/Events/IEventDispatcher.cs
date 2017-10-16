namespace MultiCredCard.Domain.Interfaces.Events
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
    }
}
