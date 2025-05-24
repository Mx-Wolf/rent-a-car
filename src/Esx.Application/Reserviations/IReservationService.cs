using Esx.Domain.Dto;

namespace Esx.Application.Reserviations;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> List(CancellationToken cancellationToken);
}
