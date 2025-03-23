using Esx.Application.ReservationUse;

using Microsoft.AspNetCore.Mvc;


namespace Esx.Controllers;

[ApiController]
[Route("reservations")]
public class ReservationsController
{
    private readonly IReservationRequestHandler reservationRequestHandler;

    public ReservationsController(IReservationRequestHandler reservationRequestHandler)
    {
        this.reservationRequestHandler = reservationRequestHandler;
    }

    [HttpPost]
    public async Task<IActionResult> MakeReservation([FromBody] MakeAdHocReservationRequest request)
    {
        await reservationRequestHandler.MakeAdHocReservation(request);
        return new StatusCodeResult(201);
    }
}
