using NorthWind.Entities.Interfaces.Events;

namespace NorthWind.Entities.Services
{
    public class DomainEventHub<EventType> : IDomainEventHub<EventType> where EventType : IDomainEvent
    {
        readonly IEnumerable<IDomainEventHandler<EventType>> eventHandlers;

        public DomainEventHub(IEnumerable<IDomainEventHandler<EventType>> eventHandlers)
        {
            this.eventHandlers = eventHandlers;
        }

        public void Raise(EventType evenTypeInstance)
        {
            foreach (var Handler in eventHandlers)
            {
                Task.Run(()=> Handler.Handle(evenTypeInstance));
            }
        }
    }
}
