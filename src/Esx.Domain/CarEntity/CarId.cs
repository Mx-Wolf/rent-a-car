namespace Esx.Domain.CarEntity;
[StronglyTypedId()]
public readonly partial struct CarId :
    IEntityKey,
    IComparisonOperators<CarId, CarId, bool>,
    IEqualityOperators<CarId, CarId, bool>
{ }
