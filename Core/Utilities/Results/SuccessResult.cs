using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {

        public SuccessResult(string message):base(true, message) //message neden yazıldı?  //ha mesajı dönderecek ve alt mesajsız dönecek. Alttaki true default değer
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
