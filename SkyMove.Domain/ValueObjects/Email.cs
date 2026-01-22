namespace SkyMove.Domain.ValueObjects
{
    public class Email(string address)
    {
        public string Address { get; private set; } = address;
    }
}