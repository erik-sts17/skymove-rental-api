using System;
using SkyMove.Domain.Enums;
using SkyMove.Shared.Entities;

namespace SkyMove.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public EVehicleType Type { get; set; }
        public EVehicleStatus Status { get; set; }

    }
}