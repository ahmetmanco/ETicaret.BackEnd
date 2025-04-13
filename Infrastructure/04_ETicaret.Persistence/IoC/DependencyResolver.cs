using AutoMapper;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Repositories.Customer;
using _04_ETicaret.Persistence.Repositories;
using _04_ETicaret.Persistence.Repositories.Product;
using _04_ETicaret.Persistence.Repositories.Order;

namespace _04_ETicaret.Persistence.IoC
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
