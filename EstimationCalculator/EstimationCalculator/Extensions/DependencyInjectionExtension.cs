using Business.Contracts.Interface;
using Business.Services;
using Data.Contracts.Interface;
using Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EstimationCalculator.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection DependencyInjectionService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped<ICategoriesDataService, CategoriesDataService>();
            services.AddScoped<ICustomerCategoriesDataService, CustomerCategoriesDataService>();
            services.AddTransient<IEstimationService, EstimationService>();
            return services;
        }
    }
}
