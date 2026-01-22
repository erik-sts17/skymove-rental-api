namespace SkyMove.Domain.ValueObjects
{
    public class Document(string number)
    {
        public string Number { get; set; } = number;
    }
}