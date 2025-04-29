using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _04_ETicaret.Persistence_.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Productss { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // yukarıdaki config dosyalarının kısaltılmış versiyonu using System.Reflection; indirilmesi gerek! 

            foreach (var foreingKey in builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
    }
}
