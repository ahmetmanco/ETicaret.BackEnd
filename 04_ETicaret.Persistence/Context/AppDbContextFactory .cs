using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _04_ETicaret.Persistence_.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ETicaret;Username=postgres;Password=123456");

            return new AppDbContext(optionsBuilder.Options);
        }
        //DI (Dependency Injection) sistemi çalışamadığında ortaya çıkar. Projeye bu classı ve içindeki kodları eklediğimizde sorun çözüldü, migration işlemi başarılı bir şekilde oluştu
    }
}
