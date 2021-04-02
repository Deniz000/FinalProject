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
        { //aop: bütün metotlarý loglamak istiyoruz. Normal ILoggerService Log() gibi bir þey yaparýz onun yerine loglanacak metot üzerine [LogAspect] vs yazarýz. 
            // Aop bize metot önünde, arkadsýnda vs bu alt yapýlarý kullanýrýz([]). 
            //Aop örnekler, [validation] [RemoveCache] [Transaction] ...> clas baþýna yaýnca boþta metot kaldý mý diye düþünmemize gerek kalmýyor.
            // Aop imkaný sunuyor -> Autoffac sunuyor, bu yüzden Autofac inject ediyoruz mesela
            //Autofac, Ninject, CastleWindsor...   //postsharp
            //Dal, Service'ler karþýlýðýný  Autofac de yapýlandýracaðýz. Yaani; Teknoloji kullanacaðýz.
            // Dependency Resolves içinde. Autofac için baðýmlýlýk configurasyonu yapacaðýz. 
            services.AddControllers();
            //services.AddSingleton<IProductService, ProductManager>(); // bana arka planda bir referans oluþtu r.Ioc yerimize newliyor. <Bunu görürsen, bunu oluþtur, ver> demek
            ////içinde data tutmuyorsak AddSingleton kullanýlabilir. *******
            //services.AddSingleton<IProductDal, EfProductDal>();// SingleTon Tüm bellekte bir manager oluþturur,

            //AddSingketon bizim yerimize new leyen arkqadaþ 
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
 