using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

namespace Esx.Application.Reservations;

public class UpdateReservationService(
    IRepository<RentRecord, RentRecordId> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper): IUpdateReservationService
{
    public async Task<Reservation> UpdateAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        var existing = await repository.GetAsync((RentRecordId)reservation.Id, cancellationToken);
        existing.PickupLocation = reservation.PickupLocation;
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<Reservation>(existing);
    }
}