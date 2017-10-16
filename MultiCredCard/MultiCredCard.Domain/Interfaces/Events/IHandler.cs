namespace MultiCredCard.Domain.Interfaces.Events
{
    public interface IHandler<in T> where T : IDomainEvent
    {
        //Task HandleAsync(T @event);
        void Handle(T args);
    }
}
