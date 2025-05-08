using AutoMapper;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence_.Repositories.Customer;
using _04_ETicaret.Persistence_.Repositories.Product;
using _04_ETicaret.Persistence_.Repositories.Order;
using _03_ETicaret.Infrastructure_.Services;
using _04_ETicaret.Persistence_.Repositories.File;
using _02_ETicaret.Application_.Repositories.File;
using _04_ETicaret.Persistence_.Repositories.ProductImageFile;
using _02_ETicaret.Application_.Repositories.ProductImageFile;
using _02_ETicaret.Application_.Repositories.InvoiceFile;
using _04_ETicaret.Persistence_.Repositories.InvoiceFile;
using _03_ETicaret.Infrastructure_.Services.Storage.Local;
using _02_ETicaret.Application_.Abstractions.Storage.Local;
using _03_ETicaret.Infrastructure_.Services.Storage;
using _02_ETicaret.Application_.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace _04_ETicaret.Persistence_.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterType<CustomerReadRepository>().As<ICustomerReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerWriteRepository>().As<ICustomerWriteRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ProductReadRepository>().As<IProductReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductWriteRepository>().As<IProductWriteRepository>().InstancePerLifetimeScope();

            builder.RegisterType<OrderReadRepository>().As<IOrderReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderWriteRepository>().As<IOrderWriteRepository>().InstancePerLifetimeScope();

            builder.RegisterType<FileReadRepository>().As<IFileReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FileWriteRepository>().As<IFileWriteRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ProductImageReadRepository>().As<IProductImageReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductImageWriteRepository>().As<IProductImageWriteRepository>().InstancePerLifetimeScope();

            builder.RegisterType<InvoicefileReadRepository>().As<IinvoiceReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InvoicefileWriteRepository>().As<IinvoiceWriteRepository>().InstancePerLifetimeScope();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
      
    }
}
