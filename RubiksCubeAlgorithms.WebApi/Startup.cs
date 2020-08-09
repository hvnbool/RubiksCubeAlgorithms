using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RubiksCubeAlgorithmsWebApi.DAL;
using RubiksCubeAlgorithmsWebApi.Services.EFImplementations;
using RubiksCubeAlgorithmsWebApi.Services.Interfaces;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace RubiksCubeAlgorithmsWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<RubiksCubeContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("RubiksCubeConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Rubik's Cube API",
                    Description = "Web API for Rubik's Cube algorithms applications",
                    Contact = new OpenApiContact
                    {
                        Name = "Egor Kartashov",
                        Email = "egor.linkinked@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/egor-kartashov/")
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IMethodsService, EFMethodsService>();
            services.AddTransient<IStepsService, EFStepsService>();
            services.AddTransient<ICasesService, EFCasesService>();
            services.AddTransient<IAlgorithmsService, EFAlgorithmsService>();
            services.AddTransient<IImagesService, ImagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("https://localhost:3000").AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rubik's Cube API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
