using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { //aop: b�t�n metotlar� loglamak istiyoruz. Normal ILoggerService Log() gibi bir �ey yapar�z onun yerine loglanacak metot �zerine [LogAspect] vs yazar�z. 
            // Aop bize metot �n�nde, arkads�nda vs bu alt yap�lar� kullan�r�z([]). 
            //Aop �rnekler, [validation] [RemoveCache] [Transaction] ...> clas ba��na ya�nca bo�ta metot kald� m� diye d���nmemize gerek kalm�yor.
            // Aop imkan� sunuyor -> Autoffac sunuyor, bu y�zden Autofac inject ediyoruz mesela
            //Autofac, Ninject, CastleWindsor...   //postsharp
            //Dal, Service'ler kar��l���n�  Autofac de yap�land�raca��z. Yaani; Teknoloji kullanaca��z.
            // Dependency Resolves i�inde. Autofac i�in ba��ml�l�k configurasyonu yapaca��z. 
            services.AddControllers();
            //services.AddSingleton<IProductService, ProductManager>(); // bana arka planda bir referans olu�tu r.Ioc yerimize newliyor. <Bunu g�r�rsen, bunu olu�tur, ver> demek
            ////i�inde data tutmuyorsak AddSingleton kullan�labilir. *******
            //services.AddSingleton<IProductDal, EfProductDal>();// SingleTon T�m bellekte bir manager olu�turur,

            //AddSingketon bizim yerimize new leyen arkqada� 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
 