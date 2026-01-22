using SkyMove.Domain.Enums;

namespace SkyMove.Application.Dtos.Vehicle
{
    public class CreateVehicleRequest
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Kilometers { get; set; }
        public int HorsePower { get; set; }
        public Color Color { get; set; }
    }
}