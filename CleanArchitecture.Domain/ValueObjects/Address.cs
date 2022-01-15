using System.Text;

namespace CleanArchitecture.Domain.ValueObjects;

public record Address
{
    public string Street { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }

    public Address(string street, string neighborhood, string city, string zipCode)
    {
        Street = street;
        Neighborhood = neighborhood;
        City = city;
        ZipCode = zipCode;
    }
};