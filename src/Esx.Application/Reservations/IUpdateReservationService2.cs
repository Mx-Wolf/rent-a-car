namespace Esx.Application.Reservations;

public interface IUpdateReservationService2
{
    Task UpdateAsync(Esx.Domain.Dto.Reservation reservation, CancellationToken cancellationToken);
}