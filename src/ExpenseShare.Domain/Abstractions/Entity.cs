namespace ExpenseShare.Domain.Abstractions
{
    public abstract class Entity 
    {
        private readonly List<IDomainEvent> _events = [];

        public Guid Id { get; init; }
        
        protected Entity(Guid id)
        {
            Id = id;
        }
        protected Entity() { }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        protected void ClearDomainEvents()
        {
            _events.Clear();
        }
        
        protected IReadOnlyList<IDomainEvent> GetDomainEvents() => [.. _events];
    }
}
