using Esx.Domain.Dto;

namespace Esx.Application.Reservations;

public interface IUpdateReservationService
{
    Task<Reservation> UpdateAsync(Reservation reservation, CancellationToken cancellationToken);
}