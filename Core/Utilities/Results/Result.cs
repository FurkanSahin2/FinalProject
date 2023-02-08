using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Not: "get" read only özelliğine sahiptir. 'Read only'ler constructor'da "set" edilebilir.

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        // İki tane farklı metot varmış gibi olsun diye constructor overloading yapıyoruz:
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
