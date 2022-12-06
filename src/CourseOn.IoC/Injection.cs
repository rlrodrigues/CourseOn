using CourseOn.Domain.Interfaces;
using CourseOn.Infrastructure.BaseContext;
using CourseOn.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseOn.IoC
{
    public static class Injection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            return services;
        }
        
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseOnContext>(options =>
            options.UseInMemoryDatabase(configuration["ConnectionString"]));

            return services;
        }
    }
}