using SpaceAdventure.Shared.Models.Enums;

namespace SpaceAdventure.Shared.Models.Interfaces
{
    public interface IResult
    {
        ResultType ResultType { get; set; }
        List<string> Messages { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }
}