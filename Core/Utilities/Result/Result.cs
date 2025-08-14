using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {

        public Result(bool success,string message):this(success) //this yazarak hem 2 sini de hem de sadece success'ı kullanmıs oluyoruz
        {
            Message= message;
        }

        public Result(bool success)
        {
            Success= success;
        }
        public bool Success { get; }

        public string Message {  get; }
    }
}
