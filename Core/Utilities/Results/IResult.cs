using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        //salt okunur
        bool Success { get; } // yapmaya çalıştığın işlem (ekleme silme vs) başarılı true
        string Message { get; } // başarılı, ürün eklendi mesajı. başarasız, şundan dolayı başarısız.

    }
}
