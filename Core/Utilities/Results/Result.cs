using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            Message = message;
            //buraya da success yazsaydık iki kere çalışacaktı. Gereksiz kod yazmış olacaktık. Öyleyse succes asıl kullanılması gereken yerde yazılır
            //this burada : tamam sen çalış sonra ama succes tek parametreliden  gelsin 
        }
        public Result(bool success)
        {
            Success = success;
            // burada sadece succes geliyor öyleyse succes burada kullanılacak
        }

        //sadece get olduğu için bu şekilde. => karşısına ne yazarsak onu dönderir
        public bool Success { get;  }
        public string Message { get; }

    }
}
