using SpaceAdventure.Shared.Services.Interfaces;

namespace SpaceAdventure.Shared.Services
{
    public class RandomiserService : IRandomiserService
    {
        private readonly Random _random;

        public RandomiserService()
        {
            _random = new Random();
        }

        public int GetRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
