using SpaceAdventure.Shared.Models.Enums;
using SpaceAdventure.Shared.Models.Interfaces;
using System.Collections.Generic;

namespace SpaceAdventure.Shared.Models
{
    public class Result : IResult
    {
        public ResultType ResultType { get; set; }
        public List<string> Messages { get; set; }

        public Result(ResultType resultType = ResultType.Error)
        {
            ResultType = resultType;
            Messages = new List<string>();
        }
    }

    public class Result<T> : Result, IResult<T> where T : class
    {
        public T Data { get; set; }

        public Result(ResultType resultType = ResultType.Error): base(resultType) { }
    }
}
