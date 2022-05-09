using SpaceAdventure.Shared.Models.Interfaces;
using System;

namespace SpaceAdventure.Shared.Models
{
    public class CustomDateTime : IDateTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
