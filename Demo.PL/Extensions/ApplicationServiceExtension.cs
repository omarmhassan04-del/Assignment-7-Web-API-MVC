using Demo.BLL.Implementations;
using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
