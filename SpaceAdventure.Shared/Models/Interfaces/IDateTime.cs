using System;

namespace SpaceAdventure.Shared.Models.Interfaces
{
    public interface IDateTime
    {
        public DateTime UtcNow { get; }
    }
}
