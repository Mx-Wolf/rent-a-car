using AutoMapper;

using Esx.Application.Reserviations;
using Esx.Domain.Dto;
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

namespace Esx.Application.Reservations;
public class ReservationService(
    IRepository<RentRecord,RentRecordId> rentRecords,
    IMapper mapper): IReservationService
{
    public async Task<IEnumerable<Reservation>> List(CancellationToken cancellationToken)
    {
        return await rentRecords.ProjectAsync(q => mapper.ProjectTo<Reservation>(q), cancellationToken);
    }
}
