namespace Esx.Application.Payments;

public interface IPaymentService
{
    Task ProcessPayment(Esx.Domain.Dto.Payment command, CancellationToken cancellationToken);
}