using ForApiProject.Data.IRepositories;
using ForApiProject.Data.Repositories;
using ForApiProject.Service.Interfaces;
using ForApiProject.Service.Services;

namespace ForApiProject.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomeServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

        }
    }
}
