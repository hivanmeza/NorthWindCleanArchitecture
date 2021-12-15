namespace NorthWind.Entities.Interfaces.Events
{
    public interface IDomainEventHub<EvenType> where EvenType : IDomainEvent
    {
        void Raise(EvenType evenTypeInstance);
    }
}
