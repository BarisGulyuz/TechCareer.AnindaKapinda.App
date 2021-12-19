using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DependencyResolver
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //CATEGORY
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //PRODUCT
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManger>();
            //BASKET
            services.AddScoped<IBasketService, BasketManager>();
            //ORDER
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();
            //ORDERLİNE
            services.AddScoped<IOrderLinesDal, EfOrderLineDal>();
            services.AddScoped<IOrderLineService, OrderLineManager>();
            //ADRESS
            services.AddScoped<IAdressDal, EfAdressDal>();
            services.AddScoped<IAdressService, AdressManager>();
            //WORKER
            services.AddScoped<IWorkerDal, EfWorkerRepository>(); //EfWorkerDal
            services.AddScoped<IWorkerService, WorkerManager>();
            return services;
        }
    }
}
