using SpaceAdventure.Shared.Models.Enums;
using SpaceAdventure.Shared.Models.Interfaces;

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

        public void MapResult(Result result)
        {
            ResultType = result.ResultType;
            Messages.AddRange(result.Messages);
        }

        public static Result GetSuccessResult()
        {
            return new Result(ResultType.Success);
        }

        public static Result GetFailedResult(string message)
        {
            var result = new Result(ResultType.Error);
            result.Messages.Add(message);
            return result;
        }

        public static Result GetFailedResult(List<string> messages)
        {
            return new Result(ResultType.Error)
            {
                Messages = messages
            };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }

        public Result(ResultType resultType = ResultType.Error) : base(resultType)
        {
        }

        public static Result<T> GetSuccessResult(T data)
        {
            return new Result<T>(ResultType.Success)
            {
                Data = data
            };
        }

        public static Result<T> GetFailedResult(string message)
        {
            var result = new Result<T>(ResultType.Error);
            result.Messages.Add(message);
            return result;
        }

        public static Result<T> GetFailedResult(List<string> messages)
        {
            return new Result<T>(ResultType.Error)
            {
                Messages = messages
            };
        }
    }
}