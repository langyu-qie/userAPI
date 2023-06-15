using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPractice.Repository;
//using WebApplicationPractice.Services;
using Microsoft.AspNetCore.Cors;

namespace WebApplicationPractice
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

            services.AddControllers();
            //services.AddSingleton<IUserRepository, UserRepository>();
            //services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<UserRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplicationPractice", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplicationPractice v1"));
            }

            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("http://localhost:3000").AllowAnyHeader()
            //        .AllowAnyMethod().AllowCredentials();
            //});
            //app.UseCors(options =>
            //{
            //    options.AllowAnyOrigin(); // Allow requests from any origin
            //    options.AllowAnyMethod(); // Allow all HTTP methods
            //    options.AllowAnyHeader(); // Allow all headers
            //});

            

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAllCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
