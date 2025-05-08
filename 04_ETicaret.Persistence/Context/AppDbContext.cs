using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Base;
using _01_ETicaret.Domain.Entities;
using _01_ETicaret.Domain_.Entities;
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
        public DbSet<_01_ETicaret.Domain_.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ImageFiles { get; set; }
        public DbSet<InvoiceFile> I { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // yukarıdaki config dosyalarının kısaltılmış versiyonu using System.Reflection; indirilmesi gerek! 

            foreach (var foreingKey in builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.Now,
                    EntityState.Deleted => data.Entity.DeletedDate = DateTime.Now,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
