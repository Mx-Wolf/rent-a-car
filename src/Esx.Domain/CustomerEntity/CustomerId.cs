using System.Numerics;

namespace Esx.Domain.CustomerEntity;

[StronglyTypedId]
public readonly partial struct CustomerId: 
    IEntityKey, 
    IComparisonOperators<CustomerId, CustomerId, bool>,
    IEqualityOperators<CustomerId, CustomerId, bool>
{ } 
