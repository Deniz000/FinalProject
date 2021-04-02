using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext  // DbContext EntityFrameworkCore dan geliyor 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //hangi veritabanı ile ilişki olduğunu kurduğumuz yer
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; } // database tabloları ile classlarımı bağla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; } // çoğullar database tablosu, içteki classım
        public DbSet<Order> Orders { get; set; }
    }
}
