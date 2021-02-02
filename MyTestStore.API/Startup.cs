using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTestStore.BLL.Intefaces;
using MyTestStore.BLL.Services;
using MyTestStore.DLL;
using MyTestStore.DLL.Entities;
using MyTestStore.DLL.Interfaces;
using MyTestStore.DLL.Repositories;
using MyTestStore.DLL.Seeders;

namespace MyTestStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            using (var client = new MyDbContext())
            {
                client.Database.EnsureCreated();
                client.Database.Migrate();
            }
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddEntityFrameworkSqlite().AddDbContext<MyDbContext>();

            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IRepository<Client>, ClientsRepository>();

            services.AddAutoMapper(c => c.AddProfile<BLL.Mappers.AutoMapping>(), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            SeederDb.SeedData(app.ApplicationServices);
        }
    }
}
