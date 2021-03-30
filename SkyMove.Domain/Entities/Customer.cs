using System;
using SkyMove.Domain.ValueObjects;
using SkyMove.Shared.Entities;

namespace SkyMove.Domain.Entities
{
    public class Customer : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime Birthday { get; private set; }
        public Address Address { get; private set; }
    }
}