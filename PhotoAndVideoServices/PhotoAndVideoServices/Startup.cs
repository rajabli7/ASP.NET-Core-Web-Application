using AutoMapper;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoAndVideoServices
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
            services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDataManager, DataManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddTransient<IServiceTypesRepository, ServiceTypesRepository>();
            services.AddTransient<IServicesRepository, ServiceRepository>();
            services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IAdditionsRepository, AdditionsRepository>();

            services.AddTransient<IServicesService, ServiceService>();
            services.AddTransient<IDepartmentsService, DepartmentsService>();
            services.AddTransient<IServiceTypesService, ServiceTypessService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IAdditionsService, AdditionsService>();


            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PhotoAndVideoServicesContext>(options => options.UseSqlServer(connection));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Photogallery}/{action=Index}/");
            });
        }
    }
}
