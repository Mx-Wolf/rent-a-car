namespace Esx.Application.ReservationUse;
public interface IReservationRequestHandler
{
    Task MakeAdHocReservation(MakeAdHocReservationRequest request);
}
