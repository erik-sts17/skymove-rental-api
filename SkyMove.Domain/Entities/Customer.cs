using SkyMove.Domain.ValueObjects;

namespace SkyMove.Domain.Entities
{
    public class Customer(Name name, Document document, Email email, string phoneNumber, DateTime birthday, Address address) : Entity
    {
        public Name Name { get; private set; } = name;
        public Document Document { get; private set; } = document;
        public Email Email { get; private set; } = email;
        public string PhoneNumber { get; private set; } = phoneNumber;
        public DateTime Birthday { get; private set; } = birthday;
        public Address Address { get; private set; } = address;
    }
}