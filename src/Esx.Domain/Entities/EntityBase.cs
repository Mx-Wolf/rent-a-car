namespace Esx.Domain.Entities;

public abstract class EntityBase<TEntityIdBase> where TEntityIdBase : struct
{
    public TEntityIdBase Id { get; private set; }
    protected EntityBase() { }
}
