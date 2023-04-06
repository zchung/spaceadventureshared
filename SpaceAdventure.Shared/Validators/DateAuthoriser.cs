using NodaTime;
using SpaceAdventure.Shared.Models.Interfaces;
using SpaceAdventure.Shared.Models.Structs;
using SpaceAdventure.Shared.Validators.Interfaces;

namespace SpaceAdventure.Shared.Validators
{
    public class DateAuthoriser : ICustomAuthoriser
    {
        private readonly IClock _clock;
        public DateAuthoriser(IClock clock)
        {
            _clock = clock;
        }
        public bool AuthoriseHeader(string authCode)
        {           
            return !string.IsNullOrEmpty(authCode) &&
                _clock.GetCurrentInstant().ToDateTimeUtc().ToString(AuthorisationConstants.AUTH_DATE_FORMAT) == authCode;          
        }
    }
}
