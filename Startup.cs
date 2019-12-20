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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace acb_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var identitySettingSection = _configuration.GetSection("AppIdentitySettings");
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.AddDbContext<ACBSystemContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlConnection")));
            services.AddDbContext<AuthDbContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlAuthConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<AuthDbContext>();
            services.AddScoped<IDataContextAsync, ACBSystemContext>();

            // configure strongly typed settings objects      
            services.Configure<AppIdentitySettings>(identitySettingSection);
            services.Configure<AppSettings>(appSettingsSection);
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();
            services.AddScoped<IRepositoryAsync<Phone>, Repository<Phone>>();
            services.AddScoped<IPhoneService, PhoneService>();

            var identitySettings = identitySettingSection.Get<AppIdentitySettings>();

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Token);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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
