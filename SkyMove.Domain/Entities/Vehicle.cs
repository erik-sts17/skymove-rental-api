using SkyMove.Domain.Enums;

namespace SkyMove.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Kilometers { get; set; }
        public int HorsePower { get; set; }
        public Color Color { get; set; }
        public VehicleType Type { get; set; }
        public VehicleStatus Status { get; set; }
    }
}