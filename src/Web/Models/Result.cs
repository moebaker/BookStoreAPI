using System;
using Web.Errors;

namespace Web.Models
{
    public class Result
    {
        private readonly bool _success;
        private readonly IError _error;

        public Result()
        {
            _success = true;
            _error = null;
        }

        public Result(IError error)
        {
            _success = false;
            _error = error;
        }

        public TR Match<TR>(Func<TR> valid, Func<IError, TR> fail) => _success ? valid() : fail(_error);
    }

    public class Result<T>
    {
        private readonly bool _success;
        private readonly T _value;
        private readonly IError _error;

        public Result(T value)
        {
            _success = true;
            _value = value;
            _error = null;
        }

        public Result(IError error)
        {
            _success = false;
            _value = default;
            _error = error;
        }

        public R Match<R>(Func<T, R> valid, Func<IError, R> fail) => _success ? valid(_value) : fail(_error);
    }
}
