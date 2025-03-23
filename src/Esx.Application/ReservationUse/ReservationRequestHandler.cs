using Esx.Domain;
using Esx.Domain.AuditTrailEntity;
using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

namespace Esx.Application.ReservationUse;

public class ReservationRequestHandler : IReservationRequestHandler
{
    private readonly IEntityRepository<Reservation, ReservationId> reservations;
    private readonly IEntityRepository<Customer, CustomerId> customers;
    private readonly IEntityRepository<AuditTrial, AuditTrialId> auditTrials;
    private readonly IUnitOfWork unitOfWork;

    public ReservationRequestHandler(
        IEntityRepository<Reservation, ReservationId> reservations,
        IEntityRepository<Customer, CustomerId> customers,
        IUnitOfWork unitOfWork,
        IEntityRepository<AuditTrial, AuditTrialId> auditTrials)
    {
        this.reservations = reservations;
        this.customers = customers;
        this.unitOfWork = unitOfWork;
        this.auditTrials = auditTrials;
    }

    public async Task MakeAdHocReservation(MakeAdHocReservationRequest request)
    {
        var customer = new Customer(
            new PersonName(request.FirstName, request.LastName),
            Customer.DriverLicenseNull,
            PaymentInfo.Null
            );
        customers.Add(customer);

        await unitOfWork.SaveChangesAsync();

        var reservation = new Reservation(
            request.CarId,
            customer.Id,
            request.DateStart,
            request.DateEnd
            );
        reservations.Add(reservation);

        await unitOfWork.SaveChangesAsync();

        var audit = new AuditTrial
        {
            Category = "Test1",
            Changes = [new ChangeInfo("test action", "test field", "42", "-")],
            CompletedBy = new UserInfo("mr x","mrx@example.com"),
            DateCompleted = DateTime.UtcNow,
            ObjectId = 42,
            ObjectName = "foo",
        };
        auditTrials.Add(audit);

        await unitOfWork.SaveChangesAsync();
    }
}
