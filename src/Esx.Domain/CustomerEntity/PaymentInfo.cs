namespace Esx.Domain.CustomerEntity;

public record PaymentInfo(PaymentMethod PreferedMethod, bool Verified)
{
    public static readonly PaymentInfo Null = new(PaymentMethod.Unknown, false);
};
