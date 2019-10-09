using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace CalculatorService.Server.Setup
{
    public static class Settings
    {
        /// <summary>
        /// Load all dependencies
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="Configuration">Configuration</param>
        /// <returns></returns>
        public static IServiceCollection LoadSomeDependencies(this IServiceCollection services, IConfiguration Configuration)
        {



            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = Configuration["Swagger:Name"], Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                string xmlPath = Path.Combine(AppContext.BaseDirectory, Configuration["Swagger:xmlFile"]);
                s.IncludeXmlComments(xmlPath);
            });

            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(Startup));

            services.AddRouting(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
