using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentApi.Mediatr.Students;

namespace StudentApi.Mediatr
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<IStudentMapper, StudentMapper>();
            return services
                .AddMediatR(typeof(Dependencies).Assembly);
        }
    }
}
