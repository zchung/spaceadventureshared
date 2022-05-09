
namespace SpaceAdventure.Shared.Validators.Interfaces
{
    public interface ICustomAuthoriser
    {
        bool AuthoriseHeader(string authCode);
    }
}
