using System;

namespace ContactsBackendDotnet.Models
{
    public class Contact
    {
        public Contact() => Id = Guid.NewGuid();
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Contact Clone()
        {
            return ((Contact)MemberwiseClone());
        }
    }
}