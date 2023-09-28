using FindJob.Core.Contracts;
using FindJob.Core.Services;
using FindJob.Infrastructure.Data.Common;

namespace FindJob.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProgrammerService, ProgrammerService>();
            services.AddScoped<ICompanyService, CompanyService>();

            return services;
        }
    }
}
