using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //ister data ve mesaj ver, ister sadevce data-mesaj ver istersen hiçbir şey verme, bunlar versiyonlar, default demek dataya karşılık geliyor. int'tir mesela data da int dir
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
