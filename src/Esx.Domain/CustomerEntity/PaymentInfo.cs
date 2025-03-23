namespace Esx.Domain.CustomerEntity;

public record PaymentInfo(PaymentMethod PreferedMethod, bool Verified)
{
    public static readonly PaymentInfo Null = new(PaymentMethod.Unknown, false);
    private PaymentInfo() : this(PaymentMethod.Unknown, false) { }
};
