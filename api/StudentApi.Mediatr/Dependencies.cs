using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentApi.Mediatr.Students;
using StudentApi.Mediatr.Validators;

namespace StudentApi.Mediatr
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<IStudentMapper, StudentMapper>();
            services.AddScoped<IValidator<CreateStudentRequest>, CreateStudentRequestValidator>();
            return services
                .AddMediatR(typeof(Dependencies).Assembly);
        }
    }
}
