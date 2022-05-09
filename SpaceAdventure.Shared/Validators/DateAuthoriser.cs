using SpaceAdventure.Shared.Models.Interfaces;
using SpaceAdventure.Shared.Models.Structs;
using SpaceAdventure.Shared.Validators.Interfaces;

namespace SpaceAdventure.Shared.Validators
{
    public class DateAuthoriser : ICustomAuthoriser
    {
        private readonly IDateTime _customDateTime;
        public DateAuthoriser(IDateTime customDateTime)
        {
            _customDateTime = customDateTime;
        }
        public bool AuthoriseHeader(string authCode)
        {           
            return !string.IsNullOrEmpty(authCode) &&
                _customDateTime.UtcNow.ToString(AuthorisationConstants.AUTH_DATE_FORMAT) == authCode;          
        }
    }
}
