using System.Diagnostics.CodeAnalysis;

using Esx.Domain.CarEntity;
using Esx.Domain.CustomerEntity;

namespace Esx.Domain.ReservationEntity;
public class Reservation : EntityBase<ReservationId>
{
    public DateTime DateStart { get; private set; }
    public DateTime DateEnd { get; private set; }
    public CarId CarId { get; private set; }
    public required CustomerId CustomerId { get; init; }

    [SetsRequiredMembers]
    public Reservation(CarId carId, CustomerId customerId, DateTime dateStart, DateTime dateEnd) : base(ReservationId.Empty)
    {
        CarId = carId;
        CustomerId = customerId;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}
