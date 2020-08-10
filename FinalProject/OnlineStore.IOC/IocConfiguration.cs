using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Services;
using OnlineStore.DAL;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Repositories;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace OnlineStore.IOC
{
    public class IocConfiguration
    {
        public static void Register(Assembly mvcAssebly)
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            builder.RegisterControllers(mvcAssebly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ManufacturerRepository>().As<IManufacturerRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ProductAtOrderRepository>().As<IProductAtOrderRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<HalfOrderService>().As<IHalfOrderService>();
            builder.RegisterType<StoreDbContext>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<FullOrderService>().As<IFullOrderService>();
            builder.RegisterType<FullProductAtOrderService>().As<IFullProductAtOrderService>();
            builder.RegisterType<ManufacturerService>().As<IManufacturerService>();
            builder.RegisterType<HalfOrderService>().As<IHalfOrderService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ProductAtOrderService>().As<IProductAtOrderService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ReportProductStatisticService>().As<IReportProductStatisticService>();
            builder.RegisterType<ReportTopProductsService>().As<IReportTopProductsService>();
            builder.RegisterType<CommonReportService>().As<ICommonReportService>();
        }
    }
}
