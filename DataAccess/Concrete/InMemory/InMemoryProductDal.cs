using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal 
    {
        List<Product> _products;
        public InMemoryProductDal()
        {    //Oracle, Sql Server, Postgres, MongoDb den geliyormuş gibi
            _products = new List<Product> 
            { 
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - dile gömülü sorgulama - Language Integrated Query
            //_products.Remove(product); --  silmez çünkü Parametrenin içindeki referans üsttekilerin referansından farklı - ama değer tipi olsa silerdik

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            // tek bir eleman bulmaya yarar -Yukarıdaki foeach işini yapıyor - işaret lambda- p kendi p si;

            //foreach (var p in _products)  
            //{
            //    if (product.ProductId == p.ProductId) -----> Benim üzerinde çalıştığım Id(p.ProductId) no ürünün ıd nosuna eşitse şunu yap: 
            //    {
            //        productToDelete = p; --->> Referansı atıyorum
            //    }
            //}dolayısı ile buraya gerek yok productToDelete i yukarı alıyoruz
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // içindeki bütün elemanları liste halinde geri döndürür. 
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product) //parametre benim göderdiğim ürün
        {
            //gönderdiğim ürün ıd sine sahip olan listedeki ürünü bul
            Product productToUpdate = productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;

        }
    }
}