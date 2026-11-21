using Library.BLL.Implementations;
using Library.BLL.Interfaces;
using Library.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.PL.Extensions
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
