namespace SkyMove.Domain.ValueObjects
{
    public class Name
    {
        public Name()
        {
                
        }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public override string ToString()
        {
            return $"{FirstName} {LastName}"; 
        }
    }
}