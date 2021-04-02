using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {
        //ikisi de interface olduğu için implemente ye gerek yok. interface A ve B olsun A da 2 özellik olsun B yi türetsin B de bu 2 özellik yazmak zorunda değil,
        // zaten yazıyormuş gibi işlem gerçekleşir.  Sonuçta B ye ayrı olarak 1 özellik yazdığımızda B nin 3 özelliği olmuş olur.
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring 