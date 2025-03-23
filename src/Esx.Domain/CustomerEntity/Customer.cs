namespace Esx.Domain.CustomerEntity;
public class Customer : EntityBase<CustomerId>
{
    public static readonly string DriverLicenseNull = string.Empty;

    public PersonName Name { get; private set; }
    public string DriverLicense { get; private set; }
    public PaymentInfo PaymentInfo { get; private set; }

    public Customer(PersonName name, string driverLicense, PaymentInfo paymentInfo, CustomerId id = default) : base(id)
    {
        Name = name;
        DriverLicense = driverLicense;
        PaymentInfo = paymentInfo;
    }
    public Customer():base(CustomerId.Empty)
    {
        Name = PersonName.Empty;
        DriverLicense = DriverLicenseNull;
        PaymentInfo = PaymentInfo.Null;
    }
}
