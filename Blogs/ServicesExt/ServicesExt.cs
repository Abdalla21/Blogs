using Blogs.Infrastucture.DBContext;
using Blogs.Infrastucture.RepositoryContracts;
using BlogsCore.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Blogs.UI.ServicesExt
{
    public static class ServicesExt
    {
        public static IServiceCollection AddDBContextService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<BlogsDBContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            return services;
        }

        public static IServiceCollection AddBlogRepo(this IServiceCollection services)
        {

            services.AddScoped<IRepository, BlogRepository>();
            return services;
        }
    }
}
