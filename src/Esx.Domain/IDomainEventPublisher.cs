namespace Esx.Domain;

public abstract record DomainEventBase();
public interface IDomainEventPublisher
{
    IEnumerable<DomainEventBase> GetEvents();
    void Reset();
}
