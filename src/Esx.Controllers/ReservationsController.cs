using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esx.Application.Reserviations;

using Microsoft.AspNetCore.Mvc;

namespace Esx.Controllers;
[ApiController]
[Route("[controller]")]
public class ReservationsController(IReservationService reservationService)
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var data = await reservationService.List(cancellationToken);
        return new OkObjectResult(data);
    }
}
