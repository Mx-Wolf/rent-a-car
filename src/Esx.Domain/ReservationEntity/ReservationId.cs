namespace Esx.Domain.ReservationEntity;

[StronglyTypedId]
public readonly partial struct ReservationId :
    IEntityKey,
    IEqualityOperators<ReservationId, ReservationId, bool>,
    IComparisonOperators<ReservationId, ReservationId, bool>
{ }
