using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> // sondaki T kullanabilmek için 
    {
        //base(succes,message) --> gönder. diyor, bir daha yazmamış oluyoıruz
        //Dataresult aslında result içerisini içeriyor
        // T data resulttan farkı, result void ler için, data result aynı zamanda datası olduğu için

        public DataResult(T data, bool success,string message):base(success,message) // base içindekiler, onları tekrar yazmak istemiyoruz onlar gelsin anlamında 
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}

