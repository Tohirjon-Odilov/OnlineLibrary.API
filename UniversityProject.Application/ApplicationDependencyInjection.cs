using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UniversityProject.Application.Abstraction.AuthServices;
using UniversityProject.Application.Abstraction.EmailServices;
using UniversityProject.Application.UseCases.Books.Handlers;

namespace UniversityProject.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());   
            services.AddMediatR(typeof(CreateBookCommandHandler).Assembly);
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            
            return services;
        }
    }
}
