using SkyMove.Domain.ValueObjects;

namespace SkyMove.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Document document, Email email, string phoneNumber, DateTime birthday, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Address = address;
        }

        public Customer()
        {

        }

        public Name Name { get; private set; }
        public Document Document { get; private set; } 
        public Email Email { get; private set; } 
        public string PhoneNumber { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }
        public Address? Address { get; private set; }
    }
}