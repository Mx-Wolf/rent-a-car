namespace Esx.Domain.CustomerEntity;
public class Customer : EntityBase<CustomerId>
{
    public static readonly string DriverLicenseNull = string.Empty;

    public PersonName Name { get; private set; }
    public string DriverLicense { get; private set; }
    public PaymentInfo PaymentInfo { get; private set; }

    public Customer(PersonName name, string driverLicense, PaymentInfo paymentInfo) : base(CustomerId.Empty)
    {
        Name = name;
        DriverLicense = driverLicense;
        PaymentInfo = paymentInfo;
    }
}
