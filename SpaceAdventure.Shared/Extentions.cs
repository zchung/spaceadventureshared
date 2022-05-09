using Newtonsoft.Json;

namespace SpaceAdventure.Shared
{
    public static class Extentions
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
