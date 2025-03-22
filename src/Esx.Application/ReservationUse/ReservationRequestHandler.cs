using Esx.Domain;
using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

namespace Esx.Application.ReservationUse;

public class ReservationRequestHandler : IReservationRequestHandler
{
    private readonly IEntityRepository<Reservation, ReservationId> reservations;
    private readonly IEntityRepository<Customer, CustomerId> customers;
    private readonly IUnitOfWork unitOfWork;

    public ReservationRequestHandler(
        IEntityRepository<Reservation, ReservationId> reservations,
        IEntityRepository<Customer, CustomerId> customers,
        IUnitOfWork unitOfWork)
    {
        this.reservations = reservations;
        this.customers = customers;
        this.unitOfWork = unitOfWork;
    }

    public async Task MakeAdHocReservation(MakeAdHocReservationRequest request)
    {
        var customer = new Customer(
            new PersonName(request.FirstName, request.LastName),
            Customer.DriverLicenseNull,
            PaymentInfo.Null
            );
        customers.Add( customer );

        var reservation = new Reservation(
            request.CarId, 
            customer.Id, 
            request.DateStart, 
            request.DateEnd);
        reservations.Add( reservation );

        await unitOfWork.SaveChangesAsync();
    }
}
