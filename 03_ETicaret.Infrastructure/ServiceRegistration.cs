using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Abstractions.Storage;
using _03_ETicaret.Infrastructure_.Enums;
using _03_ETicaret.Infrastructure_.Services.Storage;
using _03_ETicaret.Infrastructure_.Services.Storage.Azurex;
using _03_ETicaret.Infrastructure_.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace _03_ETicaret.Infrastructure_
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureservices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;

                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;

                case StorageType.AWS:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;

                default:
                    throw new NotImplementedException($"{storageType} storage type is not implemented.");
            }
        }
    }
}
