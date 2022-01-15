namespace CleanArchitecture.Domain.ValueObjects;

public record Phone
{
    public string CountryCode { get; private set; }
    public string RegionCode { get; private set; }
    public string Number { get; private set; }

    public Phone(string countryCode, string regionCode, string number)
    {
        CountryCode = countryCode;
        RegionCode = regionCode;
        Number = number;
    }
};