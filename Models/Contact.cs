using System;

namespace ContactsBackendDotnet.Models
{
    public class Contact
    {
        public Contact(){
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}