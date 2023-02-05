using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMISAppLayer.DTO;
using PMISBLayer.Data; //namespace  ::change Name to Name of my busnis Layer
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer
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
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectTypeRepository, ProjectTypeRepository>();
            services.AddTransient<IProjectStatusRepository, ProjectStatusRepository>();
            services.AddTransient<IPhaseRepository, PhaseRepository>();
            services.AddTransient<IPhaseTypeRepository, PhaseTypeRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IDeliverableRepository, DeliverableRepository>();
            services.AddTransient<IPaymentTermRepository, PaymentTermRepository>();
            services.AddTransient<IProjectPhaseRepository, ProjectPhaseRepository>();
            

            var mapperConfig = new MapperConfiguration(mc =>
              {
                  mc.AddProfile(new MappingProfile());

              });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
            //Configuration.GetConnectionString("PMISAZURE")));

            services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
