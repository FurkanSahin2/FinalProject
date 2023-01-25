using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    // Context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        //Context, hangi veritabanına bağlanacağını bulması için 13-16 arasındaki kodları yazdık. "Trusted_Connection=true" yazarak kullanıcı adı ve şifreye ihtiyacı kaldırdık. (Şifresiz bağlantı)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        // Context hangi veritabanıyla çalışacağını buldu. Şimdi ise benim hangi classımın hangi tabloya karşılık geldiğini belirtiyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
