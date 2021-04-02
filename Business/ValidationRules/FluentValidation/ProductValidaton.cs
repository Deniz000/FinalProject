using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation      //fluent akıcı demek
{
    //Burada kurallarımızı koyuyoruz. Fluent Validation uzun iflerden kurtarır
    public class ProductValidaton : AbstractValidator<Product>
    {
        public ProductValidaton() //kurallar constructor içine yazılıyor
        {
            RuleFor(p => p.ProductName).NotEmpty(); //boş olamaz
            RuleFor(p =>p.ProductName ).MinimumLength(2); //p yukardaki product, adı iki karakter olmalıdır diyor.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); // 0dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // OOPS! çok iyi laaan!
            // Tc kimlik no zorunludur ama ne zaman uyruk Türkiye Cumhuriyeti ise!
            //kural koymak istiyorum, kendim metot koymak istiyorum.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalı.");

        }
      

        private bool StartWithA(string arg) //true kurala uygun false uygun değil. false kuralı patlatır.
        {
            return arg.StartsWith("A");
        }
    }
}
