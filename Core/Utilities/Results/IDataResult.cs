using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        // Idataresult ama ceneric, her şeyi döndürebilir,  ama ıResult taki success ve message ayrı. Yani onlar var ama bir de bu T Data var
        //interface interface i implemente ederse içindekileri çekmesine gerek yok, zaten öyleymiş varsayılıyor
        T Data { get; }
    }
}
