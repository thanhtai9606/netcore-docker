using acb_app.Models;
using acb_app.Repositories.Contract;
using acb_app.Repositories.Services;
using BecamexIDC.Pattern.EF.DataContext;
using BecamexIDC.Pattern.EF.Factory;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.EF.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace acb_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.Json")
               .AddJsonFile("appsettings.Development.Json", true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
            // Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var identitySettingSection = Configuration.GetSection("AppIdentitySettings");
            services.AddDbContext<ACBSystemContext>(options => options.UseMySql(Configuration["ConnectionStrings:MySqlConnection"]));
            services.AddDbContext<AuthDbContext>(options => options.UseMySql(Configuration["ConnectionStrings:MySqlAuthConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<AuthDbContext>();
            services.AddScoped<IDataContextAsync, ACBSystemContext>();

            services.Configure<AppIdentitySettings>(identitySettingSection);
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();
            services.AddScoped<IRepositoryAsync<Phone>, Repository<Phone>>();
            services.AddScoped<IPhoneService, PhoneService>();

            services.AddControllers();
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
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
