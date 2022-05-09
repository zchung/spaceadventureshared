using SpaceAdventure.Shared.Models.Enums;
using System.Collections.Generic;

namespace SpaceAdventure.Shared.Models.Interfaces
{
    public interface IResult
    {
        ResultType ResultType { get; set; }
        List<string> Messages { get; set; }
    }

    public interface IResult<T> : IResult where T : class
    {
        T Data { get; set; }
    }
}
