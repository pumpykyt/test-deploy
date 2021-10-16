using System.Globalization;
using Domain.Filters;
using Domain.Interfaces;
using DTO.Validators;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Domain.Installers
{
    public class CoreInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();
                    cfg.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "API Documentation"
                });
            });
            services.AddHangfire(t => t.UseSqlServerStorage(configuration["ConnectionString"]));
            services.AddHangfireServer();
        }
    }
}