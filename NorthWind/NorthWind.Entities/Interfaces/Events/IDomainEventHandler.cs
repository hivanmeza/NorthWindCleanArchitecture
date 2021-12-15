namespace NorthWind.Entities.Interfaces.Events
{
    public interface IDomainEventHandler<EventType>where EventType : IDomainEvent
    {
        void Handle(EventType eventTypeInstance);
    }
}
