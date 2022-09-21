using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{   //Context: Vt tabloları ile Proje Class larını ilişkilendirmek
    public class NorthwindContext : DbContext //Hangi Vt'ye bağlanacak
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //proje hangi vt ile ilişkili olduğunu belirttiğimiz yer
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");//Connetcion string yazıyoruz
        }
        public DbSet<Product> Products { get; set; } //Hangi Nesne hangi vt nesnesine karşılık gelecek
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
