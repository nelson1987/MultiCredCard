namespace MultiCredCard.Domain.Interfaces.Events
{
    public interface ICommandHandler<in T> : IHandler<T> where T : IDomainEvent
    {
    }
}
