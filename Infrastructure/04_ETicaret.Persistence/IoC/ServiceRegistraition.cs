using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_ETicaret.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _04_ETicaret.Persistence.IoC
{
    public static class ServiceRegistraition
    {
        //public static void AddPersistenceServices(this IServiceCollection services)
        //{
        //    ConfigurationManager configurationManager = new();
        //    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/05_ETicaret.API"));
        //    configurationManager.AddJsonFile("appsettings.json");
        //    DbContextOptionsBuilder<AppDbContext> builder = new();
        //    services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql("PostgresConnection"));

        //    return new(builder.Options);
        //}
    }
}
