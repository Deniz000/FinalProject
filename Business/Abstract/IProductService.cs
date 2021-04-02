using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //ilem sonucu, mesaj böyle şekley ekledik 
        IDataResult<List<Product>> GetAll(); //tüm ürünleri listeleyecek ortam
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<Product>> GetById(int productId);
        IResult Add(Product product);

        //bunların tamamını birer istek haline getiriyoruz.
        // restful --> Http(internet) --> TCP (kablo)
    }
}