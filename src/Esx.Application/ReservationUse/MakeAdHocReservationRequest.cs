using Esx.Domain.CarEntity;

namespace Esx.Application.ReservationUse;

public record MakeAdHocReservationRequest(
    string FirstName,
    string LastName,
    CarId CarId,
    DateTime DateStart,
    DateTime DateEnd);
