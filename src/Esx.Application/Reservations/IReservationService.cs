using Esx.Domain.Dto;

namespace Esx.Application.Reservations;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> List(CancellationToken cancellationToken);
}