using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models;
using HouseSaldoLab.Repositories;
using HouseSaldoLab.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HouseSaldoLab
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
            services.AddControllersWithViews();

            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=saldodb;Username=postgres;Password=qwerty1234"));
            services.AddDbContext<ApplicationContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IChargeService, ChargeService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IHouseService, HouseService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<SaldoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saldo API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Saldo API V1");
            });
        }
    }
}
