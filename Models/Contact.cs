namespace WastingNoTime.Contacts.Models;

public class Contact
{
    public Guid Id { get; set; }= Guid.NewGuid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public Contact Clone() =>
        (Contact)MemberwiseClone();
}