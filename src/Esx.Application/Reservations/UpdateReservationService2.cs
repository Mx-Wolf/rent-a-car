using AutoMapper;

using Esx.Domain.Entities;
using Esx.Domain.Repositories;

namespace Esx.Application.Reservations;

public class UpdateReservationService2(
    IRepository<Reservation, RentRecordId> repository,
    IUnitOfWork unitOfWork): IUpdateReservationService2
{
    public async Task UpdateAsync(Domain.Dto.Reservation reservation, CancellationToken cancellationToken)
    {
        var existing = await repository.GetAsync((RentRecordId)reservation.Id, cancellationToken);
        existing.PickupLocation = reservation.PickupLocation;
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}