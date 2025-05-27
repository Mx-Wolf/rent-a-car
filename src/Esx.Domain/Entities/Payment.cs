namespace Esx.Domain.Entities;

public record PaymentValue(decimal TotalCharges, decimal AdditionalFees);

public record PaymentConfirmationEvent(decimal TotalCharges, decimal AdditionalFees) : DomainEventBase;
public class Payment : EntityBase<RentRecordId>, IDomainEventPublisher
{
    public decimal TotalCharges { get; private set; }
    public decimal AdditionalFees { get; private set; }
    public bool PaymentConfirmation { get; private set; }

    private Payment() { }

    public Payment(PaymentValue value)
    {
        PaymentConfirmation = true;
        (AdditionalFees,TotalCharges) = (value.AdditionalFees, value.TotalCharges);
        _domainEvents.Add(new PaymentConfirmationEvent(value.TotalCharges, value.AdditionalFees));
    }

    private readonly List<DomainEventBase> _domainEvents = [];
    public IEnumerable<DomainEventBase> GetEvents()
    {
        return _domainEvents.ToArray();
    }

    public void Reset()
    {
        _domainEvents.Clear();
    }
}