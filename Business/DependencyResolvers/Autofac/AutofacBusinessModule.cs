using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    // Business Modulu demenin sebebi bu projeyi ilgilendiren configirasyonu burda yapacaz. Bir de core katmanı var bunun. 
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder) // uygulama hayata geçtiği zaman, çalıştırınca burası çalışacak. -OKU
        {
            //Bununla çeşitli build conf. oluşturabiliyoruz. hangi instance kullanılacak.
            //SingleInstance tek instance oluştur herkese onu ver. Aynı anda 1 uygulamaya 100 giriş varsa 100 kere üretmek yerine 1 kere üretip veriyor
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); // Service isterse Manager register et. Örneği ver. newleyip ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance(); // sürekli new lemek zorunda kalmıyoruz.
        }
    }
}
