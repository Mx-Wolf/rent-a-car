using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

namespace Esx.Application.Reservations;
public class ReservationService(
    IRepository<RentRecord,RentRecordId> rentRecords,
    IMapper mapper): IReservationService
{
    public async Task<IEnumerable<Esx.Domain.Dto.Reservation>> List(CancellationToken cancellationToken)
    {
        return await rentRecords.ProjectAsync(q => mapper.ProjectTo<Esx.Domain.Dto.Reservation>(q), cancellationToken);
    }
}
