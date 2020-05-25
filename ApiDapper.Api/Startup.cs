using System;
using ApiDapper.Domain.StoreContext.Handlers;
using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Domain.StoreContext.Services;
using ApiDapper.Infra.DataContexts;
using ApiDapper.Infra.StoreContext.Repositories;
using ApiDapper.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog.Extensions.Logging;
using System.IO;
using ApiDapper.Shared;

namespace ApiDapper.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set;}
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            services.AddResponseCompression();

            // AddScoped só vai instanciar uma vez, verifica se já existe na memoria
            services.AddScoped<ApiDapperDataContext, ApiDapperDataContext>();
            // AddTransient vai instanciar toda vez que precisar
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Api com Dapper", Version = "v1" });
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddNLog();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(x => 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Api com Dapper");
            });
        }
    }
}
