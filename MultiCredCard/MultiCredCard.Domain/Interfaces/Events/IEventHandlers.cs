namespace MultiCredCard.Domain.Interfaces.Events
{
    public interface IEventHandler<in T> : IHandler<T> where T : IDomainEvent
    {
    }
}
