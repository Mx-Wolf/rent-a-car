using Esx.Application.Payments;
using Esx.Domain.Dto;

using Microsoft.AspNetCore.Mvc;

namespace Esx.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController()
{
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        [FromServices] IPaymentService paymentService,
        [FromRoute] int id,
        [FromBody] Esx.Controllers.Bodies.Payment body,
        CancellationToken cancellationToken)
    {
        if (body == null)
        {
            throw new ArgumentNullException(nameof(body));
        }

        await paymentService.ProcessPayment(
            new Payment(id, body.TotalCharges, body.AdditionalFees),
            cancellationToken);

        return new RedirectToActionResult(nameof(ReservationsController.Get), nameof(ReservationsController), false);
    }
}