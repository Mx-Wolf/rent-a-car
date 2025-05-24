using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Esx.Controllers;
[ApiController]
[Route("[controller]")]
public class ReservationsController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;
        return new OkObjectResult(new { status = "Reservations OK" });
    }
}
