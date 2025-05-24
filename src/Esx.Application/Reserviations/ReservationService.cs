using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

namespace Esx.Application.Reserviations;
public class ReservationService(
    IReadRepository<RentRecord> rentRecords,
    IMapper mapper): IReservationService
{
    public async Task<IEnumerable<Reservation>> List(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return [.. mapper.ProjectTo<Reservation>(rentRecords.GetAll())];
    }
}
