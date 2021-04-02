using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // kodlama.io da yazılabilir yani. ??
    // rota: isteği yaparken yapan kişiler nasıl ulaşsın. 
    [ApiController] //Attrıbute olması Control old. gösterir. // Bu class bir controller dır bu yüzden kendini ona göre yapılandır.
    public class ProductsController : ControllerBase // inherit edlmesi ve (yukarda, attribute )
    {
        //naming convention _ isimlendirme standartı
        // IoC Container -- inversion of control -- değişimin kontrolü 
        //Ioc= bellekte bir yer, liste. bu listede masangerlar var. a) new ProductManager vs bisürü manager var. Bu listeden işe yarayan, o an kullanılan 
        //managerları gönderiyor. Web api istek zamanı (ya da işlem zamanı tam bilmiyorum). IoC ye bakıyor, Ioc de referansı veriyor --canfigurasyon yapıyoruz
        IProductService _productService;  // BU İŞLEMDE BAĞIMLILIK ÇÖZÜYORUZ

        //Loosely coupled
        public ProductsController(IProductService productService) // GEVŞEK BAĞLILIK // PRODUCT CONROLLER ıPRODUTSERVİCE BAĞIMLISI -- manager ver demek
        {
            _productService = productService; // verdiği referansı da buna atayayım 
        }

        [HttpGet("getall")] 
        public IActionResult GetAll()  // http statü kodu dönmeyi sağlıyor 
        { 
            //swagger
            //Dependency chain --
            var result = _productService.GetAll(); //front-end ci okuyunca içinde data da okuyan bir veri veriyor diyor.
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); // eğer başarısız sa bad 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
    }
}