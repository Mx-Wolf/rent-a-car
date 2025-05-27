using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

using Payment = Esx.Domain.Entities.Payment;

namespace Esx.Application.Payments;

public class PaymentService(
    IRepository<Payment, RentRecordId> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper): IPaymentService
{
    public async Task ProcessPayment(Esx.Domain.Dto.Payment command, CancellationToken cancellationToken)
    {
        var found = await repository.FindAsync((RentRecordId)command.Id, cancellationToken);
        if (found == null)
        {
            repository.Add(new Payment(command));
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
