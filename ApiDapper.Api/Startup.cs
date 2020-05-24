using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Domain.StoreContext.Services;
using ApiDapper.Infra.DataContexts;
using ApiDapper.Infra.StoreContext.Repositories;
using ApiDapper.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDapper.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // AddScoped só vai instanciar uma vez, verifica se já existe na memoria
            services.AddScoped<ApiDapperDataContext, ApiDapperDataContext>();
            // AddTransient vai instanciar toda vez que precisar
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
