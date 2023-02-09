using API.Service.DB;
using API.Service.Interfaces;
using API.Service.Mapping;
using API.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace SalesOrderAPI.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           services.AddScoped<IOrderService, OrderService>()
                .AddAutoMapper(typeof(MapperProfile));
            return services;
        }
        public static IServiceCollection RegisterCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(configuration["policyName"],
                    policy =>
                    {
                        policy.WithOrigins(configuration["clientBaseUrl"])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            return services;
        }
    }
}
