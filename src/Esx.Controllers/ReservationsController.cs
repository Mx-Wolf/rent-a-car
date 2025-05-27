using AutoMapper;

using Esx.Application.Reservations;
using Esx.Controllers.Bodies;

using Microsoft.AspNetCore.Mvc;

namespace Esx.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController(IMapper mapper)
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] IReservationService reservationService,
        CancellationToken cancellationToken)
    {
        var data = await reservationService.List(cancellationToken);
        return new OkObjectResult(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        [FromServices] IUpdateReservationService reservationService,
        [FromRoute] int id, 
        [FromBody] Reservation body,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var command = mapper.Map<Domain.Dto.Reservation>((id, body));
        var result = await reservationService.UpdateAsync(command, cancellationToken);
        return new OkObjectResult(result);
    }
    
    [HttpPut("{id}/command")]
    public async Task<IActionResult> PutCommand(
        [FromServices] IUpdateReservationService2 reservationService,
        [FromRoute] int id,
        [FromBody] Reservation body,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<Domain.Dto.Reservation>((id, body));
        await reservationService.UpdateAsync(command, cancellationToken);
        return new RedirectToActionResult(nameof(Get),"reservations",null,false);
    }
}
