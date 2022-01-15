using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

public class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime Birthdate { get; private set; }
    public Address Address { get; private set; }
    public Phone Phone { get; private set; }

    public bool IsActive { get; private set; } = true;
    

    public Customer(string name, DateTime birthdate, Address address, Phone phone)
    {
        Name = name;
        Birthdate = birthdate;
        Address = address;
        Phone = phone;
    }

    public void UpdateInfo(string name, DateTime birthdate, Address address, Phone phone)
    {
        Name = name;
        Birthdate = birthdate;
        Address = address;
        Phone = phone;
    }

    public void ChangeAddress(Address newAddress)
    {
        Address = newAddress;
    }

    public void ChangePhone(Phone newPhone)
    {
        Phone = newPhone;
    }

    public void Inactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}