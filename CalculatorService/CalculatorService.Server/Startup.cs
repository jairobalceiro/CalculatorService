using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CalculatorService.Data;
using CalculatorService.Server.Setup;
using CalculatorService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace CalculatorService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.LoadSomeDependencies(Configuration);

            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<DaoCalculators>().As<IDaoCalculators>();
            builder.RegisterType<ServiceCalculators>().As<IServiceCalculators>();

            builder.Register(c => new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration)
               .MinimumLevel.Verbose()
               .Enrich.FromLogContext()
               //.WriteTo.
               .CreateLogger()).As<Serilog.ILogger>();

            return new AutofacServiceProvider(builder.Build());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // logging
            loggerFactory.AddSerilog();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint(Configuration["Swagger:Path"], Configuration["Swagger:Name"]);
            });


            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
