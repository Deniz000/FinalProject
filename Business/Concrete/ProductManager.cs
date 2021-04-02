using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //iş katmanının somut sınıfı 
    public class ProductManager : IProductService
    {
        //bir iş sınıfı başka sınıfları newlemez.
         //InMemoryProductDal inMemoryProductDal = -----new----- InMemoryProductDal(); --Yazarsak eğer bu sayfayı saatlerce değiştirmemiz gerekir
        IProductDal _productDal; //soyut sınıfla bağlantı kurmalıyız

        public ProductManager(IProductDal productDal)  // bana bir product DAL (data..) referansı ver
            // BU İŞLEMDE BAĞIMLILIK ÇÖZÜYORUZ 
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları-bir iş sınıfı başka sınıfları newlemez
            //yetkisi var MI? gibi gibi kodlar yazıldıktan sonra, şu çalıştırılır: 
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //aşağıdaki, 1)dr dödürüyorum,2)çalıştığım tip bu,3)dönderdiğim data bu, 4) ekstradan işlem sonucum, 5) bilgilendirici mesajım
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed); 

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetById(int productId)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.ProductId == productId));
        }

        //[LogAspect] //--AOP
        //[Validate] // ürün eklenecek kuralları uygula
        //[RemoveCach]
        //[Transaction]
        //[Performance]

        //business code ayrı
        //validation nu ayrı 
        //girilen verinin uzunluk kısalık vs vs uyumu DĞRULAMA DIR. İŞ KURALI İSE BİZİM İŞ GEREKSİNİMLERİMİZE UYGUNLUK. 

        public IResult Add(Product product)
        { // ÖNEMLİ NOT : IRESULT GELDİ TÜRETTİĞİ SINIF GİTTİ. ÇÜNKÜ BEN REFERANSINI ALDIM VE ÜZERİNDE İŞLEM
          //YAPTIM. DAHA SONRASINDA İŞLEMİ DİĞER SINIFA LAZIM OLDUĞU ŞEKİLDE 
          // DÖNDERDİM. İNTERFACE REFERANS TUTUCUDUR.
          //business codes
          //magic strings 

            //////bu bizim validation yapacağımız zamanki standart kodumuz. Daha doğruau       SPAGETTİ KODUMUZ.
            ////var context = new ValidationContext<Product>(product); // context ilgili bi tred, Product için bir doğrulama yapacağım diyoruz. Ceneric de product
            ////ProductValidaton productValidation = new ProductValidaton(); 
            ////var result = productValidation.Validate(context);// kurallar için ilgili context, 83 ü doğrular(bu 85)
            ////if (!result.IsValid) //doğru değilse hata fırlat
            ////{
            ////    throw new ValidationException(result.Errors);
            ////}
            ///

            ValidationTool.Validate(new ProductValidaton(), product);

            //business code

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    } 
}
